using System;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nancy.Simple.CachingExtensions;

namespace Nancy.Simple
{
	public class HealthModule : NancyModule
	{
		public HealthModule()
		{
			Get ["/api/ping"] = args => {
				return new Response
				{
					ContentType = "application/json",
					Contents = s => s.Write(Encoding.Default.GetBytes("OK"), 0, "OK".Length)
				};
			};
		}
	}
}
