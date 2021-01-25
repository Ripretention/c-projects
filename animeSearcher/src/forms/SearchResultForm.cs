using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AnimeSearcher
{	
	public partial class SearchResultForm : Form
	{
		private MainForm mainForm;
		private List<animeSearch.AnimeResult> animeSearchResults;
		public SearchResultForm(List<animeSearch.AnimeResult> animeSearchResults, System.Drawing.Image imgSearched, MainForm mainForm)
		{
			InitializeComponent();

			searchImage.Image = utils.Img.resizeImage(imgSearched, new System.Drawing.Size(79, 79));

			animeResults.Items.AddRange(animeSearchResults.Select((animeResult) => animeResult.Title).ToArray());

			this.animeSearchResults = animeSearchResults;
			this.mainForm = mainForm;
		}
		
        private void backButton_Click(object sender, EventArgs e)
        {
			mainForm.Show();
			this.Close();
		}
		private void SearchResultFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (!mainForm.Visible) this.mainForm.Close();
		}

        private void copyButton_Click(object sender, EventArgs e)
        {
			string selectedItem = animeResults?.SelectedItem?.ToString() ?? String.Empty;
			if (selectedItem == String.Empty) return;
			Clipboard.SetText(selectedItem);
		}

        private void openAnimeButton_Click(object sender, EventArgs e)
        {
			string selectedItem = animeResults?.SelectedItem?.ToString() ?? String.Empty;
			if (selectedItem == String.Empty) return;

			string URLOnAnimeDataBase = animeSearchResults.Where((animeResult) => animeResult.URLOnAnimeDataBase != string.Empty && animeResult.Title == selectedItem).Select((animeResult) => animeResult.URLOnAnimeDataBase).ToArray()[0] ?? string.Empty;
			if (URLOnAnimeDataBase == string.Empty) return;
			System.Diagnostics.Process.Start(URLOnAnimeDataBase);
		}
	}
}