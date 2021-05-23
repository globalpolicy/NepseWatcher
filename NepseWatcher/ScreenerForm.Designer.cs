
namespace NepseWatcher
{
    partial class ScreenerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenerForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxEnableMovingAverage = new System.Windows.Forms.CheckBox();
            this.textBoxMASlopeDataPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMaxFallThroughs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFallThroughPriceLimit = new System.Windows.Forms.TextBox();
            this.checkBoxSupportThreshold = new System.Windows.Forms.CheckBox();
            this.comboBoxMADuration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.radioButtonEveningStar = new System.Windows.Forms.RadioButton();
            this.radioButtonBearishEngulfing = new System.Windows.Forms.RadioButton();
            this.radioButtonHammer = new System.Windows.Forms.RadioButton();
            this.checkBoxCandlesticksEnable = new System.Windows.Forms.CheckBox();
            this.radioButtonMorningStar = new System.Windows.Forms.RadioButton();
            this.radioButtonBullishEngulfing = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxROIDurations = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxROIEnable = new System.Windows.Forms.CheckBox();
            this.buttonScreenRun = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radioButtonSimpleAverage = new System.Windows.Forms.RadioButton();
            this.radioButtonLinearAverage = new System.Windows.Forms.RadioButton();
            this.radioButtonLogAverage = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(455, 129);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxEnableMovingAverage);
            this.tabPage1.Controls.Add(this.textBoxMASlopeDataPoints);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.comboBoxMADuration);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 101);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Moving Average";
            this.tabPage1.ToolTipText = "Moving Average";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableMovingAverage
            // 
            this.checkBoxEnableMovingAverage.AutoSize = true;
            this.checkBoxEnableMovingAverage.Checked = true;
            this.checkBoxEnableMovingAverage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableMovingAverage.Location = new System.Drawing.Point(8, 3);
            this.checkBoxEnableMovingAverage.Name = "checkBoxEnableMovingAverage";
            this.checkBoxEnableMovingAverage.Size = new System.Drawing.Size(61, 19);
            this.checkBoxEnableMovingAverage.TabIndex = 5;
            this.checkBoxEnableMovingAverage.Text = "Enable";
            this.checkBoxEnableMovingAverage.UseVisualStyleBackColor = true;
            // 
            // textBoxMASlopeDataPoints
            // 
            this.textBoxMASlopeDataPoints.Location = new System.Drawing.Point(105, 59);
            this.textBoxMASlopeDataPoints.Name = "textBoxMASlopeDataPoints";
            this.textBoxMASlopeDataPoints.Size = new System.Drawing.Size(62, 23);
            this.textBoxMASlopeDataPoints.TabIndex = 4;
            this.textBoxMASlopeDataPoints.Text = "5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slope data points";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMaxFallThroughs);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFallThroughPriceLimit);
            this.groupBox1.Controls.Add(this.checkBoxSupportThreshold);
            this.groupBox1.Location = new System.Drawing.Point(173, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fallthrough threshold";
            // 
            // textBoxMaxFallThroughs
            // 
            this.textBoxMaxFallThroughs.Location = new System.Drawing.Point(153, 42);
            this.textBoxMaxFallThroughs.Name = "textBoxMaxFallThroughs";
            this.textBoxMaxFallThroughs.Size = new System.Drawing.Size(35, 23);
            this.textBoxMaxFallThroughs.TabIndex = 4;
            this.textBoxMaxFallThroughs.Text = "5";
            this.toolTip1.SetToolTip(this.textBoxMaxFallThroughs, resources.GetString("textBoxMaxFallThroughs.ToolTip"));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Max. fall throughs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fall through price limit";
            // 
            // textBoxFallThroughPriceLimit
            // 
            this.textBoxFallThroughPriceLimit.Location = new System.Drawing.Point(153, 16);
            this.textBoxFallThroughPriceLimit.Name = "textBoxFallThroughPriceLimit";
            this.textBoxFallThroughPriceLimit.Size = new System.Drawing.Size(35, 23);
            this.textBoxFallThroughPriceLimit.TabIndex = 1;
            this.textBoxFallThroughPriceLimit.Text = "10";
            this.toolTip1.SetToolTip(this.textBoxFallThroughPriceLimit, "If a local minimum of a stock falls below the moving average curve by this amount" +
        ", count it as a fallthrough.");
            // 
            // checkBoxSupportThreshold
            // 
            this.checkBoxSupportThreshold.AutoSize = true;
            this.checkBoxSupportThreshold.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxSupportThreshold.Checked = true;
            this.checkBoxSupportThreshold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSupportThreshold.Location = new System.Drawing.Point(127, 2);
            this.checkBoxSupportThreshold.Name = "checkBoxSupportThreshold";
            this.checkBoxSupportThreshold.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSupportThreshold.TabIndex = 0;
            this.checkBoxSupportThreshold.UseVisualStyleBackColor = false;
            this.checkBoxSupportThreshold.CheckedChanged += new System.EventHandler(this.checkBoxSupportThreshold_CheckedChanged);
            // 
            // comboBoxMADuration
            // 
            this.comboBoxMADuration.AutoCompleteCustomSource.AddRange(new string[] {
            "5",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "44",
            "50",
            "100"});
            this.comboBoxMADuration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMADuration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxMADuration.FormattingEnabled = true;
            this.comboBoxMADuration.Items.AddRange(new object[] {
            "5",
            "9",
            "10",
            "15",
            "20",
            "25",
            "30",
            "44",
            "50",
            "100"});
            this.comboBoxMADuration.Location = new System.Drawing.Point(105, 28);
            this.comboBoxMADuration.Name = "comboBoxMADuration";
            this.comboBoxMADuration.Size = new System.Drawing.Size(62, 23);
            this.comboBoxMADuration.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duration";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.radioButtonEveningStar);
            this.tabPage2.Controls.Add(this.radioButtonBearishEngulfing);
            this.tabPage2.Controls.Add(this.radioButtonHammer);
            this.tabPage2.Controls.Add(this.checkBoxCandlesticksEnable);
            this.tabPage2.Controls.Add(this.radioButtonMorningStar);
            this.tabPage2.Controls.Add(this.radioButtonBullishEngulfing);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 101);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Candlesticks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // radioButtonEveningStar
            // 
            this.radioButtonEveningStar.AutoSize = true;
            this.radioButtonEveningStar.Location = new System.Drawing.Point(159, 50);
            this.radioButtonEveningStar.Name = "radioButtonEveningStar";
            this.radioButtonEveningStar.Size = new System.Drawing.Size(89, 19);
            this.radioButtonEveningStar.TabIndex = 5;
            this.radioButtonEveningStar.Text = "Evening star";
            this.radioButtonEveningStar.UseVisualStyleBackColor = true;
            // 
            // radioButtonBearishEngulfing
            // 
            this.radioButtonBearishEngulfing.AutoSize = true;
            this.radioButtonBearishEngulfing.Location = new System.Drawing.Point(159, 30);
            this.radioButtonBearishEngulfing.Name = "radioButtonBearishEngulfing";
            this.radioButtonBearishEngulfing.Size = new System.Drawing.Size(117, 19);
            this.radioButtonBearishEngulfing.TabIndex = 4;
            this.radioButtonBearishEngulfing.Text = "Bearish engulfing";
            this.radioButtonBearishEngulfing.UseVisualStyleBackColor = true;
            // 
            // radioButtonHammer
            // 
            this.radioButtonHammer.AutoSize = true;
            this.radioButtonHammer.Location = new System.Drawing.Point(9, 70);
            this.radioButtonHammer.Name = "radioButtonHammer";
            this.radioButtonHammer.Size = new System.Drawing.Size(77, 19);
            this.radioButtonHammer.TabIndex = 3;
            this.radioButtonHammer.Text = "Hammers";
            this.toolTip1.SetToolTip(this.radioButtonHammer, "Hammer/inverted hammer/hanging man/shooting star");
            this.radioButtonHammer.UseVisualStyleBackColor = true;
            // 
            // checkBoxCandlesticksEnable
            // 
            this.checkBoxCandlesticksEnable.AutoSize = true;
            this.checkBoxCandlesticksEnable.Checked = true;
            this.checkBoxCandlesticksEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCandlesticksEnable.Location = new System.Drawing.Point(9, 5);
            this.checkBoxCandlesticksEnable.Name = "checkBoxCandlesticksEnable";
            this.checkBoxCandlesticksEnable.Size = new System.Drawing.Size(61, 19);
            this.checkBoxCandlesticksEnable.TabIndex = 2;
            this.checkBoxCandlesticksEnable.Text = "Enable";
            this.checkBoxCandlesticksEnable.UseVisualStyleBackColor = true;
            // 
            // radioButtonMorningStar
            // 
            this.radioButtonMorningStar.AutoSize = true;
            this.radioButtonMorningStar.Location = new System.Drawing.Point(9, 50);
            this.radioButtonMorningStar.Name = "radioButtonMorningStar";
            this.radioButtonMorningStar.Size = new System.Drawing.Size(93, 19);
            this.radioButtonMorningStar.TabIndex = 1;
            this.radioButtonMorningStar.Text = "Morning star";
            this.radioButtonMorningStar.UseVisualStyleBackColor = true;
            // 
            // radioButtonBullishEngulfing
            // 
            this.radioButtonBullishEngulfing.AutoSize = true;
            this.radioButtonBullishEngulfing.Checked = true;
            this.radioButtonBullishEngulfing.Location = new System.Drawing.Point(9, 30);
            this.radioButtonBullishEngulfing.Name = "radioButtonBullishEngulfing";
            this.radioButtonBullishEngulfing.Size = new System.Drawing.Size(114, 19);
            this.radioButtonBullishEngulfing.TabIndex = 0;
            this.radioButtonBullishEngulfing.TabStop = true;
            this.radioButtonBullishEngulfing.Text = "Bullish engulfing";
            this.radioButtonBullishEngulfing.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.radioButtonLogAverage);
            this.tabPage3.Controls.Add(this.radioButtonLinearAverage);
            this.tabPage3.Controls.Add(this.radioButtonSimpleAverage);
            this.tabPage3.Controls.Add(this.textBoxROIDurations);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.checkBoxROIEnable);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(447, 101);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ROI";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxROIDurations
            // 
            this.textBoxROIDurations.Location = new System.Drawing.Point(96, 29);
            this.textBoxROIDurations.Name = "textBoxROIDurations";
            this.textBoxROIDurations.Size = new System.Drawing.Size(324, 23);
            this.textBoxROIDurations.TabIndex = 1;
            this.textBoxROIDurations.Text = "10;20;30;40;50;80;110;150;200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Test durations:";
            // 
            // checkBoxROIEnable
            // 
            this.checkBoxROIEnable.AutoSize = true;
            this.checkBoxROIEnable.Checked = true;
            this.checkBoxROIEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxROIEnable.Location = new System.Drawing.Point(9, 5);
            this.checkBoxROIEnable.Name = "checkBoxROIEnable";
            this.checkBoxROIEnable.Size = new System.Drawing.Size(61, 19);
            this.checkBoxROIEnable.TabIndex = 0;
            this.checkBoxROIEnable.Text = "Enable";
            this.checkBoxROIEnable.UseVisualStyleBackColor = true;
            // 
            // buttonScreenRun
            // 
            this.buttonScreenRun.Location = new System.Drawing.Point(4, 131);
            this.buttonScreenRun.Name = "buttonScreenRun";
            this.buttonScreenRun.Size = new System.Drawing.Size(75, 23);
            this.buttonScreenRun.TabIndex = 1;
            this.buttonScreenRun.Text = "Run";
            this.buttonScreenRun.UseVisualStyleBackColor = true;
            this.buttonScreenRun.Click += new System.EventHandler(this.buttonScreenRun_Click);
            // 
            // radioButtonSimpleAverage
            // 
            this.radioButtonSimpleAverage.AutoSize = true;
            this.radioButtonSimpleAverage.Checked = true;
            this.radioButtonSimpleAverage.Location = new System.Drawing.Point(12, 62);
            this.radioButtonSimpleAverage.Name = "radioButtonSimpleAverage";
            this.radioButtonSimpleAverage.Size = new System.Drawing.Size(105, 19);
            this.radioButtonSimpleAverage.TabIndex = 2;
            this.radioButtonSimpleAverage.TabStop = true;
            this.radioButtonSimpleAverage.Text = "Simple average";
            this.radioButtonSimpleAverage.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinearAverage
            // 
            this.radioButtonLinearAverage.AutoSize = true;
            this.radioButtonLinearAverage.Location = new System.Drawing.Point(123, 62);
            this.radioButtonLinearAverage.Name = "radioButtonLinearAverage";
            this.radioButtonLinearAverage.Size = new System.Drawing.Size(153, 19);
            this.radioButtonLinearAverage.TabIndex = 3;
            this.radioButtonLinearAverage.Text = "Linear weighted average";
            this.radioButtonLinearAverage.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogAverage
            // 
            this.radioButtonLogAverage.AutoSize = true;
            this.radioButtonLogAverage.Location = new System.Drawing.Point(282, 62);
            this.radioButtonLogAverage.Name = "radioButtonLogAverage";
            this.radioButtonLogAverage.Size = new System.Drawing.Size(141, 19);
            this.radioButtonLogAverage.TabIndex = 4;
            this.radioButtonLogAverage.Text = "Log weighted average";
            this.radioButtonLogAverage.UseVisualStyleBackColor = true;
            // 
            // ScreenerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 165);
            this.Controls.Add(this.buttonScreenRun);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScreenerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Screener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenerForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonScreenRun;
        private System.Windows.Forms.ComboBox comboBoxMADuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMASlopeDataPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSupportThreshold;
        private System.Windows.Forms.TextBox textBoxMaxFallThroughs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFallThroughPriceLimit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBoxEnableMovingAverage;
        private System.Windows.Forms.RadioButton radioButtonMorningStar;
        private System.Windows.Forms.RadioButton radioButtonBullishEngulfing;
        private System.Windows.Forms.CheckBox checkBoxCandlesticksEnable;
        private System.Windows.Forms.RadioButton radioButtonHammer;
        private System.Windows.Forms.RadioButton radioButtonEveningStar;
        private System.Windows.Forms.RadioButton radioButtonBearishEngulfing;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxROIDurations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxROIEnable;
        private System.Windows.Forms.RadioButton radioButtonLinearAverage;
        private System.Windows.Forms.RadioButton radioButtonSimpleAverage;
        private System.Windows.Forms.RadioButton radioButtonLogAverage;
    }
}