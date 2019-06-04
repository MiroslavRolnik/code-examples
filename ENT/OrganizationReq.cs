using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class OrganizationReq : RequestMethod
	{
		/// <summary>
		/// ID pokladny, povinné pokud není vyplněno [NameCash]
		/// </summary>
		[XmlElement("id_subject")]
		public int? IdSubject { get; set; }

		public bool ShouldSerializeIdSubject() => IdSubject.HasValue;

		/// <summary>
		/// označení pokladny, povinné pokud není vyplněno [IdCash]
		/// </summary>
		[XmlElement("subject_type")]
		public SubjectType? SubjectType { get; set; }

		public bool ShouldSerializeSubjectType() => SubjectType.HasValue;

		[XmlElement("name")]
		public string OrganizationName { get; set; }
			   		 
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

		[XmlElement("id_residence")]
		public string IdResidence { get; set; }

		[XmlElement("city")]
		public string City { get; set; }

		[XmlElement("district")]
		public string District { get; set; }

		[XmlElement("state")]
		public string State { get; set; }

		[XmlElement("city_part")]
		public string CityPart { get; set; }
			   
		[XmlElement("house_number")]
		public string HouseNumber { get; set; }

		/// <summary>
		///1 - popisné číslo, 2 - evidenční číslo, 3 - náhradní číslo 
		/// </summary>
		[XmlElement("number_type")]
		public int? NumberType { get; set; }

		public bool ShouldSerializeNumberType() => NumberType.HasValue;

		[XmlElement("street_name")]
		public string StreetName { get; set; }

		[XmlElement("number_add")]
		public string NumberAdd { get; set; }

		[XmlElement("postcode")]
		public string Postcode { get; set; }

		public OrganizationReq()
		{
			ClassName = "vera-vr";
			Name = "organizace-hledej";
		}

		public override string ToString()
		{
			return $"CompanyId=[{CompanyId}]" + base.ToString();
		}
	}
}
