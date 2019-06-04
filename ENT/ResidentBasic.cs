using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ResidentBasic
	{
		[XmlElement("id_subject")]
		public string IdSubject { get; set; }

		[XmlElement("subject_type")]
		public SubjectType SubjectType { get; set; }

		[XmlElement("lastname")]
		public string Lastname { get; set; }

		[XmlElement("firstname")]
		public string Firstname { get; set; }

		[XmlElement("middlename")]
		public string Middlename { get; set; }

		[XmlElement("born_lastname")]
		public string BornLastname { get; set; }

		[XmlElement("birthday")]
		public Date Birthday { get; set; }

		[XmlElement("birth_place")]
		public string BirthPlace { get; set; }

		[XmlElement("birth_district")]
		public string BirthDistrict { get; set; }

		public override string ToString()
		{
			return $"IdSubject=[{IdSubject}],Lastname=[{Lastname}],Firstname=[{Firstname}]";
		}
	}
}
