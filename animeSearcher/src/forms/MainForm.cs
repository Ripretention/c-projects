using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnimeSearcher
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		async void startSearchTitleByAnimeImg(Image imgIn)
		{
			Cursor = System.Windows.Forms.Cursors.AppStarting;
			startLoadAnimation();

			animeSearch.AnimeSearcher searchRes = new animeSearch.AnimeSearcher(imgIn);
			List<animeSearch.AnimeResult> aRL = await searchRes.Search();

			Cursor = System.Windows.Forms.Cursors.Arrow;
			stopLoadAnimation();

			this.Hide();
			SearchResultForm searchResultForm = new SearchResultForm(aRL, imgIn, this);
			searchResultForm.Show();	
		}
	}
}
