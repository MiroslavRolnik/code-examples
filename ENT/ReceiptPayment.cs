using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ReceiptPayment
	{
		[XmlElement("id_payer")]
		/// <summary>
		/// identifikace plátce 
		/// </summary>
		public int? IdPayer { get; set; }

		[XmlElement("id_payment")]
		/// <summary>
		/// identifikace poplatku
		/// </summary>
		public int? IdPayment { get; set; }

		[XmlElement("quantity")]
		/// <summary>
		/// množství
		/// </summary>
		public int Quantity { get; set; }

		[XmlElement("amount")]
		/// <summary>
		/// částka
		/// </summary>
		public decimal Amount { get; set; }

		public bool ShouldSerializeIdPayer() => IdPayer.HasValue;

		public bool ShouldSerializeIdPayment() => IdPayment.HasValue;

		public override string ToString()
		{
			return $"IdPayer=[{IdPayer}],IdPayment=[{IdPayment}],Quantity=[{Quantity}],Amount=[{Amount}]";
		}
	}
}
