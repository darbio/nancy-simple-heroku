using System;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Nancy.Simple.CachingExtensions;

namespace Nancy.Simple
{
	public class ExampleModule : NancyModule
	{
		public ExampleModule()
		{
			Get ["/api/v1/example"] = args => {
				return new Response
				{
					ContentType = "application/json",
					Contents = s => s.Write(Encoding.Default.GetBytes("OK"), 0, "OK".Length)
				};
			};
		}
	}
}
