using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	/// <summary>
	/// vlací platbu přiřazenou plátci
	/// </summary>
	public class Payer
	{
		[XmlElement("id_payer")]
		/// <summary>
		/// identifikace plátce 
		/// </summary>
		public int IdPayer { get; set; }

		[XmlElement("variable_symbol")]
		/// <summary>
		/// variabilní symbol 
		/// </summary>
		public string VariableSymbol { get; set; }

		[XmlElement("text_payment")]
		/// <summary>
		/// popis úhrady
		/// </summary>
		public string TextPayment { get; set; }


		private decimal _Amount;
		[XmlElement("amount")]
		/// <summary>
		/// částka k úhradě  
		/// </summary>
		public decimal Amount
		{
			get
			{
				return _Amount;
			}
			set
			{
				_Amount = value;
				AmountToPay = value;
			}
		}

		[XmlIgnore]
		public decimal AmountToPay { get; set; }

		[XmlIgnore]
		public bool IsToPay { get; set; } = true;

		[XmlIgnore]
		public Payer Entity { get => this; }

		public override string ToString()
		{
			return $"IdPayer=[{IdPayer}],VariableSymbol=[{VariableSymbol}],TextPayment=[{TextPayment}],Amount=[{Amount}]";
		}
	}
}
