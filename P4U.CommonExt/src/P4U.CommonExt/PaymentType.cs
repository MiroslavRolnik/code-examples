using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4U.CommonExt
{
	public class PaymentType: Cache<PaymentType>, ICacheElement
	{
		#region Public Variables

		public static PaymentType Cash
		{
			get
			{
				return PaymentType.GetForCode("cash");
			}
		}

		public static PaymentType Card
		{
			get
			{
				return PaymentType.GetForCode("card");
			}
		}

		public static PaymentType Credit
		{
			get
			{
				return PaymentType.GetForCode("credit");
			}
		}

		#endregion

		#region Constructors

		public PaymentType(int id, string code, string name)
		{
			Code = code;
			ID = id;
			Name = name;
		}

		#endregion

		#region Properties

		public int ID { get; private set; }
		public string Code { get; private set; }
		public string Name { get; private set; }

		#endregion

		#region Overriding Object

		public override string ToString()
		{
			if (this.Code != null)
			{
				return this.Code;
			}
			else
			{
				return base.ToString();
			}
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			PaymentType type = obj as PaymentType;

			return Code.Equals(type.Code, StringComparison.InvariantCultureIgnoreCase);
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			return Code.ToUpperInvariant().GetHashCode();
		}	

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		#endregion
	}
}
