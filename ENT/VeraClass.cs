using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class VeraClass<T> where T : VeraMethod, new()
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("version")]
		public string Version { get; set; } = "1.0";

		[XmlAttribute("revision")]
		public string Revision { get; set; } = "1";

		[XmlElement("method")]
		public T VeraMethod { get; set; } = new T();

		public override string ToString()
		{
			return $"ClassName=[{Name}],Version=[{Version}],Revision=[{Revision}],{VeraMethod}";
		}
	}
}
