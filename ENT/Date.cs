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
	public struct Date : IEquatable<Date>, IEquatable<DateTime>, IXmlSerializable
	{
		private DateTime _DateTime;

		public override string ToString()
		{
			return _DateTime.ToString("yyyy-MM-dd");
		}

		public bool Equals(Date other)
		{
			return _DateTime.Equals(other._DateTime);
		}

		public bool Equals(DateTime other)
		{
			return _DateTime.Equals(other);
		}

		public static implicit operator DateTime(Date date)
		{
			return date._DateTime;
		}
		public static explicit operator Date(DateTime dateTime)
		{
			return new Date(dateTime);
		}

		public Date(DateTime dateTime)
		{
			_DateTime = dateTime;
		}


		#region IXmlSerializable

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			string nilValue = reader["nil", "http://www.w3.org/2001/XMLSchema-instance"];

			string elementValue = reader.IsEmptyElement ? null : reader.ReadElementString();

			_DateTime = (elementValue != null) ? XmlConvert.ToDateTime(elementValue, "yyyy-MM-dd") : new DateTime();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteString(XmlConvert.ToString(_DateTime, "yyyy-MM-dd"));
		}

		#endregion

	}
}
