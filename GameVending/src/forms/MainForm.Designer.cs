using System;
using System.Windows.Forms;

namespace ShiningMoonVending
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGridView();
            this.loadedItemsScore = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterByLabel = new System.Windows.Forms.Label();
            this.filterBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.desiredItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchTextBox.Location = new System.Drawing.Point(12, 52);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(582, 38);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.FilterVendingItems);
            // 
            // dataGrid1
            // 
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.Location = new System.Drawing.Point(12, 96);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.RowTemplate.Height = 40;
            this.dataGrid1.ShowEditingIcon = false;
            this.dataGrid1.Size = new System.Drawing.Size(657, 354);
            this.dataGrid1.TabIndex = 1;
            // 
            // loadedItemsScore
            // 
            this.loadedItemsScore.AutoSize = true;
            this.loadedItemsScore.Location = new System.Drawing.Point(9, 36);
            this.loadedItemsScore.Name = "loadedItemsScore";
            this.loadedItemsScore.Size = new System.Drawing.Size(66, 13);
            this.loadedItemsScore.TabIndex = 3;
            this.loadedItemsScore.Text = "Loaded: 0/0";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Shining Moon Vending";
            this.notifyIcon.BalloonTipTitle = "Program minimized";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Shining Moon Vending";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // filterByLabel
            // 
            this.filterByLabel.AutoSize = true;
            this.filterByLabel.Location = new System.Drawing.Point(597, 51);
            this.filterByLabel.Name = "filterByLabel";
            this.filterByLabel.Size = new System.Drawing.Size(47, 13);
            this.filterByLabel.TabIndex = 5;
            this.filterByLabel.Text = "Filter By:";
            // 
            // filterBox
            // 
            this.filterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterBox.FormattingEnabled = true;
            this.filterBox.Items.AddRange(new object[] {
            "Name",
            "Shop"});
            this.filterBox.Location = new System.Drawing.Point(600, 67);
            this.filterBox.Name = "filterBox";
            this.filterBox.Size = new System.Drawing.Size(69, 21);
            this.filterBox.TabIndex = 6;
            this.filterBox.SelectedIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desiredItemsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // desiredItemsToolStripMenuItem
            // 
            this.desiredItemsToolStripMenuItem.Name = "desiredItemsToolStripMenuItem";
            this.desiredItemsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.desiredItemsToolStripMenuItem.Text = "Desired items";
            this.desiredItemsToolStripMenuItem.Click += new System.EventHandler(this.desiredItemsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(681, 462);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.loadedItemsScore);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.filterByLabel);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.SearchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Shining Moon Vending";
            this.FormClosing += new FormClosingEventHandler(this.MainFormClose);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Label loadedItemsScore;
		private System.Windows.Forms.DataGridView dataGrid1;
		private System.Windows.Forms.TextBox SearchTextBox;
		
		private void NotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			notifyIcon.Visible = false;
		}
		
		private void MainFormClose(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
                e.Cancel = true;
                this.Hide();
				notifyIcon.Visible = true;
				notifyIcon.ShowBalloonTip(1000);
                return;
			}
            this.Close();
		}
		
		private void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Show();		
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}

        private void desiredItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ShiningMoonVending.DesiredItemSystem(ref diseredItemsList).Show();
        }

        private Label filterByLabel;
        private ComboBox filterBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem desiredItemsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
