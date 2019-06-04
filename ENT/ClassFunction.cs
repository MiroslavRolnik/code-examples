using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FSD.PayAut.Business.WS.ENT
{
	public static class ClassFunction
	{
		public static string ToString(object obj)
		{
			Type type = obj.GetType();

			StringBuilder result = new StringBuilder();
			bool isFirst = true;
			foreach (var propertyInfo in type.GetProperties())
			{
				if (!isFirst)
					result.Append(",");

				if (propertyInfo.PropertyType.IsArray)
				{
					StringBuilder arrStr = new StringBuilder();
					Array arr = (Array)propertyInfo.GetValue(obj);
					for (int i = 0; i < arr.Length; i++)
					{
						if (i > 0)
							arrStr.Append(",");
						arrStr.Append(arr.GetValue(i).ToString());
					}

					result.Append($"{propertyInfo.Name}=[{arrStr.ToString()}]");
				}
				else
				{
					result.Append($"{propertyInfo.Name}=[{propertyInfo.GetValue(obj)}]");
				}

				isFirst = false;
			}

			return result.ToString();
		}

		public static string Serialize(object obj)
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());

			string xmlString = null;

			using (StringWriter writer = new Utf8StringWriter())
			{
				serializer.Serialize(writer, obj);

				xmlString = writer.ToString();
			}

			return xmlString;
		}

		public static T Deserialize<T>(string xmlString)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			T obj = default(T);

			using (StringReader reader = new StringReader(xmlString))
			{
				obj = (T)serializer.Deserialize(reader);
			}
			
			return obj;
		}


		public class Utf8StringWriter : StringWriter
		{
			public override Encoding Encoding => Encoding.UTF8;
		}


		#region requestDocument


		#endregion


		#region responseDocument


		#endregion
	}
}
