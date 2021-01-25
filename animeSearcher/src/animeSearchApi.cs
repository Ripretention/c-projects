using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;

namespace animeSearch
{	
	public class AnimeResult
    {
		public string Title { get; private set; }
		public string URLOnAnimeDataBase { get; private set; }
		public string URLOnAnimeImage { get; private set; }

		public AnimeResult(string title, string URLOnAnimeDataBase, string URLOnAnimeImage) 
		{
			Title = title;
			this.URLOnAnimeDataBase = URLOnAnimeDataBase;
			this.URLOnAnimeImage = URLOnAnimeImage;
		}
    }
	
	class AnimeSearcher
	{
		private const string API_URL = "https://saucenao.com/search.php?db=999&output_type=2&testmode=0&numres=16&api_key=";
		private List<AnimeResult> searchAnimeResult = new List<AnimeResult>();
		private HttpClient client = new HttpClient();
		private byte[] searchingAnimeImage;

		public AnimeSearcher(System.Drawing.Image searchingImg)
        {
			searchingAnimeImage = utils.Img.ImageToByteArray(searchingImg);
		}

		public async Task<List<AnimeResult>> Search()
        {
			await fillSearchAnimeResultList();
			return searchAnimeResult;
		}
		
		private async Task fillSearchAnimeResultList()
        {
			List<JObject> animeSearchResult = await getFilteredResultsOfAnimeSerachRequest();
			
			foreach (JObject animeResult in animeSearchResult)
            {
				string animeResultTitle = ((string)(animeResult?["data"]?["source"] ?? string.Empty)).Trim();
				
				bool isDuplicate = (searchAnimeResult.Where((animeRes) => animeRes.Title == animeResultTitle).Count() > 0);
				bool isNotValidTitle = (animeResultTitle == string.Empty);
				if (isDuplicate || isNotValidTitle) continue;
                
				searchAnimeResult.Add(new AnimeResult(
					animeResultTitle,
					((string)(animeResult?["data"]?["ext_urls"]?[0] ?? string.Empty)).Trim(),
					((string)(animeResult?["header"]?["thumbnail"] ?? string.Empty)).Trim()
				));
			}

			return;
		}
		private async Task<List<JObject>> getFilteredResultsOfAnimeSerachRequest()
        {
			JObject searchResult = await requestOnAnimeSearchService();

			List<JObject> resultsCount = searchResult["results"].Select((result) => (JObject)result).Where((result) => result["data"]["source"] != null).ToList();
			return resultsCount;
		}
		private async Task<JObject> requestOnAnimeSearchService()
        {
			MultipartFormDataContent form = new MultipartFormDataContent();
			form.Add(new ByteArrayContent(searchingAnimeImage, 0, searchingAnimeImage.Length), "file", "image.png");
			HttpResponseMessage responseBody = await client.PostAsync(API_URL, form);

			if ((int)responseBody.StatusCode > 400)
				MessageBox.Show($"Error Request \n Code: {responseBody.StatusCode} \n Message: {responseBody.ReasonPhrase}");

			return JsonConvert.DeserializeObject<JObject>(responseBody.Content.ReadAsStringAsync().Result);
		}
	}
	
	class AnimeSearchResultSort
	{
		private JObject animeSearchRes;
		private bool isRelevantRes;
		
		public AnimeSearchResultSort(JObject animeSerachResult) 
		{
			this.animeSearchRes = animeSerachResult;
			this.isRelevantRes = this.isResultHaveAnime();
		}
		
		public Dictionary<string, dynamic>[] getResultsInDictionaryArray()
		{
			JArray arrayOfResults = (JArray)this.animeSearchRes["results"];
			Dictionary<string, dynamic>[] convertedResultsInDictionaryArray = new Dictionary<string, dynamic>[arrayOfResults.Count];
			
			for (int i = 0; i < arrayOfResults.Count; i++)
			{
				convertedResultsInDictionaryArray[i] = this.convertResultInDictionary((JObject)arrayOfResults[i]);
			}
			var filteredConvertedResultsInDictionaryArray = convertedResultsInDictionaryArray.GroupBy((result) => result["title"]).Select((groupItems) => groupItems.First()).ToArray();
			
			return filteredConvertedResultsInDictionaryArray;
		}
		private Dictionary<string, dynamic> convertResultInDictionary(JObject searchResult)
		{
			Dictionary<string, dynamic> convertedResult = new Dictionary<string, dynamic>();
			
			if (searchResult["data"]["source"] == null) return convertedResult;
			convertedResult["title"] = ((string)searchResult["data"]["source"]).Trim();
			convertedResult["url"] = (searchResult["data"]["ext_urls"] != null) ? (string)searchResult["data"]["ext_urls"][0] : "";
			
			return convertedResult;
		}
		
		public bool isResultHaveAnime()
		{
			if ((int)this.animeSearchRes["header"]["status"] < 0) return false;
			this.deleteResultsWithNoAnimeTitles();
			int lngResArray = (int)((JArray)this.animeSearchRes["results"]).Count;
			
			return (lngResArray > 0);
		}
		private void deleteResultsWithNoAnimeTitles()
		{
			JArray animeResArray = (JArray)this.animeSearchRes["results"];
			
			for (int i = 0; i < animeResArray.Count; i++)
			{
				if (animeResArray[i]["data"]["source"] == null)
				{
					animeResArray.Remove(animeResArray[i]);
				}
			}
			
			return;
		}
	}
}