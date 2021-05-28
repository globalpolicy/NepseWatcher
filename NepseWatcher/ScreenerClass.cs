using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NepseWatcher
{

    public class ScreenerEventArgs : EventArgs
    {
        public List<string> ScreenedCompanySymbolsList { get; set; }

        public int Progress { get; set; }
        public string Message { get; set; }
        public Dictionary<string, CompanyAnalysisResult> CompanyAnalysisDict { get; set; }
        public ScreenerEventArgs(List<string> screenedCompanySymbolsList, Dictionary<string, CompanyAnalysisResult> companyAnalysisDict)
        {
            this.ScreenedCompanySymbolsList = screenedCompanySymbolsList;
            this.CompanyAnalysisDict = companyAnalysisDict;
        }

        public ScreenerEventArgs(int progress)
        {
            this.Progress = progress;
        }

        public ScreenerEventArgs(string message)
        {
            this.Message = message;
        }

    }

    public class ScreenerClass
    {
        #region Multithreading stuff
        private static readonly object lockObj = new object();
        #endregion

        #region Fields
        private List<string> originalListOfCompanySymbols;
        private List<string> screenedListOfCompanySymbols;

        private Dictionary<string, string> companiesTimeSeries = new Dictionary<string, string>();
        private Dictionary<string, CompanyAnalysisResult> companyAnalysisDict = new Dictionary<string, CompanyAnalysisResult>();
        #endregion

        #region Events
        public delegate void ScreeningCompletedHandler(object src, ScreenerEventArgs eventArgs);
        public delegate void ScreeningProgressUpdatedHandler(object src, ScreenerEventArgs eventArgs);
        public delegate void ScreeningOperationReporterHandler(object src, ScreenerEventArgs eventArgs);

        public event ScreeningCompletedHandler ScreeningCompleted;
        public event ScreeningProgressUpdatedHandler ScreeningProgressUpdated;
        public event ScreeningOperationReporterHandler ScreeningOperationReporter;
        #endregion

        #region Constructor
        public ScreenerClass(List<string> originalListOfCompanySymbols)
        {
            this.originalListOfCompanySymbols = originalListOfCompanySymbols;
        }
        #endregion

        #region Properties
        public List<string> OriginalListOfCompanySymbols
        {
            get
            {
                return this.originalListOfCompanySymbols;
            }
            set
            {
                this.originalListOfCompanySymbols = value;
            }
        }
        #endregion

        #region Public Methods
        public void Screen(ScreenerOptions screenerOptions)
        {
            new Thread(() =>
            {
                PopulateCompaniesTimeSeries(); //fill up the companiesTimeSeries dictionary
                screenedListOfCompanySymbols = originalListOfCompanySymbols; //default value. screenedListOfCompanySymbols will be incrementally pruned by screening algorithms such as candlestick screener, etc
                companyAnalysisDict = new Dictionary<string, CompanyAnalysisResult>(); //renew

                if (screenerOptions.CandleStickPatternOptions != null)
                {
                    CandleStickPattern(screenerOptions);
                }
                if (screenerOptions.MovingAverageOptions != null)
                {
                    MovingAverage(screenerOptions);
                }
                if (screenerOptions.ROIOptions != null)
                {
                    ROIAnalysis(screenerOptions);
                }
                OnScreeningCompleted();
            }).Start();

        }

        public void ClearCache()
        {
            companyAnalysisDict.Clear();
        }
        #endregion

        #region Private Methods
        //outputs to screenedListOfCompanySymbols
        private void CandleStickPattern(ScreenerOptions screenerOptions)
        {
            OnScreeningOperationReport("Searching for candlestick patterns..");
            List<string> newList = new List<string>();
            for (int i = 0; i < originalListOfCompanySymbols.Count; i++)
            {
                string company = originalListOfCompanySymbols[i];
                try
                {
                    JObject json;
                    try
                    {
                        json = JObject.Parse(companiesTimeSeries[company]);
                        if ((string)json["s"] != "ok") continue; //if no error in data
                    }
                    catch (Exception ex)
                    {
                        OnScreeningOperationReport($"Time series unavailable for {company}");
                        continue;
                    }


                    var cp = json["c"]; //closing prices
                    var op = json["o"]; //opening prices
                    var lp = json["l"]; //low prices
                    var hp = json["h"]; //high prices
                    List<float> closingPrices = cp.ToList().Select(token => (float)token).ToList();
                    List<float> openingPrices = op.ToList().Select(token => (float)token).ToList();
                    List<float> lowPrices = lp.ToList().Select(token => (float)token).ToList();
                    List<float> highPrices = hp.ToList().Select(token => (float)token).ToList();

                    Candle firstCandle = new Candle(openingPrices.GetThirdLast(), closingPrices.GetThirdLast(), highPrices.GetThirdLast(), lowPrices.GetThirdLast());
                    Candle secondCandle = new Candle(openingPrices.GetSecLast(), closingPrices.GetSecLast(), highPrices.GetSecLast(), lowPrices.GetSecLast());
                    Candle thirdCandle = new Candle(openingPrices.GetLast(), closingPrices.GetLast(), highPrices.GetLast(), lowPrices.GetLast());

                    if (screenerOptions.CandleStickPatternOptions.BullishEngulfing)
                    {
                        if (Candlesticks.IsBullishEngulfing(secondCandle, thirdCandle))
                            newList.Add(company);
                    }
                    if (screenerOptions.CandleStickPatternOptions.MorningStar)
                    {
                        if (Candlesticks.IsMorningStar(firstCandle, secondCandle, thirdCandle))
                            newList.Add(company);
                    }
                    if (screenerOptions.CandleStickPatternOptions.Hammer)
                    {
                        if (Candlesticks.IsHammer(thirdCandle))
                            newList.Add(company);
                    }
                    if (screenerOptions.CandleStickPatternOptions.BearishEngulfing)
                    {
                        if (Candlesticks.IsBearishEngulfing(secondCandle, thirdCandle))
                            newList.Add(company);
                    }
                    if (screenerOptions.CandleStickPatternOptions.EveningStar)
                    {
                        if (Candlesticks.IsEveningStar(firstCandle, secondCandle, thirdCandle))
                            newList.Add(company);
                    }


                }
                catch (ArgumentOutOfRangeException argrex)
                {
                    OnScreeningOperationReport($"Not enough data points for {company}");
                }
                catch (Exception ex)
                {
                    OnScreeningOperationReport($"Exception occurred for company: {company}.\r\n{ex.Message}");
                }

                OnScreeningProgressUpdated((int)((float)(i + 1) / (float)originalListOfCompanySymbols.Count * 100));
            }
            screenedListOfCompanySymbols = newList;

        }

        //outputs to companyAnalysisDict
        private void MovingAverage(ScreenerOptions screenerOptions)
        {
            int duration = screenerOptions.MovingAverageOptions.Duration;
            int lastNDataPoints = screenerOptions.MovingAverageOptions.SlopeDataPoints;
            int fallThroughPriceThreshold = screenerOptions.MovingAverageOptions.FallThroughPriceLimit;


            #region Calculate MA and MA slopes for all companies
            OnScreeningOperationReport("Calculating moving averages..");
            int cnt = 0;
            foreach (string company in screenedListOfCompanySymbols)
            {
                CompanyAnalysisResult companyAnalysisResult = new CompanyAnalysisResult(); //analysis result container class for each company
                try
                {
                    JObject json;
                    try
                    {
                        json = JObject.Parse(companiesTimeSeries[company]);
                        if ((string)json["s"] != "ok") continue; //if error in data
                    }
                    catch (Exception ex)
                    {
                        OnScreeningOperationReport($"Time series unavailable for {company}");
                        continue;
                    }


                    var cp = json["c"]; //closing prices
                    List<float> closingPrices = cp.ToList().Select(token => (float)token).ToList();
                    List<float> movingAverages = new List<float>();

                    //moving average calculation loop
                    for (int i = 0; i < closingPrices.Count; i++)
                    {
                        if (i < duration - 1) //MA(n) can't be calculated for the first 'n' values
                        {
                            movingAverages.Add(0);
                            continue;
                        }
                        List<float> toAverage = closingPrices.GetRange(i - (duration - 1), duration);
                        float average = toAverage.Average();
                        movingAverages.Add(average);
                    }

                    //moving average slope calculation
                    float movingAvgSlope = movingAverages.Last() - movingAverages[movingAverages.Count - lastNDataPoints];

                    //save to the analysis result dictionary
                    companyAnalysisResult.MovingAverages = movingAverages;
                    companyAnalysisResult.MovingAverageSlope = movingAvgSlope;
                    companyAnalysisDict.Add(company, companyAnalysisResult);


                }
                catch (ArgumentOutOfRangeException argrex)
                {
                    //do nothing here. the company doesn't have the required number of data points for this moving average
                }
                catch (InvalidOperationException inopex)
                {
                    //do nothing here. there's no timeseries data
                }
                catch (Exception ex)
                {
                    OnScreeningOperationReport($"Exception occurred for company {company}.\r\n{ex.Message}");
                }
                OnScreeningProgressUpdated((int)((float)++cnt / (float)screenedListOfCompanySymbols.Count * 100));
            }
            #endregion

            #region Calculation of fallthroughs for the MA curve
            if (screenerOptions.MovingAverageOptions.FallthroughThresholdEnabled)
            {
                OnScreeningOperationReport("Calculating fallthroughs..");
                List<string> companiesAfterMACalcs = companyAnalysisDict.Keys.ToList(); //get the company list after MA calculations

                for (int i = 0; i < companiesAfterMACalcs.Count; i++)
                {
                    string company = companiesAfterMACalcs[i];

                    try
                    {
                        JObject json = JObject.Parse(companiesTimeSeries[company]);
                        var cp = json["c"]; //closing prices
                        List<float> closingPrices = cp.ToList().Select(token => (float)token).ToList();

                        //populate the list of positions(index) of local minima
                        List<int> minimaPositions = new List<int>();
                        for (int j = 1; j < closingPrices.Count - 1; j++) //iterate from second to the second last element
                        {
                            if (closingPrices[j] < closingPrices[j - 1] && closingPrices[j] < closingPrices[j + 1])
                                minimaPositions.Add(j);
                        }

                        //calculate the number of significant fallthroughs
                        int noOfSignificantFallThroughs = 0;
                        for (int position = 0; position < minimaPositions.Count; position++)
                        {
                            int j = minimaPositions[position];
                            if (closingPrices[j] < companyAnalysisDict[company].MovingAverages[j]) //check if candle falls below the moving average curve
                            {
                                if (companyAnalysisDict[company].MovingAverages[j] - closingPrices[j] > fallThroughPriceThreshold) //if the fallthrough is significant
                                {
                                    noOfSignificantFallThroughs++;
                                }
                            }
                        }

                        //store the calculated fallthroughs
                        companyAnalysisDict[company].NoOfFallthroughs = noOfSignificantFallThroughs;
                    }
                    catch (ArgumentOutOfRangeException argrex)
                    {
                        //do nothing. the company doesn't have the required number of data points
                    }
                    catch (Exception ex)
                    {
                        OnScreeningOperationReport($"Exception occurred for company {company}.\r\n{ex.Message}");
                    }

                    //report progress
                    OnScreeningProgressUpdated((int)((float)(i + 1) / (float)screenedListOfCompanySymbols.Count * 100));

                }
            }


            #endregion



        }

        //outputs to companyAnalysisDict
        private void ROIAnalysis(ScreenerOptions screenerOptions)
        {
            OnScreeningOperationReport("Performing Return On Investment (ROI) analysis..");
            string[] durations = screenerOptions.ROIOptions.Durations.Split(";", StringSplitOptions.RemoveEmptyEntries);
            if (durations.Length == 0) return; //if no durations specified for ROI calculations, return

            int cnt = 0;
            foreach (string company in screenedListOfCompanySymbols)
            {
                Dictionary<int, float> avgRois = new Dictionary<int, float>(); //duration:average_roi pairs
                //if (company == "ADBL") System.Diagnostics.Debugger.Break();

                JObject json;
                try
                {
                    json = JObject.Parse(companiesTimeSeries[company]);
                    if ((string)json["s"] != "ok") continue; //if error in data(no data present, etc.)
                }
                catch (Exception ex)
                {
                    OnScreeningOperationReport($"Time series unavailable for {company}");
                    continue;
                }



                var cp = json["c"]; //closing prices
                List<float> closingPrices = cp.ToList().Select(token => (float)token).ToList();

                foreach (string _ in durations)
                {
                    int duration; //duration for calculating the ROI
                    if (!int.TryParse(_, out duration)) continue; //the duration specified was not an integer so goto the next duration

                    if (duration > closingPrices.Count - 1)
                    { //not enough data for this duration of ROI calculation
                        avgRois.Add(duration, 0); //put in 0
                        continue;
                    }

                    List<float> rois = new List<float>();
                    int index1 = 0, index2 = index1 + duration;
                    do
                    {
                        float roi = (closingPrices[index2] - closingPrices[index1]) / closingPrices[index1];
                        rois.Add(roi);
                        index1++;
                        index2 = index1 + duration;
                    } while (index2 < closingPrices.Count);

                    float avgRoi = 0;
                    if (screenerOptions.ROIOptions.SimpleAveraging)
                        avgRoi = rois.Average();
                    if (screenerOptions.ROIOptions.LinearAveraging)
                        avgRoi = rois.WeightedAverage(0);
                    if (screenerOptions.ROIOptions.LoglinearAveraging)
                        avgRoi = rois.WeightedAverage(1);
                    avgRois.Add(duration, avgRoi);
                }


                if (companyAnalysisDict.ContainsKey(company))
                    companyAnalysisDict[company].AverageROIs = avgRois;
                else
                    companyAnalysisDict.Add(company, new CompanyAnalysisResult() { AverageROIs = avgRois });

                OnScreeningProgressUpdated((int)(((float)cnt++ / (float)screenedListOfCompanySymbols.Count) * 100));
            }
            
        }


        /// <summary>
        /// fills up companiesTimeSeries dictionary with relevant timeseries for companies in the OriginalListOfCompanySymbols list
        /// </summary>
        private void PopulateCompaniesTimeSeries()
        {
            OnScreeningOperationReport("Loading companies' stocks...");

            //make a list of companies whose info isn't there in the companiesTimeSeries dictionary
            List<string> companiesToFetch = OriginalListOfCompanySymbols.FindAll(company =>
             {
                 if (companiesTimeSeries.ContainsKey(company))
                     return false;
                 return true;
             });

            if (companiesToFetch.Count == 0) return; //all companies are accounted for in the companiesTimeSeries dictionary

            //load timeseries for the companies of the companiesToFetch list from cache file if present and remove the companies off the list whose timeseries were found
            try
            {
                Dictionary<string, string> fileCache = HelperClass.LoadTimeSeriesCache(); //try to load time series dictionary from cache file
                List<string> tmp = new List<string>(); //temporary
                foreach (string missingCompany in companiesToFetch)
                {
                    if (fileCache.ContainsKey(missingCompany)) //if the cache has a company we'd like the timeseries of
                    {
                        companiesTimeSeries.Add(missingCompany, fileCache[missingCompany]); //add the company with its timeseries to companiesTimeSeries
                        tmp.Add(missingCompany); //add this company to a list
                    }
                }
                companiesToFetch.RemoveAll(company => tmp.Contains(company)); //remove any company from companiesToFetch, whose timeseries has been found and added to the companiesTimeSeries dictionary
            }
            catch (Exception ex)
            {
                //do nothing. general exceptions could be ioexception, filenotfound, etc.
                //anyway, after this catch block, remaining elements of the companiesToFetch list should be downloaded from the internet
            }

            //download timeseries for companies of the companiesToFetch list and store into the companiesTimeSeries dictionary
            int cntr = 0; //counter for no. of companies downloaded
            Parallel.ForEach(companiesToFetch, missingCompany =>
            {
                string timeseries = HelperClass.GetTimeSeriesData(missingCompany);
                lock (lockObj)
                {
                    companiesTimeSeries.Add(missingCompany, timeseries);
                    OnScreeningOperationReport($"Downloading stocks for {missingCompany}..");
                    OnScreeningProgressUpdated((int)(((float)++cntr / (float)companiesToFetch.Count) * 100));
                }
            });

            //since we're using the current datetimestamp to fetch timeseries, sometimes, systemxlite's API gives two observations for the current day
            //i've found this when trying to fetch after 5:45 PM on a trading day. one entry is for right after the market closes(sometime around 3 PM) and the other is
            //right at 5:45 PM, which happens to be the time at which all historic data seem to be recorded by systemxlite. so, check the last and the second last entries
            //and use the latter if they're for the same day
            foreach (string company in companiesTimeSeries.Keys.ToArray()) //directly iterating over companiesTimeSeries.Keys will not allow its entries to be modified inside the foreach loop. ToArray() creates a copy and hence is alright. ref:https://stackoverflow.com/questions/6177697/c-sharp-collection-was-modified-enumeration-operation-may-not-execute
            {
                string timeseries = companiesTimeSeries[company];
                JToken json = JToken.Parse(timeseries);
                if ((string)json["s"] != "ok") continue; //skip this company if error
                try
                {
                    var t = json["t"].ToList();
                    long lastTimestamp = (long)t[^1];
                    long secondLastTimestamp = (long)t[^2];
                    if (HelperClass.IsSameDate(lastTimestamp, secondLastTimestamp))
                    {
                        //remove the second last timestamp and corresponding closing, opening, high and low prices and volume
                        t.RemoveAt(t.Count - 2);
                        var c = json["c"].ToList(); c.RemoveAt(c.Count - 2);
                        var o = json["o"].ToList(); o.RemoveAt(o.Count - 2);
                        var h = json["h"].ToList(); h.RemoveAt(h.Count - 2);
                        var l = json["l"].ToList(); l.RemoveAt(l.Count - 2);
                        var v = json["v"].ToList(); v.RemoveAt(v.Count - 2);

                        JObject newJson = new JObject(new JProperty("s", "ok"), new JProperty("t", t), new JProperty("c", c), new JProperty("o", o), new JProperty("h", h), new JProperty("l", l), new JProperty("v", v));
                        companiesTimeSeries[company] = newJson.ToString();
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        #endregion

        #region Event handling methods
        protected virtual void OnScreeningCompleted()
        {
            OnScreeningProgressUpdated(100); //this is here because progress may not have reached a 100% as some companies may have been skipped
            HelperClass.SaveTimeSeriesCache(companiesTimeSeries);
            if (ScreeningCompleted != null) //if non-zero number of subscribers to this event
                ScreeningCompleted(this, new ScreenerEventArgs(screenedListOfCompanySymbols, companyAnalysisDict));
        }

        protected virtual void OnScreeningProgressUpdated(int progress)
        {
            if (ScreeningProgressUpdated != null)
                ScreeningProgressUpdated(this, new ScreenerEventArgs(progress));
        }

        protected virtual void OnScreeningOperationReport(string message)
        {
            if (ScreeningOperationReporter != null)
                ScreeningOperationReporter(this, new ScreenerEventArgs(message));
        }
        #endregion
    }


    public class CompanyAnalysisResult
    {

        private List<float> movingAverages;
        private float movingAverageSlope;
        private int noOfFallthroughs;
        private Dictionary<int, float> avgROIs;

        public List<float> MovingAverages { get => movingAverages; set => movingAverages = value; }
        public float MovingAverageSlope { get => movingAverageSlope; set => movingAverageSlope = value; }
        public int NoOfFallthroughs { get => noOfFallthroughs + 1; set => noOfFallthroughs = value; }
        public Dictionary<int, float> AverageROIs { get => avgROIs; set => avgROIs = value; }

    }

    public class ScreenerOptions
    {
        public MovingAverageOptions MovingAverageOptions { get; set; }
        public CandleStickPatternOptions CandleStickPatternOptions { get; set; }
        public ROIOptions ROIOptions { get; set; }

    }
    public class MovingAverageOptions
    {
        private int duration;
        private int slopeDataPoints;
        private bool fallthroughThresholdEnabled;
        private int fallThroughPriceLimit;
        private int maxFallThroughs;

        public int Duration { get => duration; set => duration = value; }
        public int SlopeDataPoints { get => slopeDataPoints; set => slopeDataPoints = value; }
        public bool FallthroughThresholdEnabled { get => fallthroughThresholdEnabled; set => fallthroughThresholdEnabled = value; }
        public int FallThroughPriceLimit { get => fallThroughPriceLimit; set => fallThroughPriceLimit = value; }
        public int MaxFallThroughs { get => maxFallThroughs; set => maxFallThroughs = value; }
    }

    public class CandleStickPatternOptions
    {
        private bool bullishEngulfing;
        private bool morningStar;
        private bool hammer;
        private bool bearishEngulfing;
        private bool eveningStar;


        public bool BullishEngulfing { get => bullishEngulfing; set => bullishEngulfing = value; }
        public bool MorningStar { get => morningStar; set => morningStar = value; }
        public bool Hammer { get => hammer; set => hammer = value; }
        public bool BearishEngulfing { get => bearishEngulfing; set => bearishEngulfing = value; }
        public bool EveningStar { get => eveningStar; set => eveningStar = value; }
    }

    public class ROIOptions
    {
        private string durations;
        private bool simpleAveraging;
        private bool linearAveraging;
        private bool loglinearAveraging;

        public string Durations { get => durations; set => durations = value; }
        public bool SimpleAveraging { get => simpleAveraging; set => simpleAveraging = value; }
        public bool LinearAveraging { get => linearAveraging; set => linearAveraging = value; }
        public bool LoglinearAveraging { get => loglinearAveraging; set => loglinearAveraging = value; }
    }
}
