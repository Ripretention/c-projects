using System;
using System.Collections.Generic;

namespace AnimeSearcher
{
	partial class SearchResultForm
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
            this.searchImage = new System.Windows.Forms.PictureBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.animeResults = new System.Windows.Forms.ListBox();
            this.openAnimeButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchImage)).BeginInit();
            this.SuspendLayout();
            // 
            // searchImage
            // 
            this.searchImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchImage.Location = new System.Drawing.Point(354, 9);
            this.searchImage.Name = "searchImage";
            this.searchImage.Size = new System.Drawing.Size(79, 79);
            this.searchImage.TabIndex = 0;
            this.searchImage.TabStop = false;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(354, 160);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(79, 27);
            this.copyButton.TabIndex = 1;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // animeResults
            // 
            this.animeResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.animeResults.FormattingEnabled = true;
            this.animeResults.HorizontalScrollbar = true;
            this.animeResults.ItemHeight = 24;
            this.animeResults.Location = new System.Drawing.Point(12, 9);
            this.animeResults.Name = "animeResults";
            this.animeResults.Size = new System.Drawing.Size(336, 292);
            this.animeResults.TabIndex = 2;
            // 
            // openAnimeButton
            // 
            this.openAnimeButton.Location = new System.Drawing.Point(354, 127);
            this.openAnimeButton.Name = "openAnimeButton";
            this.openAnimeButton.Size = new System.Drawing.Size(79, 27);
            this.openAnimeButton.TabIndex = 3;
            this.openAnimeButton.Text = "Open Anime";
            this.openAnimeButton.UseVisualStyleBackColor = true;
            this.openAnimeButton.Click += new System.EventHandler(this.openAnimeButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(354, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 27);
            this.button3.TabIndex = 4;
            this.button3.Text = "Open Image";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(354, 193);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(79, 27);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SearchResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(439, 324);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.openAnimeButton);
            this.Controls.Add(this.animeResults);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.searchImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchResultForm";
            this.Text = "Anime Title Searcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchResultFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.searchImage)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button copyButton;
		private System.Windows.Forms.PictureBox searchImage;
        private System.Windows.Forms.ListBox animeResults;
        private System.Windows.Forms.Button openAnimeButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button backButton;
    }
}