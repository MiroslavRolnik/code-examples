using System;
using System.Collections.Generic;
using System.Text;


namespace P4U.CommonExt
{
	public class Language: Cache<Language>, ICacheElement
	{
		#region Constructor

		public Language(int id, string code, string name, string nameCZ, string cultureInfoCode)
		{
			ID = id;
			Code = code;
			Name = name;
			NameCZ = nameCZ;
			CultureInfoCode = cultureInfoCode;
		}

		#endregion

		#region Properties
		public int ID { get; private set; }
		public string Code { get; private set; }
		public string Name { get; private set; }
		public string NameCZ { get; private set; }
		public string CultureInfoCode { get; private set; }

		#endregion

	}
}
