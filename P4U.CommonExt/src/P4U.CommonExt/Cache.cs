using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.CommonExt
{
	public class Cache<T> where T: ICacheElement
	{
		private static Dictionary<string, T> _ObjectList = new Dictionary<string, T>();

		public static T GetForCode(string code)
		{
			if (string.IsNullOrEmpty(code))
			{
				throw new ArgumentNullException();
			}

			T retval = default(T);

			if (_ObjectList.ContainsKey(code))
			{
				retval = _ObjectList[code];
			}

			return retval;
		}

		public static T GetForID(int id)
		{
			if (id<=0)
			{
				throw new ArgumentOutOfRangeException("ID has to be positive!");
			}

			T retval = default(T);

			foreach (var kvp in _ObjectList)
			{
				if (kvp.Value.ID == id)
				{
					retval = kvp.Value;
					break;
				}
			}

			return retval;
		}

		public static void AddObject(T obj)
		{
			if (_ObjectList.ContainsKey(obj.Code))
			{
				_ObjectList[obj.Code] = obj;
			}
			else
			{
				_ObjectList.Add(obj.Code, obj);
			}
		}

		public static IEnumerable<T> GetObjects()
		{
			foreach (var kvp in _ObjectList)
			{
				yield return kvp.Value;
			}
		}

	}

	public interface ICacheElement
	{
		string Code { get; }
		int ID { get; }
	}
}
