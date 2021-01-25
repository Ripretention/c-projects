using System;
using System.Xml;
using System.Linq;
using System.Text.RegularExpressions;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

using search;

namespace ShiningMoonVending
{
	public partial class MainForm : Form
	{
		private List<VendingItem> VendingItemList = new List<VendingItem>();
		private List<string> diseredItemsList = new List<string>();
		private int totalCountItems;

		public MainForm()
		{
			InitializeComponent();
			loadDesiredItems();
			
			start();
			startAutoUpdateVendingList(18e5);
		}

		void start()
        {
			HTMLParseVending HTMLParse = new HTMLParseVending();
			HTMLParse.AddVendingItems += UpdateVendingItems;
			totalCountItems = HTMLParse.TotalCountItems;

			new Thread(() => StartParsingItems(HTMLParse)).Start();
		}
		void startAutoUpdateVendingList(double interval)
        {
			System.Timers.Timer autoUpdateIntervalTimer = new System.Timers.Timer(interval);
			autoUpdateIntervalTimer.AutoReset = true;
			autoUpdateIntervalTimer.Elapsed += new System.Timers.ElapsedEventHandler((Object source, System.Timers.ElapsedEventArgs e) => { start(); });
			autoUpdateIntervalTimer.Enabled = true;
			return;
		}

		void loadDesiredItems()
		{
			XMLConfigWorker XMLConfig = new XMLConfigWorker();
			XmlDocument XMLConfigDoc = XMLConfig.GetXMLConfig();

			foreach (XmlNode XMLConfigDocNode in XMLConfigDoc.DocumentElement)
				if (XMLConfigDocNode.LocalName == "diseredItems")
					foreach (XmlNode XMLConfigDocChildNode in XMLConfigDocNode.ChildNodes)
						diseredItemsList.Add(Convert.ToString(XMLConfigDocChildNode.InnerText).Trim());
		}

		void UpdateVendingItems(VendingItems items)
		{
			VendingItemList = items.Items;
			
			loadedItemsScore.Invoke(new Action(() => loadedItemsScore.Text = $"Loaded: {items.Items.Count}/{totalCountItems}"));
			dataGrid1.Invoke(new Action(() => dataGrid1.DataSource = VendingItemList));
		}
		
		void StartParsingItems(HTMLParseVending HTMLParse)
		{
			HTMLParse.StartParse();
			VendingItemList = HTMLParse.GetVendingItems;
			checkOnDesiredItems(VendingItemList);
		}
		void checkOnDesiredItems(List<VendingItem> items)
		{
			foreach (VendingItem item in items.ToArray())
				if (diseredItemsContainsItem(item.Name.Trim()))
					MessageBox.Show($"<{item.Name.Trim()}> item is on sale with a price of {item.Offer} in the store <{item.Shop}>");
		}
		bool diseredItemsContainsItem(string itemName)
        {
			return (diseredItemsList.Where((x) => new Regex(x, RegexOptions.IgnoreCase).IsMatch(itemName)).Count() > 0);
		}

		void FilterVendingItems(object sender, EventArgs e) 
		{
			Regex filterRegex = new Regex((SearchTextBox.Text.Length == 0) ? ".*" : String.Format("{0}", SearchTextBox.Text), RegexOptions.IgnoreCase);

			var filteredItems = VendingItemList.Where(i => filterRegex.IsMatch(FilteredParam(i)) == true).ToList();

			loadedItemsScore.Text = $"Loaded: {filteredItems.Count}/{totalCountItems}";
			dataGrid1.DataSource = filteredItems;
		}
		string FilteredParam(VendingItem item)
        {
			string filterBy = filterBox.SelectedItem.ToString();
			if (filterBy == "Name" || filterBy == "")
				filterBy = item.Name;
			else if (filterBy == "Shop")
				filterBy = item.Shop;

			return filterBy;
		}
    }
}
