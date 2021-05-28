using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace NepseWatcher
{
    public partial class MainForm : Form
    {
        private bool searchingModeOn;
        private bool searchingModeOnScreened;

        WebDriverController webDriverController;
        ListViewColumnSorter lvwColumnSorter;
        ScreenerForm screenerForm;
        SectorsForm sectorsForm;
        Logger logger;

        private List<Company> companies; //list of all companies. source for the main list(Overview tab)
        private List<ListViewItem> screenedCompanies; //listViewItems of screened companies. source for the screened list(Screened tab)

        private BindingList<WatchListEntry> watchList; //list of watchlist entries. bound to the watchlist datagridview
        public MainForm()
        {
            InitializeComponent();
            InitializeMisc();
        }

        private void InitializeMisc()
        {
            lvwColumnSorter = new ListViewColumnSorter(); this.listViewScreened.ListViewItemSorter = lvwColumnSorter; //CP'd from https://docs.microsoft.com/en-US/troubleshoot/dotnet/csharp/sort-listview-by-column
            companies = new CompaniesInfo().CompanyList;

            logger = new Logger(textBoxLogs);
            screenerForm = new ScreenerForm();
            watchList = new BindingList<WatchListEntry>();

        }

        #region UI Event Handlers


        #region UI handlers for the main form

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateMainList(companies);
            dataGridViewWatchlist.DataSource = watchList;
            logger.Log($"{companies.Count} companies loaded!");
            SetStatusText($"{companies.Count} companies loaded");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webDriverController == null) return;
            webDriverController.Close();
        }
        private void screenerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            screenerForm.Show();
            screenerForm.CompanySymbolsList = GetCompanySymbolsFromListview();

            //remove any previous event handlers
            screenerForm.ScreeningProgressUpdated -= ScreenerForm_ScreeningProgressUpdated;
            screenerForm.ScreeningCompleted -= ScreenerClass_ScreeningCompleted;
            screenerForm.ScreeningStarted -= ScreenerForm_ScreeningStarted;
            screenerForm.ScreeningOperationReporter -= ScreenerForm_ScreeningOperationReporter;

            //attach event handlers
            screenerForm.ScreeningProgressUpdated += ScreenerForm_ScreeningProgressUpdated;
            screenerForm.ScreeningCompleted += ScreenerClass_ScreeningCompleted;
            screenerForm.ScreeningStarted += ScreenerForm_ScreeningStarted;
            screenerForm.ScreeningOperationReporter += ScreenerForm_ScreeningOperationReporter;
        }

        private void toolStripMenuItemShowLogs_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItemShowLogs.Checked)
                splitContainer1.Panel2Collapsed = false;
            else
                splitContainer1.Panel2Collapsed = true;
        }

        private void toolStripMenuItemClearLogs_Click(object sender, EventArgs e)
        {
            textBoxLogs.Text = "";
        }

        private void sectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sectorsForm == null)
            {
                sectorsForm = new SectorsForm();
            }
            sectorsForm.Show();

            sectorsForm.AllowedSectorsChanged -= SectorsForm_AllowedSectorsChanged; //remove any previous event handler
            sectorsForm.AllowedSectorsChanged += SectorsForm_AllowedSectorsChanged; //attach new event handler
        }

        private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the cache?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            screenerForm.ClearCache();

            if (HelperClass.DeleteCacheFile())
                MessageBox.Show("Cache cleared successfully!", "Cache", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cache could not be cleared!", "Cache", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NepseWatcher:\nAuthor: s0ft\nBlog: c0dew0rth.blogspot.com\nGitHub: globalpolicy\nEmail: yciloplabolg@gmail.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItemBrowser_Click(object sender, EventArgs e)
        {
            if (webDriverController == null || !webDriverController.IsBrowserOpen())
                webDriverController = new WebDriverController();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Select your watchlist file...";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var openedList = HelperClass.GetWatchListEntries(openFileDialog1.FileName);
                foreach (var entry in openedList)
                {
                    watchList.Add(entry);
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save your watchlist";
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HelperClass.SaveWatchListEntries(saveFileDialog1.FileName, watchList);
                    MessageBox.Show($"Watchlist saved to {saveFileDialog1.FileName} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving to file!\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region UI handlers for the Overview tab
        private void listViewSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webDriverController == null) return;
            if (listViewSymbols.SelectedItems.Count > 0) //this method is called even when selection is removed, so filter that case out
                webDriverController.LoadChartOfCompany(listViewSymbols.SelectedItems[0].Text);
        }

        private void textBoxFilterString_TextChanged(object sender, EventArgs e)
        {
            if (searchingModeOn)
            {
                List<Company> tmp = new List<Company>();
                foreach (Company company in companies)
                {
                    if (company.Symbol.ToLower().Contains(textBoxFilterString.Text.ToLower()) && (company.Sector == comboBoxSectors.Text || comboBoxSectors.Text == "All" || comboBoxSectors.Text == ""))
                        tmp.Add(company);
                }
                PopulateMainList(tmp);
            }
        }

        private void textBoxFilterString_Enter(object sender, EventArgs e)
        {
            if (!searchingModeOn)
            {
                searchingModeOn = true; //keep this line above the textBoxFilterString.Text="" line since changing the text will first execute the textBoxFilterString_TextChanged() handler
                textBoxFilterString.Text = ""; //remove the placeholder text
                textBoxFilterString.ForeColor = SystemColors.WindowText; //normal color font

            }

        }

        private void textBoxFilterString_Leave(object sender, EventArgs e)
        {
            if (textBoxFilterString.Text == "")
            {
                searchingModeOn = false; //keep this line above the textBoxFilterString.Text="" line since changing the text will first execute the textBoxFilterString_TextChanged() handler
                textBoxFilterString.Text = "Search"; //restore the placeholder text
                textBoxFilterString.ForeColor = SystemColors.WindowFrame; //gray color font

            }

        }

        private void comboBoxSectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Company> tmp = new List<Company>();
            foreach (Company company in companies)
            {
                if (company.Sector.Equals(comboBoxSectors.Text) || comboBoxSectors.Text == "All" || comboBoxSectors.Text == "")
                    tmp.Add(company);
            }
            var finalFilteredCompaniesList = ApplyGlobalSectorFilter(tmp); //uses info from SectorsForm(global sectorwise filter) to further filter the filtered list of companies
            PopulateMainList(finalFilteredCompaniesList);

        }

        private void listViewSymbols_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip3.Show(listViewSymbols, e.Location);
            }
        }

        private void toolStripMenuOverviewItemAddToWatchlist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewSymbols.SelectedItems.Count; i++)
            {
                ListViewItem itemSrc = listViewSymbols.SelectedItems[i];
                watchList.Add(new WatchListEntry() { Symbol = itemSrc.SubItems[0].Text, FullName = itemSrc.SubItems[1].Text, Sector = itemSrc.SubItems[2].Text });
            }
        }
        #endregion

        #region UI handlers for the Screened tab

        private void listViewScreened_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webDriverController == null) return;
            if (listViewScreened.SelectedItems.Count > 0) //this method is called even when selection is removed, so filter that case out
                webDriverController.LoadChartOfCompany(listViewScreened.SelectedItems[0].SubItems[0].Text);
        }

        private void textBoxFilterStringScreened_TextChanged(object sender, EventArgs e)
        {
            if (screenedCompanies == null) return;
            if (searchingModeOnScreened)
            {
                List<ListViewItem> tmp = new List<ListViewItem>();
                foreach (ListViewItem row in screenedCompanies)
                {
                    if (row.SubItems[0].Text.ToLower().Contains(textBoxFilterStringScreened.Text.ToLower()) && (row.SubItems[2].Text == comboBoxSectorsScreened.Text || comboBoxSectorsScreened.Text == "All" || comboBoxSectorsScreened.Text == ""))
                        tmp.Add(row);
                }
                listViewScreened.Items.Clear();
                listViewScreened.Items.AddRange(tmp.ToArray());

            }
        }

        private void textBoxFilterStringScreened_Enter(object sender, EventArgs e)
        {
            if (!searchingModeOnScreened)
            {
                searchingModeOnScreened = true; //keep this line above the textBoxFilterStringScreened.Text="" line since changing the text will first execute the textBoxFilterStringScreened_TextChanged() handler
                textBoxFilterStringScreened.Text = ""; //remove the placeholder text
                textBoxFilterStringScreened.ForeColor = SystemColors.WindowText; //normal color font

            }

        }

        private void textBoxFilterStringScreened_Leave(object sender, EventArgs e)
        {
            if (textBoxFilterStringScreened.Text == "")
            {
                searchingModeOnScreened = false; //keep this line above the textBoxFilterStringScreened.Text="" line since changing the text will first execute the textBoxFilterStringScreened_TextChanged() handler
                textBoxFilterStringScreened.Text = "Search"; //restore the placeholder text
                textBoxFilterStringScreened.ForeColor = SystemColors.WindowFrame; //gray color font

            }

        }

        private void comboBoxSectorsScreened_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (screenedCompanies == null) return;
            List<ListViewItem> tmp = new List<ListViewItem>();
            foreach (ListViewItem row in screenedCompanies)
            {
                if (row.SubItems[2].Text.Equals(comboBoxSectorsScreened.Text) || comboBoxSectorsScreened.Text == "All" || comboBoxSectorsScreened.Text == "")
                    tmp.Add(row);
            }
            listViewScreened.Items.Clear();
            listViewScreened.Items.AddRange(tmp.ToArray());
        }

        private void listViewScreened_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //CP'd from https://docs.microsoft.com/en-US/troubleshoot/dotnet/csharp/sort-listview-by-column

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewScreened.Sort();
        }



        //CP'd from: https://stackoverflow.com/questions/37841587/c-sharp-listview-how-to-handle-the-mouse-click-event-on-a-listviewitem
        private void listViewScreened_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < listViewScreened.Items.Count; i++)
                {
                    var rectangle = listViewScreened.GetItemRect(i);
                    if (rectangle.Contains(e.Location))
                    {
                        contextMenuStrip1.Show(listViewScreened, e.Location);
                        return;
                    }
                }
            }

        }

        private void toolStripMenuItemAddToWatchlist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewScreened.SelectedItems.Count; i++)
            {
                ListViewItem itemSrc = listViewScreened.SelectedItems[i];
                watchList.Add(new WatchListEntry() { Symbol = itemSrc.SubItems[0].Text, FullName = itemSrc.SubItems[1].Text, Sector = itemSrc.SubItems[2].Text });
            }
        }
        #endregion

        #region UI handlers for the Watchlist tab
        private void dataGridViewWatchlist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip2.Show(dataGridViewWatchlist, e.Location);
                if (dataGridViewWatchlist.Rows.Count == 0)
                {
                    toolStripMenuItemExportWatchlistTable.Enabled = false;
                    toolStripMenuItemCalculateWatchlist.Enabled = false;
                }
                    
                else
                {
                    toolStripMenuItemExportWatchlistTable.Enabled = true;
                    toolStripMenuItemCalculateWatchlist.Enabled = true;
                }
                    
            }
        }

        private void toolStripMenuItemCalculateWatchlist_Click(object sender, EventArgs e)
        {
            CalculateWatchlist();
        }

        private void toolStripMenuItemExportWatchlistTable_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Export table";
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            saveFileDialog1.FileName = "Report";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        List<string> columnNames = new List<string>();
                        foreach (DataGridViewColumn col in dataGridViewWatchlist.Columns)
                        {
                            columnNames.Add(col.HeaderText);
                        }
                        writer.WriteLine(string.Join(',', columnNames));

                        
                        foreach (DataGridViewRow row in dataGridViewWatchlist.Rows)
                        {
                            List<string> elementsOfRow = new List<string>();
                            foreach (DataGridViewTextBoxCell cell in row.Cells)
                            {
                                elementsOfRow.Add(cell.Value.ToString());
                            }
                            writer.WriteLine(string.Join(',', elementsOfRow));
                        }
                    }
                    MessageBox.Show($"Table successfully exported to {saveFileDialog1.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not export table!\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        #endregion

        #endregion





        #region Interclass Event Handlers
        private void ScreenerForm_ScreeningStarted(object src, ScreenerEventArgs eventArgs)
        {
            logger.Log("Screening process started");
        }


        //take items matching eventArgs.ScreenedCompanySymbolsList from listViewSymbols and populate listViewScreened
        private void ScreenerClass_ScreeningCompleted(object src, ScreenerEventArgs eventArgs)
        {
            Invoke(new Action(() =>
            {
                List<string> outputCompanyList;

                if (eventArgs.ScreenedCompanySymbolsList != null) //screening has also been done besides analysis
                {
                    outputCompanyList = eventArgs.ScreenedCompanySymbolsList;
                    logger.Log($"Screening process completed.\r\n{eventArgs.ScreenedCompanySymbolsList.Count} companies passed the screening.");
                }
                else //only analysis has been done. no screening
                {
                    outputCompanyList = eventArgs.CompanyAnalysisDict.Keys.ToList();
                    logger.Log($"Companies analysis complete.");
                }
                SetStatusText("Screening complete");


                //prepare a clean slate
                listViewScreened.Clear();
                listViewScreened.Columns.Add(new ColumnHeader() { Name = "Symbol", Text = "Symbol" });
                listViewScreened.Columns.Add(new ColumnHeader() { Name = "Name", Text = "Name" });
                listViewScreened.Columns.Add(new ColumnHeader() { Name = "Sector", Text = "Sector" });

                #region Populate the output(screened and/or analysed) companies into listview
                for (int i = 0; i < outputCompanyList.Count; i++)
                {
                    string company = outputCompanyList[i];
                    ListViewItem listViewItemSrc = listViewSymbols.FindItemWithText(company, false, 0, false);
                    string name = listViewItemSrc.SubItems[1].Text;
                    string sector = listViewItemSrc.SubItems[2].Text;

                    ListViewItem listViewItemDest = new ListViewItem(new string[] { company, name, sector });
                    listViewScreened.Items.Add(listViewItemDest);
                }
                #endregion

                #region Populate analysis results into listview
                if (eventArgs.CompanyAnalysisDict.Count > 0)
                {
                    #region Populate the moving average slopes into the listview
                    if (screenerForm.IsMovingAverageAnalysisEnabled())
                    {
                        //add a column for MA slope to the listview
                        listViewScreened.Columns.Add(new ColumnHeader() { Name = "MA Slope", Text = "MA Slope(MAS)" });

                        //update listview items with their MA slope values
                        foreach (ListViewItem row in listViewScreened.Items)
                        {
                            string companySymbol = (string)row.SubItems[0].Text; //company of this row

                            //if the company's analysis result is not available, continue to the next company
                            if (!eventArgs.CompanyAnalysisDict.ContainsKey(companySymbol))
                                continue;

                            string MAslope = eventArgs.CompanyAnalysisDict[companySymbol].MovingAverageSlope.ToString("F3");

                            row.SubItems.Add(MAslope);

                        }
                    }
                    #endregion

                    #region Populate the fallthroughs into the listview
                    if (screenerForm.IsFallthroughAnalysisEnabled())
                    {
                        //add a column for the no. of fallthroughs to the listview
                        listViewScreened.Columns.Add(new ColumnHeader() { Name = "Fallthroughs", Text = "Fallthroughs(FT)" });

                        //add a column for (moving avg slope)/(no. of fallthroughs) to the listview
                        listViewScreened.Columns.Add(new ColumnHeader() { Name = "MAslopeByFallthroughs", Text = "MAS/FT" });


                        //update listview items with their fallthrough values
                        foreach (ListViewItem row in listViewScreened.Items)
                        {
                            string companySymbol = (string)row.SubItems[0].Text; //company of this row

                            //if the company's analysis result is not available, continue to the next company
                            if (!eventArgs.CompanyAnalysisDict.ContainsKey(companySymbol))
                                continue;

                            int fallthroughs = eventArgs.CompanyAnalysisDict[companySymbol].NoOfFallthroughs;
                            string fallthroughsStr = fallthroughs.ToString();
                            row.SubItems.Add(fallthroughsStr);

                            float weightedSlope = eventArgs.CompanyAnalysisDict[companySymbol].MovingAverageSlope / fallthroughs;
                            string weightedSlopeStr = weightedSlope.ToString("F3");
                            row.SubItems.Add(weightedSlopeStr);

                        }
                    }
                    #endregion

                    #region Populate the screened listview with ROI analysis result
                    int[] durations;
                    if (screenerForm.IsROIAnalysisEnabled(out durations))
                    {

                        //add the durations as columns
                        foreach (var duration in durations)
                        {
                            listViewScreened.Columns.Add(new ColumnHeader() { Name = $"ROI{duration}", Text = $"ROI{duration}" });
                        }

                        //update ROI values for each ROI duration column
                        foreach (ListViewItem row in listViewScreened.Items)
                        {
                            string companySymbol = (string)row.SubItems[0].Text; //company of this row

                            //if the company's analysis result is not available, continue to the next company
                            if (!eventArgs.CompanyAnalysisDict.ContainsKey(companySymbol))
                                continue;

                            //array for the average ROI values of this company
                            string[] rois = new string[durations.Length];

                            for (int i = 0; i < durations.Length; i++)
                            {
                                int duration = durations[i];
                                rois[i] = eventArgs.CompanyAnalysisDict[companySymbol].AverageROIs[duration].ToString("F2");
                            }

                            row.SubItems.AddRange(rois);

                        }

                    }
                    #endregion
                }
                #endregion


                //update the comboBoxSectorsScreened according to the sectors the companies in listViewScreened belong to
                comboBoxSectorsScreened.Items.Clear();
                comboBoxSectorsScreened.Items.Add("All");
                screenedCompanies = new List<ListViewItem>(); //reset the screenedCompanies list
                foreach (ListViewItem row in listViewScreened.Items)
                {
                    screenedCompanies.Add(row); //add the screened company to the list
                    if (!comboBoxSectorsScreened.Items.Contains(row.SubItems[2].Text))
                        comboBoxSectorsScreened.Items.Add(row.SubItems[2].Text);
                }
                comboBoxSectorsScreened.SelectedItem = "All";


            }
            ));

        }

        private void ScreenerForm_ScreeningProgressUpdated(object src, ScreenerEventArgs eventArgs)
        {
            Invoke(new Action(() =>
            {
                SetStatusText($"Screening - {eventArgs.Progress}%");
                toolStripProgressBar1.Value = eventArgs.Progress;
            }));
        }

        private void ScreenerForm_ScreeningOperationReporter(object src, ScreenerEventArgs eventArgs)
        {
            Invoke(new Action(() =>
            {
                logger.Log(eventArgs.Message);
            }));
        }

        private void SectorsForm_AllowedSectorsChanged(object src, AllowedSectorsChangedEventArgs args)
        {
            comboBoxSectors.Items.Clear(); //remove existing options from the combobox
            comboBoxSectors.Items.AddRange(args.AllowedSectors.ToArray()); //add the allowed sectors to the combobox
            RemoveNonSectorCompaniesFromListView(); //remove any company outside of the sectors specified in the combobox
        }
        #endregion





        #region Miscellaneous methods
        private List<string> GetCompanySymbolsFromListview()
        {
            List<string> companySymbols = new List<string>();
            foreach (ListViewItem item in this.listViewSymbols.Items)
            {
                companySymbols.Add(item.SubItems[0].Text);
            }
            return companySymbols;
        }

        private void PopulateMainList(List<Company> filteredItems)
        {
            listViewSymbols.Items.Clear();
            listViewSymbols.Items.AddRange(filteredItems.Select(item => new ListViewItem(new string[] { item.Symbol, item.Fullname, item.Sector })).ToArray());

        }

        private void SetStatusText(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        /// <summary>
        /// Filters out elements of companies that are not in the sectors(except "All") present in the comboBoxSectors combobox. Its contents reflect that of the global sector filter as defined by the SectorsForm form.
        /// </summary>
        /// <param name="companies"></param>
        private List<Company> ApplyGlobalSectorFilter(List<Company> companies)
        {
            List<string> allowedSectors = new List<string>();
            foreach (var item in comboBoxSectors.Items)
                allowedSectors.Add(comboBoxSectors.GetItemText(item));

            List<Company> newList = new List<Company>();
            foreach (var company in companies)
            {
                if (allowedSectors.Contains(company.Sector))
                    newList.Add(company);
            }

            return newList;

        }

        /// <summary>
        /// Remove any company in the listview that doesn't exist in the sectors combobox
        /// </summary>
        private void RemoveNonSectorCompaniesFromListView()
        {
            List<string> allowedSectors = new List<string>();
            foreach (var item in comboBoxSectors.Items)
                allowedSectors.Add(comboBoxSectors.GetItemText(item));

            foreach (ListViewItem row in listViewSymbols.Items)
            {
                if (!allowedSectors.Contains(row.SubItems[2].Text))
                    row.Remove();
            }
        }


        private void CalculateWatchlist()
        {
            if (!dataGridViewWatchlist.Columns.Contains("investment"))
                dataGridViewWatchlist.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Investment", Name = "investment", ToolTipText = "Total money invested in buying this stock" });
            if (!dataGridViewWatchlist.Columns.Contains("last_closing_price"))
                dataGridViewWatchlist.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "LCP", Name = "last_closing_price", ToolTipText = "Last Closing Price i.e. the most recent closing price of this stock" });
            if (!dataGridViewWatchlist.Columns.Contains("current_worth"))
                dataGridViewWatchlist.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Current worth", Name = "current_worth", ToolTipText = "Amount receivable upon sale of this stock as of the last closing price" });
            if (!dataGridViewWatchlist.Columns.Contains("profit"))
                dataGridViewWatchlist.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Profit", Name = "profit" });
            if (!dataGridViewWatchlist.Columns.Contains("roi"))
                dataGridViewWatchlist.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ROI", Name = "roi", ToolTipText = "Return On Investment" });

            double totalInvestment = 0, totalCurrentValue = 0, totalProfit = 0, averageROI = 0;
            int totalQuantity = 0;
            foreach (DataGridViewRow row in dataGridViewWatchlist.Rows)
            {
                string company = (string)row.Cells["Symbol"].Value;
                string entryDateStr = row.Cells["EntryDate"].Value.ToString();
                string entryPriceStr = row.Cells["EntryPrice"].Value.ToString();
                string quantityStr = row.Cells["Quantity"].Value.ToString();
                if (quantityStr == "0" || entryPriceStr == "0") return; //these being zero mean the entry has just been added, hence the user has not been able to input the entryDate, entryPrice and quantity to the table
                try
                {
                    DateTime entryDate = DateTime.Parse(entryDateStr);
                    double entryPrice = double.Parse(entryPriceStr);
                    int quantity = int.Parse(quantityStr);
                    double currentPrice = HelperClass.GetLastClosingPrice(company); // == LCP i.e. Last Closing Price

                    dynamic shareCalculationResult = HelperClass.CalculatePricesWithDeductibles(quantity, entryPrice, currentPrice);
                    double costAmount = shareCalculationResult.TotalCostOfSharesWhileBuying; // == investment
                    double receivableAmount = shareCalculationResult.TotalReceivableAmtAfterSale; // == resale value
                    double profit = shareCalculationResult.TotalProfit; // == profit
                    double roi = profit / costAmount * 100; // == roi

                    row.Cells["last_closing_price"].Value = currentPrice.ToString("F2");
                    row.Cells["investment"].Value = costAmount.ToString("F2");
                    row.Cells["current_worth"].Value = receivableAmount.ToString("F2");
                    row.Cells["profit"].Value = profit.ToString("F2");
                    row.Cells["roi"].Value = roi.ToString("F2") + " %";

                    totalInvestment += costAmount;
                    totalCurrentValue += receivableAmount;
                    totalProfit += profit;
                    averageROI += roi / dataGridViewWatchlist.Rows.Count;
                    totalQuantity += quantity;
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }
            SetStatusText($"Total investment: {totalInvestment.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}, Current worth: {totalCurrentValue.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}, Total profit: {totalProfit.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}, Mean ROI: {averageROI.ToString("F2")} %, Total shares: {totalQuantity}");
            logger.WriteLine("-----");
            logger.WriteLine($"Total investment: {totalInvestment.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}");
            logger.WriteLine($"Current worth: {totalCurrentValue.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}");
            logger.WriteLine($"Total profit: {totalProfit.ToString("C", CultureInfo.CreateSpecificCulture("np-NP"))}");
            logger.WriteLine($"Mean ROI: {averageROI.ToString("F2")} %");
            logger.WriteLine($"Total shares: {totalQuantity}");
            logger.WriteLine("-----");
        }


        #endregion


    }



}
