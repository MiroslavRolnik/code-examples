using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	[XmlRoot("request")]
	public class VeraRequest<T> : VeraBase<T> where T : RequestMethod, new()
	{
		private static Random _Random = new Random();

		[XmlElement("authorization")]
		public Authorization Authorization { get; set; } = new Authorization();

		[XmlIgnore]
		public T Request => VeraClass.VeraMethod;

		public string Serialize()
		{
			return ClassFunction.Serialize(this);
		}

		public VeraRequest() : base()
		{ }

		public VeraRequest(T requestMethod) : this()
		{
			VeraClass.VeraMethod = requestMethod;
			VeraClass.Name = requestMethod.ClassName;

			ID = _Random.Next();
		}

		public override string ToString()
		{
			return $"{Authorization},{base.ToString()}";
		}
	}
}
