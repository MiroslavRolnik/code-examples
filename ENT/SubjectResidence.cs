using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class SubjectResidence
	{
		[XmlElement("id_residence")]
		public int IdResidence { get; set; }

		[XmlElement("subject_type")]
		public SubjectType SubjectType { get; set; }

		[XmlElement("city")]
		public string City { get; set; }

		[XmlElement("city_part")]
		public string CityPart { get; set; }

		[XmlElement("district")]
		public string District { get; set; }

		[XmlElement("state")]
		public string State { get; set; }

		[XmlElement("house_number")]
		public int HouseNumber { get; set; }

		[XmlElement("number_type")]
		public string NumberType { get; set; }

		[XmlElement("street_name")]
		public string StreetName { get; set; }

		[XmlElement("number_add")]
		public string NumberAdd { get; set; }

		[XmlElement("post_code")]
		public string Postcode { get; set; }

		public override string ToString()
		{
			return $"IdResidence=[{IdResidence}]";
		}
	}
}
