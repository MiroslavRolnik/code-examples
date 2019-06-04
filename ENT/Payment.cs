using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class Payment
	{
		[XmlElement("id_payment")]
		/// <summary>
		/// identifikace poplatku
		/// </summary>
		public int IdPayment { get; set; }

		[XmlElement("text_payment")]
		/// <summary>
		/// popis poplatku
		/// </summary>
		public string TextPayment { get; set; }

		[XmlElement(ElementName ="amount",IsNullable =false)]
		/// <summary>
		/// částka k úhradě
		/// </summary>
		public string AmountString
		{
			get => Amount.ToString();
			set
			{
				decimal amount = 0;
				if (!string.IsNullOrEmpty(value))
					amount = Decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);

				Amount = amount;
			}
		}


		[XmlIgnore]
		public decimal Amount { get; set; }

		[XmlIgnore]
		public int Count { get; set; }

		[XmlIgnore]
		public decimal AmountToPay { get => Count * Amount; }

		[XmlIgnore]
		public Payment Entity { get => this; }

		public override string ToString()
		{
			return $"IdPayment=[{IdPayment}],TextPayment=[{TextPayment}],Amount=[{Amount}]";
		}
	}
}
