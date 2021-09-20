using Newtonsoft.Json.Linq;
using System.Globalization;

namespace OpenWeatherAPI
{
	public partial class Main
	{
		public TemperatureObj Temperature { get; }

		public double Pressure { get; }

		public double Humdity { get; }

		public double SeaLevelAtm { get; }

		public double GroundLevelAtm { get; }

		public Main(JToken mainData)
		{
			if (mainData is null)
				throw new System.ArgumentNullException(nameof(mainData));

			Temperature = new TemperatureObj(
								double.Parse(mainData.SelectToken("temp").ToString()),
								double.Parse(mainData.SelectToken("temp_min").ToString()),
								double.Parse(mainData.SelectToken("temp_max").ToString())
								);

			Pressure = double.Parse(mainData.SelectToken("pressure").ToString());
			Humdity = double.Parse(mainData.SelectToken("humidity").ToString());
			if (mainData.SelectToken("sea_level") != null)
				SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level").ToString());
			if (mainData.SelectToken("grnd_level") != null)
				GroundLevelAtm = double.Parse(mainData.SelectToken("grnd_level").ToString());
		}
	}
}
