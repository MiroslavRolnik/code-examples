using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class ResidentSubject
	{
		[XmlElement("basic")]
		public ResidentBasic Basic { get; set; }

		[XmlElement("death")]
		public ResidentDeath Death { get; set; }

		[XmlElement("others")]
		public ResidentOthers Others { get; set; }

		[XmlElement("residence")]
		public SubjectResidence Residence { get; set; }

		public override string ToString()
		{
			return $"Basic[{Basic}],Death=[{Death}],Others=[{Others}],Residence=[{Residence}]";
		}
	}
}
