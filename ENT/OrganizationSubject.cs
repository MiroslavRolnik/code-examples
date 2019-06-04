using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class OrganizationSubject
	{
		[XmlElement("basic")]
		public OrganizationBasic Basic { get; set; }

		[XmlElement("residence")]
		public SubjectResidence Residence { get; set; }

		public override string ToString()
		{
			return $"Basic[{Basic}],Residence=[{Residence}]";
		}
	}
}
