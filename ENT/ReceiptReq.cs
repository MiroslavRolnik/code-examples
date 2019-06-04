using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ReceiptReq : RequestMethod
	{
		[XmlElement("id_cash")]
		/// <summary>
		/// označení pokladny
		/// </summary>
		public int IdCash { get; set; }

		[XmlElement("name_cash")]
		/// <summary>
		/// typ transakce
		/// </summary>
		public string NameCash { get; set; }

		[XmlElement("type_transaction")]
		/// <summary>
		/// typ transakce 
		/// </summary>
		public TypeTransaction TypeTransaction { get; set; }

		[XmlElement("type_receipt")]
		/// <summary>
		/// typ dokladu 
		/// </summary>
		public TypeReceipt TypeReceipt { get; set; }

		[XmlElement("payment_date")]
		/// <summary>
		/// datum úhrady 
		/// </summary>
		public Date PaymentDate { get; set; }

		[XmlElement("number_pos")]
		/// <summary>
		/// číslo terminálu POS
		/// </summary>
		public string NumberPos { get; set; }

		[XmlElement("type_card")]
		/// <summary>
		/// typ platební karty 
		/// </summary>
		public string TypeCard { get; set; }

		[XmlElement("number_card")]
		/// <summary>
		/// číslo platební karty 
		/// </summary>
		public string NumberCard { get; set; }

		[XmlElement("auth_code")]
		/// <summary>
		/// autorizační kód 
		/// </summary>
		public string AuthCode { get; set; }

		[XmlArray("items")]
		[XmlArrayItem("item")]
		public ReceiptPayment[] ReceiptPayments { get; set; }

		public ReceiptReq()
		{
			ClassName = "vera-kp";
			Name = "doklad-uloz-automat";
		}

		public override string ToString()
		{
			return $"IdCash=[{IdCash}],NameCash=[{NameCash}],TypeTransaction=[{TypeTransaction}],TypeReceipt=[{TypeReceipt}],PaymentDate=[{PaymentDate}],NumberPos=[{NumberPos}],TypeCard=[{TypeCard}],NumberCard=[{NumberCard}],AuthCode=[{AuthCode}],ReceiptPayments=[{string.Join(",", ReceiptPayments?.Select(x => $"[{x.ToString()}]"))}]," + base.ToString();
		}
	}	
}
