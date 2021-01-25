using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace search
{
	public class Request
	{
		static WebClient client = new WebClient();
		
		public static string GetHTML(string url) {
			return client.DownloadString(url);
		}
	}
	
	class HTMLParseVending
	{
		private const int ITEMS_IN_ONE_PAGE = 20;
		private const string VENDING_PAGE_URL = "https://www.shining-moon.com/?module=vending&action=items";
		private VendingItems vendingItems = new VendingItems();
		
		public delegate void AddVendingItemsHandler(VendingItems items);
		public event AddVendingItemsHandler AddVendingItems;
		public int TotalCountItems { get; private set; }
		private int vendingPagesCount = 0;

		private HtmlParser parser = new HtmlParser();
		public HTMLParseVending() 
		{
			vendingPagesCount = getVendingPagesCount();
			TotalCountItems = vendingPagesCount * ITEMS_IN_ONE_PAGE;
		}

		private int getVendingPagesCount()
        {
			IDocument vendingPage = parser.ParseDocument(Request.GetHTML(getPageByNumber(1)));
			string vendingPagesCountElement = vendingPage.QuerySelector(".info-text").Text();
			int vendingPagesCount = Convert.ToInt32(new Regex(@"(\d+) page").Match(vendingPagesCountElement).Groups[1].Value);

			return vendingPagesCount;
		}

		private string getPageByNumber(int number)
        {
			return $"{VENDING_PAGE_URL}&p={number}";
		}
		public void StartParse()
		{
			for (int i = 0; i < vendingPagesCount; i++)
			{
				IDocument doc = parser.ParseDocument(Request.GetHTML(getPageByNumber(i)));
				new Thread(() => HTMLParseVendingItems(doc)).Start();
			}
		}
		
		private void HTMLParseVendingItems(IDocument HTMLDoc)
		{
			var items = HTMLDoc.QuerySelector(".vertical-table").Children[1];
			
			for (int i = 0; i < items.Children.Length; i++)
			{
				vendingItems.AddItem(createVendingItem(items.Children[i]));
				if (AddVendingItems != null) AddVendingItems.Invoke(vendingItems);
			}
		}
		private VendingItem createVendingItem(IElement item)
		{
			VendingItem vendingItem = new VendingItem();
			
			vendingItem.Name = (string)item.Children[3].TextContent.Trim();
			vendingItem.Shop = (string)item.Children[0].TextContent.Trim();
			vendingItem.Position = (string)item.Children[2].TextContent.Trim();
			vendingItem.Offer = (string)item.Children[8].TextContent.Trim();
			
			vendingItem.Card0 = (string)item.Children[4].TextContent.Trim();
			vendingItem.Card1 =	(string)item.Children[5].TextContent.Trim();
			vendingItem.Card2 =	(string)item.Children[6].TextContent.Trim();
			vendingItem.Card3 =	(string)item.Children[7].TextContent.Trim();
			
			return vendingItem;
		}
		
		public List<VendingItem> GetVendingItems
		{
			get { return vendingItems.Items; }
		}
	}
	
	public class VendingItems
	{
		public delegate void AddItemHandler(VendingItem item);
		public event AddItemHandler AddItemEvent;
		
		public List<VendingItem> Items = new List<VendingItem>();
		public VendingItems() {}
		
		public void AddItem(VendingItem item)
		{
			Items.Add(item);
			if (AddItemEvent != null) AddItemEvent.Invoke(item);
		}
	}
	
	public class VendingItem
	{
		public string Name { get; set; }
		public string Shop { get; set; }
		public string Offer { get; set; }
		public string Position { get; set; }	
		public string Card0 { get; set; }
		public string Card1 { get; set; }
		public string Card2 { get; set; }
		public string Card3 { get; set; }
		
		public VendingItem() {}
	}
}

