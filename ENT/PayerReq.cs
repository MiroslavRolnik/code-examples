using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	/// <summary>
	/// Povinný alespoň jeden z parametrů - VS nebo kombinace ID subjektu+registru subjektu.
	/// V případě vyplněného VS se parametry ID subjektu+registru subjektu ignorují.
	/// </summary>
	public class PayerReq : RequestMethod
	{
		[XmlElement("variable_symbol")]
		/// <summary>
		/// variabilní symbol
		/// </summary>		
		public string VariableSymbol { get; set; }

		[XmlElement("type_subject")]
		/// <summary>
		/// identifikace registru subjektu
		/// </summary>
		public TypeSubject TypeSubject { get; set; }

		[XmlElement("id_subject")]
		/// <summary>
		/// identifikace subjektu RČ / IČO
		/// </summary>
		public string IdSubject { get; set; }

		public override string ToString()
		{
			return $"VariableSymbol=[{VariableSymbol}],TypeSubject=[{TypeSubject}],IdSubject=[{IdSubject}]," + base.ToString();
		}

		public PayerReq()
		{
			Name = "platce-sezn-automat";
			ClassName = "vera-pd";
		}
	}
}
