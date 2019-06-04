using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public abstract class VeraMethod
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlIgnore]
		public string ClassName { get; set; }

		public override string ToString()
		{
			return $"MethodName=[{Name}]";
		}
	}
}
