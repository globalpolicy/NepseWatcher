using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NepseWatcher
{
    public static class HelperClass
    {
        private static string GetCurrentUnixTimeStamp()
        {
            string timeStampNow = ((long)((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)).ToString();
            return timeStampNow;
        }

        private static string GetOneYearBackUnixTimeStamp()
        {
            string timeStampYesteryear = ((long)((DateTime.Now.AddYears(-1) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)).ToString();
            return timeStampYesteryear;
        }

        /// <summary>
        /// Downloads time series up to a year back from today for the specified company
        /// </summary>
        /// <param name="companySymbol"></param>
        /// <returns></returns>
        public static string GetTimeSeriesData(string companySymbol)
        {
            string retVal = "";

            string currentTimestamp = GetCurrentUnixTimeStamp();
            string oneYearAgoTimestamp = GetOneYearBackUnixTimeStamp();


            string dataURL = $"https://backendtradingview.systemxlite.com/tradingViewSystemxLite/history?symbol={companySymbol}&resolution=1D&from={oneYearAgoTimestamp}&to={currentTimestamp}";

            HttpClient httpClient = new HttpClient();

            var httpResponseMessage = httpClient.GetAsync(dataURL).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string dataContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                retVal = dataContent;
            }

            return retVal;
        }

        /// <summary>
        /// Gets all available time series data for the specified company, from the first entry to the most recent
        /// </summary>
        /// <param name="companySymbol"></param>
        /// <returns></returns>
        private static string GetTimeSeriesDataTotal(string companySymbol)
        {
            string retVal = "";

            string currentTimestamp = GetCurrentUnixTimeStamp();

            //the "from" query parameter in the URL below is sometime in 2004. doesn't really matter as long as it's earlier than the date the company was first listed in NEPSE
            string dataURL = $"https://backendtradingview.systemxlite.com/tradingViewSystemxLite/history?symbol={companySymbol}&resolution=1D&from=1085135332&to={currentTimestamp}";

            HttpClient httpClient = new HttpClient();

            var httpResponseMessage = httpClient.GetAsync(dataURL).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string dataContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                retVal = dataContent;
            }

            return retVal;
        }

        /// <summary>
        /// Loads and returns a dictionary of companies and their time series from a cache file dated today if found. If no cache file found, returns an empty dictionary.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> LoadTimeSeriesCache()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();

            string today = DateTime.Today.ToString("yyyy-MMM-dd");
            string contents = File.ReadAllText($"NepseWatch_{today}.txt");
            retVal = JsonConvert.DeserializeObject<Dictionary<string, string>>(contents);

            return retVal;
        }

        /// <summary>
        /// Saves (overwrites if already present) the given dictionary of companies and their time series to a cache file dated today.
        /// </summary>
        /// <param name="companiesDict"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        public static bool SaveTimeSeriesCache(Dictionary<string, string> companiesDict)
        {
            bool retVal = false;

            string json = JsonConvert.SerializeObject(companiesDict, Formatting.Indented);
            string today = DateTime.Today.ToString("yyyy-MMM-dd");

            File.WriteAllText($"NepseWatch_{today}.txt", json);
            retVal = true;

            return retVal;
        }

        /// <summary>
        /// Deletes the cache file
        /// </summary>
        /// <returns></returns>
        public static bool DeleteCacheFile()
        {
            bool retVal = true;
            string today = DateTime.Today.ToString("yyyy-MMM-dd");
            try
            {
                File.Delete($"NepseWatch_{today}.txt");
            }
            catch (Exception ex)
            {
                retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Reads the specified stream interpreted as a CSV file consisting of the fields: symbol,name,sector,entryDate,entryPrice,quantity. Then returns a BindingList of corresponding WatchListEntry elements. Skips entries if error.
        /// </summary>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static BindingList<WatchListEntry> GetWatchListEntries(string filename)
        {
            BindingList<WatchListEntry> watchListEntries = new BindingList<WatchListEntry>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = null;
                while (true)
                {
                    try
                    {
                        line = reader.ReadLine();
                        if (line == null) break;
                        string[] tokens = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                        string symbol = tokens[0];
                        string name = tokens[1];
                        string sector = tokens[2];
                        DateTime entryDate = DateTime.Parse(tokens[3]);
                        float entryPrice = float.Parse(tokens[4]);
                        int quantity = int.Parse(tokens[5]);
                        watchListEntries.Add(new WatchListEntry() { Symbol = symbol, FullName = name, Sector = sector, EntryDate = entryDate, EntryPrice = entryPrice, Quantity = quantity });
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

            }
            return watchListEntries;
        }

        /// <summary>
        /// Write the given BindingList<WatchListEntry> using the specified stream to a CSV file consisting of the fields: symbol,name,sector,entryDate,entryPrice,quantity.
        /// </summary>
        /// <param name="fileStream"></param>
        public static void SaveWatchListEntries(string filename, BindingList<WatchListEntry> watchListEntries)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                foreach (WatchListEntry entry in watchListEntries)
                {
                    streamWriter.WriteLine($"{entry.Symbol},{entry.FullName},{entry.Sector},{entry.EntryDate},{entry.EntryPrice},{entry.Quantity}");
                }
            }
        }


        /// <summary>
        /// Gets the most recent closing price of the given company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public static double GetLastClosingPrice(string company)
        {
            string timeSeries = GetTimeSeriesDataTotal(company);

            JObject json;
            json = JObject.Parse(timeSeries);
            if ((string)json["s"] != "ok") throw new Exception("Time series unavailable."); //if no error in data
            var cp = json["c"]; //closing prices
            List<double> closingPrices = cp.ToList().Select(token => (double)token).ToList();

            return closingPrices.GetLast();
        }

        /// <summary>
        /// Returns an anonymous type containing (i) total cost of shares while buying (after tax, commission, etc) (ii) total receivable amount after selling (after tax, commission, etc) (iii) total profit (after tax, commission, etc). Method basically copied from https://www.sharesansar.com/share-calculator 's javascript source
        /// </summary>
        /// <param name="qt">Quantity of shares</param>
        /// <param name="buying_price">Price of shares while buying</param>
        /// <param name="selling_price">Price of shares while selling</param>
        /// <returns></returns>
        public static object CalculatePricesWithDeductibles(int qt, double buying_price, double selling_price)
        {
            double total = qt * buying_price;

            double r = 15e-5 * total;
            double brokerCommission = getBrokerCommission(total);

            if (brokerCommission < 10)
                brokerCommission = 10;

            double c = total + r + 25 + brokerCommission;

            double m = c / qt;

            double costPrice = m * qt;

            double d = qt * selling_price;

            double u = getBrokerCommission(d);

            if (u < 10)
                u = 10;

            double f = 15e-5 * d;

            double y = d - u - f;

            double _ = y - c;

            double g;
            if (_ > 0)
                g = 0.05 * _;
            else
                g = 0;

            double totalReceivableAmount = y - g - 25;

            double profit = totalReceivableAmount - costPrice;

            return new { TotalCostOfSharesWhileBuying = costPrice, TotalReceivableAmtAfterSale = totalReceivableAmount, TotalProfit = profit };
        }

        private static double getBrokerCommission(double total)
        {
            double e = 0;
            if (total <= 50000)
                e = 0.4;
            else if ((total > 50000) && (total < 500000))
                e = 0.37;
            else if ((total > 500000) && (total < 2000000))
                e = 0.34;
            else if ((total > 2000000) && (total < 10000000))
                e = 0.3;
            else if (total > 10000000)
                e = 0.27;
            return total * e / 100;
        }

    }
}