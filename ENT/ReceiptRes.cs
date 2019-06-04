using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ReceiptRes : ResponseMethod
	{
		[XmlArray("text_receipts")]
		[XmlArrayItem("text_receipt")]
		public string[] TextReceipts { get; set; } = new string[0];

		public override string ToString()
		{
			//return $"TextReceipt=[{string.Join(",", TextReceipts)}]," + base.ToString();
			return $"TextReceiptLength=[{TextReceipts?.Length}]," + base.ToString();
		}
	}
}
