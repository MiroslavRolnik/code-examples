using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public abstract class VeraBase<T> where T : VeraMethod, new()
	{
		[XmlAttribute("id")]
		public int ID { get; set; }

		[XmlElement("class")]
		public VeraClass<T> VeraClass { get; set; } = new VeraClass<T>();

		public override string ToString()
		{
			return $"ID=[{ID}],{VeraClass}";
		}
	}
}
