using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;

namespace Nancy.Simple
{
	public class District
	{
		[XmlElement("RegionNumber")]
		[JsonProperty("region_id")]
		public int RegionNumber {
			get;
			set;
		}

		[XmlElement("Name")]
		[JsonProperty("name")]
		public string x_Name {
			get;
			set;
		}

		[XmlElement("Councils")]
		[JsonIgnore]
		public string x_Councils {
			get;
			set;
		}

		[XmlIgnore]
		[JsonProperty("councils")]
		public List<string> Councils {
			get{
				if (!string.IsNullOrEmpty(x_Councils))
				{
					return this.x_Councils.Split (';').Select (a => a.Trim ()).ToList ();
				}
				return new List<string> ();
			}
		}

		[XmlElement("DangerLevelToday")]
		[JsonProperty("fdr_today")]
		public string FDRToday {
			get;
			set;
		}

		[XmlElement("DangerLevelTomorrow")]
		[JsonProperty("fdr_tomorrow")]
		public string FDRTomorrow {
			get;
			set;
		}

		[XmlElement("FireBanToday")]
		[JsonIgnore]
		public string FireBanToday {
			get;
			set;
		}

		[XmlIgnore]
		[JsonProperty("is_toban_today")]
		public bool IsFireBanToday {
			get {
				return this.FireBanToday.ToLowerInvariant () == "yes";
			}
		}

		[XmlElement("FireBanTomorrow")]
		[JsonIgnore]
		public string FireBanTomorrow {
			get;
			set;
		}

		[XmlIgnore]
		[JsonProperty("is_toban_tomorrow")]
		public bool IsFireBanTomorrow {
			get {
				return this.FireBanTomorrow.ToLowerInvariant () == "yes";
			}
		}
	}
}

