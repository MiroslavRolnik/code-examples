using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class OrganizationRes : ResponseMethod
	{
		[XmlArray("subjects")]
		[XmlArrayItem("subject")]
		public OrganizationSubject[] Subjects { get; set; }

		public override string ToString()
		{
			return $"Subjects=[{string.Join<OrganizationSubject>(",", Subjects)}]," + base.ToString();
		}
	}
}
