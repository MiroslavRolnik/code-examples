using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class PaymentRes : ResponseMethod
	{
		[XmlArray("payments")]
		[XmlArrayItem("payment")]
		/// <summary>
		/// seznam poplatků
		/// </summary>
		public Payment[] Payments { get; set; } = new Payment[0];

		public override string ToString()
		{
			return $"Payments=[{string.Join(",", Payments.Select(x => $"[{x.ToString()}]"))}]," + base.ToString();
		}
	}
}
