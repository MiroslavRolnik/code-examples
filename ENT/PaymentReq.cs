using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class PaymentReq : RequestMethod
	{
		[XmlElement("id_cash")]
		/// <summary>
		/// ID pokladny, povinné pokud není vyplněno [NameCash]
		/// </summary>
		public int IdCash { get; set; }

		[XmlElement("name_cash")]
		/// <summary>
		/// označení pokladny, povinné pokud není vyplněno [IdCash]
		/// </summary>
		public string NameCash { get; set; }

		public PaymentReq()
		{
			ClassName = "vera-kp";
			Name = "poplatek-sezn-automat";
		}

		public override string ToString()
		{
			return $"IdCash=[{IdCash}],NameCash=[{NameCash}]," + base.ToString();
		}
	}
}
