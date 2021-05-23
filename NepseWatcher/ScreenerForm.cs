using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace NepseWatcher
{
    public partial class ScreenerForm : Form
    {
        private ScreenerClass screenerClass;

        #region Properties
        public List<string> CompanySymbolsList { get; set; }
        #endregion

        #region Events
        public delegate void ScreeningCompletedHandler(object src, ScreenerEventArgs eventArgs);
        public event ScreeningCompletedHandler ScreeningCompleted;

        public delegate void ScreeningProgressUpdatedHandler(object src, ScreenerEventArgs eventArgs);
        public event ScreeningProgressUpdatedHandler ScreeningProgressUpdated;

        public delegate void ScreeningStartedHandler(object src, ScreenerEventArgs eventArgs);
        public event ScreeningStartedHandler ScreeningStarted;

        public delegate void ScreeningOperationReporterHandler(object src, ScreenerEventArgs eventArgs);
        public event ScreeningOperationReporterHandler ScreeningOperationReporter;

        #endregion

        public ScreenerForm()
        {
            InitializeComponent();
        }

        #region UI Event Handlers
        private void checkBoxSupportThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSupportThreshold.Checked)
            {
                textBoxFallThroughPriceLimit.Enabled = true;
                textBoxMaxFallThroughs.Enabled = true;
            }
            else
            {
                textBoxFallThroughPriceLimit.Enabled = false;
                textBoxMaxFallThroughs.Enabled = false;
            }
        }

        private void buttonScreenRun_Click(object sender, EventArgs e)
        {
            ScreenerOptions screenerOptions = new ScreenerOptions();
            if (checkBoxEnableMovingAverage.Checked) //if moving average option is checked,
            {
                MovingAverageOptions movingAverageOptions = new MovingAverageOptions()
                {
                    Duration = int.Parse(this.comboBoxMADuration.Text),
                    SlopeDataPoints = int.Parse(this.textBoxMASlopeDataPoints.Text),
                    FallthroughThresholdEnabled = this.checkBoxSupportThreshold.Checked,
                    FallThroughPriceLimit = int.Parse(this.textBoxFallThroughPriceLimit.Text),
                    MaxFallThroughs = int.Parse(this.textBoxMaxFallThroughs.Text)
                };
                screenerOptions.MovingAverageOptions = movingAverageOptions;
            };
            if (checkBoxCandlesticksEnable.Checked) //if candlestick option is checked,
            {
                CandleStickPatternOptions candleStickPatternOptions = new CandleStickPatternOptions()
                {
                    BullishEngulfing = radioButtonBullishEngulfing.Checked,
                    MorningStar = radioButtonMorningStar.Checked,
                    Hammer = radioButtonHammer.Checked,
                    BearishEngulfing = radioButtonBearishEngulfing.Checked,
                    EveningStar = radioButtonEveningStar.Checked
                };
                screenerOptions.CandleStickPatternOptions = candleStickPatternOptions;
            }
            if (checkBoxROIEnable.Checked) //if ROI option is checked,
            {
                ROIOptions rOIOptions = new ROIOptions()
                {
                    Durations = textBoxROIDurations.Text,
                    SimpleAveraging = radioButtonSimpleAverage.Checked,
                    LinearAveraging = radioButtonLinearAverage.Checked,
                    LoglinearAveraging = radioButtonLogAverage.Checked
                };
                screenerOptions.ROIOptions = rOIOptions;
            }



            if (screenerClass == null)
                screenerClass = new ScreenerClass(CompanySymbolsList);

            screenerClass.OriginalListOfCompanySymbols = CompanySymbolsList;

            //remove any previous event handlers
            screenerClass.ScreeningCompleted -= OnScreeningCompleted;
            screenerClass.ScreeningProgressUpdated -= OnScreeningProgressUpdated;
            screenerClass.ScreeningOperationReporter -= OnScreeningOperationReporter;

            //attach event handlers
            screenerClass.ScreeningCompleted += OnScreeningCompleted; //simply pass along the completed event
            screenerClass.ScreeningProgressUpdated += OnScreeningProgressUpdated;  //simply pass along the completed event
            screenerClass.ScreeningOperationReporter += OnScreeningOperationReporter;  //simply pass along the completed event

            ScreeningStarted(this, null);
            screenerClass.Screen(screenerOptions);

            Hide();
        }

        private void ScreenerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void OnScreeningCompleted(object src, ScreenerEventArgs eventArgs)
        {
            ScreeningCompleted(src, eventArgs);
        }

        private void OnScreeningProgressUpdated(object src, ScreenerEventArgs eventArgs)
        {
            ScreeningProgressUpdated(src, eventArgs);
        }

        private void OnScreeningOperationReporter(object src, ScreenerEventArgs eventArgs)
        {
            ScreeningOperationReporter(src, eventArgs);
        }
        #endregion

        #region Public methods

        public void ClearCache()
        {
            if (screenerClass != null)
                screenerClass.ClearCache();
        }

        public bool IsMovingAverageAnalysisEnabled()
        {
            return checkBoxEnableMovingAverage.Checked;
        }

        public bool IsFallthroughAnalysisEnabled()
        {
            return checkBoxSupportThreshold.Checked;
        }

        public bool IsCandlestickScreeningEnabled()
        {
            return checkBoxCandlesticksEnable.Checked;
        }

        public bool IsROIAnalysisEnabled(out int[] durations)
        {
            List<int> durs= new List<int>();
            var tokens = textBoxROIDurations.Text.Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                int dur;
                if (int.TryParse(token,out dur))
                {
                    if (dur > 0)
                        durs.Add(dur);
                }
            }
            durations = durs.ToArray();
            return checkBoxROIEnable.Checked;
        }

        #endregion
    }
}
