using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public abstract class ResponseMethod : VeraMethod
	{
		[XmlElement("status")]
		/// <summary>
		/// status, 0 - OK, menší než 0 - Chyba, 100 - nenalezen záznam  
		/// </summary>
		public int Status { get; set; }

		[XmlElement("error_msg")]
		public string ErrorMsg { get; set; }

		[XmlIgnore]
		public bool IsOk => Status == 0;

		public override string ToString()
		{
			return $"Status=[{Status}],ErrorMsg=[{ErrorMsg}]," + base.ToString();
		}
	}
}
