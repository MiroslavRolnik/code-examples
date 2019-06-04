using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class OrganizationBasic
	{
		[XmlElement("id_subject")]
		public string IdSubject { get; set; }

		[XmlElement("subject_type")]
		public SubjectType SubjectType { get; set; }

		[XmlElement("name")]
		public string Name { get; set; }

		[XmlElement("official_name")]
		public string OfficialName { get; set; }

		[XmlElement("company_id")]
		public string CompanyId { get; set; }

		[XmlElement("tax_reference_number")]
		public string TaxReferenceNumber { get; set; }

		[XmlElement("sector")]
		public string Sector { get; set; }

		[XmlElement("legal_form")]
		public string LegalForm { get; set; }

		public override string ToString()
		{
			return $"IdSubject=[{IdSubject}],Name=[{Name}],OfficialName=[{OfficialName}]";
		}
	}
}
