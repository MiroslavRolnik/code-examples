using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P4U.CommonExt
{
	public class Currency : Cache<Currency>, ICacheElement
	{
		public int ID { get; private set; }
		public string Name { get; private set; }
		public string Code { get; private set; }
		public string Shortly { get; private set; }
		public string FormatString { get; private set; }
		public int? DecimalPlaces { get; private set; }

		public Currency(int id, string code, string name,  string shortly, string formatString, int? decimalPlaces)
		{
			ID = id;
			Name = name;
			Code = code;
			Shortly = shortly;
			FormatString = formatString;
			DecimalPlaces = decimalPlaces;
		}

		public override string ToString()
		{
			return Code;
		}
		/// <summary>
		/// vrátí zformátované číslo s příznakem měny
		/// </summary>
		/// <param name="value">číslo k formátování</param>
		/// <returns>zformátované číslo s příznakem měny</returns>
		public string ToStringCurrency(decimal value, int? decimalPlaces = null)
		{
			return string.Format("{0} {1}", RoundToDecimal(value, decimalPlaces), Shortly);
		}

		public string ToStringCurrency(decimal value, string numberFormat)
		{
			return string.Format("{0} {1}", RoundToString(value, numberFormat), Shortly);
		}

		/// <summary>
		/// vrátí zformátované číslo s příznakem ISO měny
		/// </summary>
		/// <param name="value">číslo k formátování</param>
		/// <returns>zformátované číslo s příznakem měny</returns>
		public string ToStringIsoCurrency(decimal value, int? decimalPlaces = null)
		{
			return string.Format("{0} {1}", RoundToDecimal(value, decimalPlaces), Code);
		}

		/// <summary>
		/// vrátí zformátované číslo s příznakem ISO měny
		/// </summary>
		/// <param name="value">číslo k formátování</param>
		/// <returns>zformátované číslo s příznakem měny</returns>
		public string ToStringIsoCurrency(decimal value, string numberFormat)
		{
			return string.Format("{0} {1}", RoundToString(value, numberFormat), Code);
		}

		/// <summary>
		/// vrátí zakrouhlené číslo v daném formátu v řetězci
		/// </summary>
		/// <param name="value">číslo k zaokrouhlení</param>
		/// <returns>zformátované číslo v řetězci</returns>
		public string RoundToString(decimal value, string numberFormat = null)
		{
			string format = null;

			if (string.IsNullOrEmpty(numberFormat))
			{
				format = this.FormatString;
			}
			else
			{
				format = numberFormat;
			}

			return value.ToString(format);
		}

		/// <summary>
		/// zaokrouhlí číslo dle dané měny
		/// </summary>
		/// <param name="value">číslo k zaokrouhlení</param>
		/// <returns>zaokrouhlené číslo</returns>
		public decimal RoundToDecimal(decimal value, int? decimalPlaces = null)
		{
			int places = decimalPlaces ?? (this.DecimalPlaces ?? 0);

			return Math.Round(value, places);
		}

		public decimal CeilingToDecimal(decimal value, int? decimalPlaces = null)
		{
			int places = decimalPlaces ?? (this.DecimalPlaces ?? 0);

			decimal factor = (decimal)Math.Pow(10, places);

			return Math.Ceiling(value * factor) / factor;
		}

		public override bool Equals(object obj)
		{
			bool retval = false;

			if (obj != null)
			{
				if (obj is Currency currency)
				{
					return Code.Equals(currency.Code);
				}
			}

			return retval;
		}

		public override int GetHashCode()
		{
			return Code.GetHashCode();
		}
	}
}
