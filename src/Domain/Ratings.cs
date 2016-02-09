using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Nancy.Simple
{
	[XmlRoot("FireDangerMap")]
	public class Ratings
	{
		[XmlElement("District")]
		[JsonProperty("districts")]
		public List<District> Districts {
			get;
			set;
		}

		[XmlIgnore]
		[JsonProperty("updated_at")]
		public DateTime Updated {
			get;
			set;
		}
	}
}

