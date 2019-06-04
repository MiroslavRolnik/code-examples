using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ResidentDeath
	{
		[XmlElement("death_date")]
		public Date DeathDate { get; set; }

		[XmlElement("death_place")]
		public string DeathPlace { get; set; }

		[XmlElement("death_district")]
		public string DeathDistrict { get; set; }

		public override string ToString()
		{
			return $"DeathDate=[{DeathDate}]";
		}
	}
}
