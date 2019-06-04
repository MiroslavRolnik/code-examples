using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public class Authorization
	{
		[XmlIgnore]
		public string UserDomain { get; set; } = "EXSYS";

		[XmlIgnore]
		public string UserName { get; set; } = "user";

		[XmlElement("id_user")]
		public string IdUser
		{
			get
			{
				return $"{UserDomain}:{UserName}";
			}
			set
			{
				string[] values = value?.Split(':');
				if (values?.Length == 2)
				{
					UserDomain = values[0];
					UserName = values[1];
				}
			}
		}

		public override string ToString()
		{
			return $"UserDomain=[{UserDomain}],UserName=[{UserName}]";
		}
	}
}
