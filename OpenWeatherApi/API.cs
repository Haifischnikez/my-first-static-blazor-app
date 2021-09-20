namespace OpenWeatherAPI
{
	public class API
	{
		private string openWeatherAPIKey;

		public API(string key)
		{
			openWeatherAPIKey =  key;
		}

		public void UpdateAPIKey(string key)
		{
			openWeatherAPIKey = key;
		}

		//Returns null if invalid request
		public Query Query(string queryStr)
		{
			Query newQuery = new Query(openWeatherAPIKey, queryStr);
			if (newQuery.ValidRequest)
				return newQuery;
			return null;
		}
	}
}
