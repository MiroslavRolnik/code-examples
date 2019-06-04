using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ResidentOthers
	{
		[XmlElement("birth_number")]
		public string BirthNumber { get; set; }

		[XmlElement("sex")]
		public Sex Sex { get; set; }

		[XmlElement("marital_status")]
		public MaritalStatus MaritalStatus { get; set; }

		[XmlElement("marital_date")]
		public Date MaritalDate { get; set; }

		[XmlElement("title1")]
		public string Title1 { get; set; }

		[XmlElement("title2")]
		public string Title2 { get; set; }

		[XmlElement("competence")]
		public int Competence { get; set; }

		[XmlElement("nationality1")]
		public string Nationality1 { get; set; }

		[XmlElement("nationality2")]
		public string Nationality2 { get; set; }

		public override string ToString()
		{
			return $"BirthNumber=[{BirthNumber}]";
		}
	}
}
