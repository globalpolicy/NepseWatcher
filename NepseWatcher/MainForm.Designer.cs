
namespace NepseWatcher
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listViewSymbols = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.textBoxFilterString = new System.Windows.Forms.TextBox();
            this.comboBoxSectors = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.screenerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemShowLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClearLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panelFirstTabPage = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelSecondTabPage = new System.Windows.Forms.Panel();
            this.textBoxFilterStringScreened = new System.Windows.Forms.TextBox();
            this.comboBoxSectorsScreened = new System.Windows.Forms.ComboBox();
            this.listViewScreened = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewWatchlist = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddToWatchlist = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCalculateWatchlist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportWatchlistTable = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuOverviewItemAddToWatchlist = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelFirstTabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelSecondTabPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWatchlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSymbols
            // 
            this.listViewSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSymbols.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewSymbols.FullRowSelect = true;
            this.listViewSymbols.HideSelection = false;
            this.listViewSymbols.Location = new System.Drawing.Point(9, 39);
            this.listViewSymbols.MultiSelect = false;
            this.listViewSymbols.Name = "listViewSymbols";
            this.listViewSymbols.Size = new System.Drawing.Size(415, 125);
            this.listViewSymbols.TabIndex = 0;
            this.listViewSymbols.UseCompatibleStateImageBehavior = false;
            this.listViewSymbols.View = System.Windows.Forms.View.Details;
            this.listViewSymbols.SelectedIndexChanged += new System.EventHandler(this.listViewSymbols_SelectedIndexChanged);
            this.listViewSymbols.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSymbols_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Symbol";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sector";
            this.columnHeader3.Width = 100;
            // 
            // textBoxFilterString
            // 
            this.textBoxFilterString.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxFilterString.Location = new System.Drawing.Point(9, 11);
            this.textBoxFilterString.Name = "textBoxFilterString";
            this.textBoxFilterString.Size = new System.Drawing.Size(160, 23);
            this.textBoxFilterString.TabIndex = 1;
            this.textBoxFilterString.Text = "Search";
            this.textBoxFilterString.TextChanged += new System.EventHandler(this.textBoxFilterString_TextChanged);
            this.textBoxFilterString.Enter += new System.EventHandler(this.textBoxFilterString_Enter);
            this.textBoxFilterString.Leave += new System.EventHandler(this.textBoxFilterString_Leave);
            // 
            // comboBoxSectors
            // 
            this.comboBoxSectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSectors.FormattingEnabled = true;
            this.comboBoxSectors.Items.AddRange(new object[] {
            "All",
            "Hydro Power",
            "Commercial Banks",
            "Finance",
            "Tradings",
            "Microfinance",
            "Development Banks",
            "Insurance",
            "Non Life Insurance",
            "Manufacturing and Processing",
            "Hotels",
            "Mutual Fund",
            "Corporate Debenture",
            "Promotor Share",
            "Others"});
            this.comboBoxSectors.Location = new System.Drawing.Point(174, 11);
            this.comboBoxSectors.Name = "comboBoxSectors";
            this.comboBoxSectors.Size = new System.Drawing.Size(249, 23);
            this.comboBoxSectors.TabIndex = 2;
            this.comboBoxSectors.SelectedIndexChanged += new System.EventHandler(this.comboBoxSectors_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(443, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemOpen.Text = "&Open";
            this.toolStripMenuItemOpen.ToolTipText = "Open watchlist file";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AutoToolTip = true;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ToolTipText = "Save the watchlist to a CSV file";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectorsToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearCacheToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // sectorsToolStripMenuItem
            // 
            this.sectorsToolStripMenuItem.Name = "sectorsToolStripMenuItem";
            this.sectorsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.sectorsToolStripMenuItem.Text = "Sectors";
            this.sectorsToolStripMenuItem.ToolTipText = "Select which sectors should be loaded";
            this.sectorsToolStripMenuItem.Click += new System.EventHandler(this.sectorsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(132, 6);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBrowser,
            this.screenerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolStripMenuItemBrowser
            // 
            this.toolStripMenuItemBrowser.Name = "toolStripMenuItemBrowser";
            this.toolStripMenuItemBrowser.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItemBrowser.Text = "Browser";
            this.toolStripMenuItemBrowser.Click += new System.EventHandler(this.toolStripMenuItemBrowser_Click);
            // 
            // screenerToolStripMenuItem
            // 
            this.screenerToolStripMenuItem.Name = "screenerToolStripMenuItem";
            this.screenerToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.screenerToolStripMenuItem.Text = "Screener";
            this.screenerToolStripMenuItem.Click += new System.EventHandler(this.screenerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowLogs,
            this.toolStripMenuItemClearLogs});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            // 
            // toolStripMenuItemShowLogs
            // 
            this.toolStripMenuItemShowLogs.Checked = true;
            this.toolStripMenuItemShowLogs.CheckOnClick = true;
            this.toolStripMenuItemShowLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemShowLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemShowLogs.Name = "toolStripMenuItemShowLogs";
            this.toolStripMenuItemShowLogs.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItemShowLogs.Text = "Show log";
            this.toolStripMenuItemShowLogs.CheckedChanged += new System.EventHandler(this.toolStripMenuItemShowLogs_CheckedChanged);
            // 
            // toolStripMenuItemClearLogs
            // 
            this.toolStripMenuItemClearLogs.Name = "toolStripMenuItemClearLogs";
            this.toolStripMenuItemClearLogs.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItemClearLogs.Text = "Clear log";
            this.toolStripMenuItemClearLogs.Click += new System.EventHandler(this.toolStripMenuItemClearLogs_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(271, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // panelFirstTabPage
            // 
            this.panelFirstTabPage.Controls.Add(this.listViewSymbols);
            this.panelFirstTabPage.Controls.Add(this.textBoxFilterString);
            this.panelFirstTabPage.Controls.Add(this.comboBoxSectors);
            this.panelFirstTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFirstTabPage.Location = new System.Drawing.Point(3, 3);
            this.panelFirstTabPage.Name = "panelFirstTabPage";
            this.panelFirstTabPage.Size = new System.Drawing.Size(429, 170);
            this.panelFirstTabPage.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 204);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelFirstTabPage);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(435, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelSecondTabPage);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(435, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Screened";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelSecondTabPage
            // 
            this.panelSecondTabPage.Controls.Add(this.textBoxFilterStringScreened);
            this.panelSecondTabPage.Controls.Add(this.comboBoxSectorsScreened);
            this.panelSecondTabPage.Controls.Add(this.listViewScreened);
            this.panelSecondTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecondTabPage.Location = new System.Drawing.Point(3, 3);
            this.panelSecondTabPage.Name = "panelSecondTabPage";
            this.panelSecondTabPage.Size = new System.Drawing.Size(429, 170);
            this.panelSecondTabPage.TabIndex = 0;
            // 
            // textBoxFilterStringScreened
            // 
            this.textBoxFilterStringScreened.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxFilterStringScreened.Location = new System.Drawing.Point(9, 11);
            this.textBoxFilterStringScreened.Name = "textBoxFilterStringScreened";
            this.textBoxFilterStringScreened.Size = new System.Drawing.Size(159, 23);
            this.textBoxFilterStringScreened.TabIndex = 4;
            this.textBoxFilterStringScreened.Text = "Search";
            this.textBoxFilterStringScreened.TextChanged += new System.EventHandler(this.textBoxFilterStringScreened_TextChanged);
            this.textBoxFilterStringScreened.Enter += new System.EventHandler(this.textBoxFilterStringScreened_Enter);
            this.textBoxFilterStringScreened.Leave += new System.EventHandler(this.textBoxFilterStringScreened_Leave);
            // 
            // comboBoxSectorsScreened
            // 
            this.comboBoxSectorsScreened.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSectorsScreened.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSectorsScreened.FormattingEnabled = true;
            this.comboBoxSectorsScreened.Location = new System.Drawing.Point(174, 11);
            this.comboBoxSectorsScreened.Name = "comboBoxSectorsScreened";
            this.comboBoxSectorsScreened.Size = new System.Drawing.Size(249, 23);
            this.comboBoxSectorsScreened.TabIndex = 3;
            this.comboBoxSectorsScreened.SelectedIndexChanged += new System.EventHandler(this.comboBoxSectorsScreened_SelectedIndexChanged);
            // 
            // listViewScreened
            // 
            this.listViewScreened.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewScreened.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewScreened.FullRowSelect = true;
            this.listViewScreened.HideSelection = false;
            this.listViewScreened.Location = new System.Drawing.Point(9, 39);
            this.listViewScreened.MultiSelect = false;
            this.listViewScreened.Name = "listViewScreened";
            this.listViewScreened.Size = new System.Drawing.Size(415, 125);
            this.listViewScreened.TabIndex = 1;
            this.listViewScreened.UseCompatibleStateImageBehavior = false;
            this.listViewScreened.View = System.Windows.Forms.View.Details;
            this.listViewScreened.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewScreened_ColumnClick);
            this.listViewScreened.SelectedIndexChanged += new System.EventHandler(this.listViewScreened_SelectedIndexChanged);
            this.listViewScreened.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewScreened_MouseClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Symbol";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Sector";
            this.columnHeader6.Width = 100;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewWatchlist);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(435, 176);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Watchlist";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWatchlist
            // 
            this.dataGridViewWatchlist.AllowUserToAddRows = false;
            this.dataGridViewWatchlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWatchlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWatchlist.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWatchlist.Name = "dataGridViewWatchlist";
            this.dataGridViewWatchlist.RowTemplate.Height = 25;
            this.dataGridViewWatchlist.Size = new System.Drawing.Size(429, 170);
            this.dataGridViewWatchlist.TabIndex = 0;
            this.dataGridViewWatchlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewWatchlist_MouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxLogs);
            this.splitContainer1.Size = new System.Drawing.Size(443, 395);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 7;
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(443, 183);
            this.textBoxLogs.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddToWatchlist});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuItemAddToWatchlist
            // 
            this.toolStripMenuItemAddToWatchlist.Name = "toolStripMenuItemAddToWatchlist";
            this.toolStripMenuItemAddToWatchlist.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItemAddToWatchlist.Text = "Add to watchlist";
            this.toolStripMenuItemAddToWatchlist.Click += new System.EventHandler(this.toolStripMenuItemAddToWatchlist_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCalculateWatchlist,
            this.toolStripMenuItemExportWatchlistTable});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(138, 48);
            // 
            // toolStripMenuItemCalculateWatchlist
            // 
            this.toolStripMenuItemCalculateWatchlist.Name = "toolStripMenuItemCalculateWatchlist";
            this.toolStripMenuItemCalculateWatchlist.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItemCalculateWatchlist.Text = "Calculate";
            this.toolStripMenuItemCalculateWatchlist.Click += new System.EventHandler(this.toolStripMenuItemCalculateWatchlist_Click);
            // 
            // toolStripMenuItemExportWatchlistTable
            // 
            this.toolStripMenuItemExportWatchlistTable.Name = "toolStripMenuItemExportWatchlistTable";
            this.toolStripMenuItemExportWatchlistTable.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItemExportWatchlistTable.Text = "Export table";
            this.toolStripMenuItemExportWatchlistTable.ToolTipText = "Export the watchlist table including the calculations to a CSV";
            this.toolStripMenuItemExportWatchlistTable.Click += new System.EventHandler(this.toolStripMenuItemExportWatchlistTable_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuOverviewItemAddToWatchlist});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuOverviewItemAddToWatchlist
            // 
            this.toolStripMenuOverviewItemAddToWatchlist.Name = "toolStripMenuOverviewItemAddToWatchlist";
            this.toolStripMenuOverviewItemAddToWatchlist.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuOverviewItemAddToWatchlist.Text = "Add to watchlist";
            this.toolStripMenuOverviewItemAddToWatchlist.Click += new System.EventHandler(this.toolStripMenuOverviewItemAddToWatchlist_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "NepseWatcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelFirstTabPage.ResumeLayout(false);
            this.panelFirstTabPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelSecondTabPage.ResumeLayout(false);
            this.panelSecondTabPage.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWatchlist)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewSymbols;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox textBoxFilterString;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox comboBoxSectors;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel panelFirstTabPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panelSecondTabPage;
        private System.Windows.Forms.ListView listViewScreened;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowLogs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearLogs;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox textBoxFilterStringScreened;
        private System.Windows.Forms.ComboBox comboBoxSectorsScreened;
        private System.Windows.Forms.TextBox Fil;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToWatchlist;
        private System.Windows.Forms.DataGridView dataGridViewWatchlist;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCalculateWatchlist;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBrowser;
        private System.Windows.Forms.ToolStripMenuItem screenerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOverviewItemAddToWatchlist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportWatchlistTable;
    }
}

