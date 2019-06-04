using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ResidentReq : RequestMethod
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

		public bool ShouldSerializeTypeSubject() => SubjectType.HasValue;

		[XmlElement("lastname")]
		public string LastName { get; set; }

		[XmlElement("firstname")]
		public string FirstName { get; set; }

		[XmlElement("born_lastname")]
		public string BornLastName { get; set; }

		[XmlElement("birthday")]
		public Date? Birthday { get; set; }

		public bool ShouldSerializeBirthday() => Birthday.HasValue;

		[XmlElement("birth_place")]
		public string BirtPlace { get; set; }

		[XmlElement("birth_district")]
		public string BirthDistrict { get; set; }

		[XmlElement("death_date")]
		public Date? DeathDate { get; set; }

		public bool ShouldSerializeDeathDate() => DeathDate.HasValue;

		[XmlElement("death_place")]
		public string DeathPlace { get; set; }

		[XmlElement("death_district")]
		public string DeathDistrict { get; set; }

		[XmlElement("birth_number")]
		public string BirthNumber { get; set; }

		[XmlElement("sex")]
		public Sex? Sex { get; set; }

		public bool ShouldSerializeSex() => Sex.HasValue;

		[XmlElement("marital_status")]
		public MaritalStatus? MaritalStatus { get; set; }

		public bool ShouldSerializeMaritalStatus() => MaritalStatus.HasValue;

		[XmlElement("marital_date")]
		public Date? MaritalDate { get; set; }

		public bool ShouldSerializeMaritalDate() => MaritalDate.HasValue;

		[XmlElement("title1")]
		public string Title1 { get; set; }

		[XmlElement("title2")]
		public string Title2 { get; set; }

		/// <summary>
		/// 1 - svéprávný, 2 - nesvéprávný, 3 - částečně
		/// </summary>
		[XmlElement("competence")]
		public int? Competence { get; set; }

		public bool ShouldSerializeCompetence() => Competence.HasValue;

		[XmlElement("nationality1")]
		public string Nationality1 { get; set; }

		[XmlElement("nationality2")]
		public string Nationality2 { get; set; }

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

		public ResidentReq()
		{
			ClassName = "vera-vr";
			Name = "obyvatel-hledej";
		}

		public override string ToString()
		{
			return $"BirthNumber=[{BirthNumber}],TypeSubject=[{SubjectType}]" + base.ToString();
		}
	}
}
