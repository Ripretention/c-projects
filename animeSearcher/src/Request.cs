using System;

using System.Net;
using System.Net.Http;
using System.Web;
	
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Request
{
	public class RequestBody
	{
		private Dictionary<string, dynamic> reqParams = new Dictionary<string, dynamic>();

		public RequestBody() { }
		public RequestBody(Dictionary<string, dynamic> reqParams)
		{
			this.reqParams = reqParams;
			clearParamsOfReiteration();
		}
		private void clearParamsOfReiteration()
		{
			List<string> keys = new List<string>();
			foreach (KeyValuePair<string, dynamic> _param in reqParams)
			{
				if (!keys.Contains(_param.Key))
					keys.Add(_param.Key);
				else
					reqParams.Remove(_param.Key);
			}

			return;
		}

		public bool AddParam(string key, dynamic val)
		{
			if (ContainsParam(key)) return false;

			reqParams.Add(key, val);
			return true;
		}
		public bool ContainsParam(string key)
		{
			return reqParams.ContainsKey(key);
		}

		public string BodyInHTTPEncoding
		{
			get { return convertParamsToHTTP(); }
		}
		private string convertParamsToHTTP()
		{
			string paramInHTTPEconding = "";
			foreach (KeyValuePair<string, dynamic> reqParam in reqParams)
			{
				if (paramInHTTPEconding.Length == 0)
					paramInHTTPEconding += $"{reqParam.Key}={reqParam.Value}";
				else
					paramInHTTPEconding += $"&{reqParam.Key}={reqParam.Value}";
			}
			return paramInHTTPEconding;
		}
	}
	class Request 
	{	
		private static HttpClient client = new HttpClient();
		private static Dictionary<string, dynamic> convertJSONToDict(string json)
		{
			Dictionary<string, dynamic> convertedData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
			return convertedData;
		}
		
		public static async Task<Dictionary<string, dynamic>> getReq(string url)
		{
			HttpResponseMessage responseBody = await client.GetAsync(url);
			
			var jsonResult = responseBody.Content.ReadAsStringAsync().Result;
			Dictionary<string, dynamic> result = convertJSONToDict(jsonResult);
			
			return result;
		}
		
		public static async Task<Dictionary<string, dynamic>> postReq(string url, RequestBody bodyReq)
		{
			var content = new StringContent(bodyReq.BodyInHTTPEncoding, Encoding.UTF8, "application/x-www-form-urlencoded");
			HttpResponseMessage responseBody = await client.PostAsync(url, content);
			
			var jsonResult = responseBody.Content.ReadAsStringAsync().Result;
			Dictionary<string, dynamic> result = convertJSONToDict(jsonResult);

			return result;
		}
 	}
}
