using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	[XmlRoot("response")]
	public class VeraResponse<T> : VeraBase<T> where T : ResponseMethod, new()
	{
		[XmlIgnore]
		public T Response => VeraClass.VeraMethod;

		public static VeraResponse<T> Deserialize(string xmlString)
		{
			return ClassFunction.Deserialize<VeraResponse<T>>(xmlString);
		}
	}
}
