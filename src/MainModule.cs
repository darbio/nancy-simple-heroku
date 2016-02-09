using System;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nancy.Simple.CachingExtensions;

namespace Nancy.Simple
{
	public class MainModule : NancyModule
	{
		public MainModule()
		{
			Get ["/api/ping"] = args => {
				return new Response
				{
					ContentType = "application/json",
					Contents = s => s.Write(Encoding.Default.GetBytes("OK"), 0, "OK".Length)
				};
			};

            Get["/api/v1/ratings"] = args => {
				try {
	                // Get the FDR Toban file
					var request = HttpWebRequest.Create(new Uri("http://www.rfs.nsw.gov.au/feeds/fdrToban.xml"));

					var response = request.GetResponse();
					var stream = response.GetResponseStream();
					 
	                // Deserialize from XML
					var serializer = new XmlSerializer(typeof(Ratings));
					var ratings = serializer.Deserialize(stream) as Ratings;
					ratings.Updated = DateTime.UtcNow;

	                // Serialize to JSON
					var jsonRatings = JsonConvert.SerializeObject(ratings);
	                
					// Cache
					this.Context.EnableOutputCache(30);

	                // Return
					var jsonBytes = Encoding.UTF8.GetBytes(jsonRatings);
	                return new Response
	                {
	                    ContentType = "application/json",
	                    Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length)
					};
				}
				catch (Exception ex){
					Console.WriteLine(ex.ToString());
					return new Response
					{
						ContentType = "application/json",
						Contents = s => s.Write(Encoding.Default.GetBytes(ex.ToString()), 0, ex.ToString().Length)
					};
				}
			};
		}
	}
}
