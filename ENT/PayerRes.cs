using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class PayerRes : ResponseMethod
	{
		[XmlElement("name_payer")]
		/// <summary>
		/// název plátce
		/// </summary>
		public string NamePayer { get; set; }

		[XmlArray("payers")]
		[XmlArrayItem("payer")]
		/// <summary>
		/// plátci
		/// </summary>
		public Payer[] Payers { get; set; } = new Payer[0];

		public override string ToString()
		{
			return $"NamePayer=[{NamePayer}],Payers=[{string.Join(",", Payers.Select(x => $"[{x.ToString()}]"))}]," + base.ToString();
		}
	}
}
