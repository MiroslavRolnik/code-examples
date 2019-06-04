using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P4U.CommonExt
{
	public enum MoneyString
	{
		ShortCode,
		ISOCode,
		ShortCodeWithFormatString
	}

	public class Money
	{
		private static MoneyString? _MoneyString;
		public static MoneyString MoneyString
		{
			get
			{
				return _MoneyString ?? MoneyString.ShortCode;
			}
			set
			{
				if (_MoneyString != null)
					throw new ArgumentException("MoneyString has been already set!");

				_MoneyString = _MoneyString ?? value;
			}
		}

		#region Constructors

		public Money(Currency currency) : this(0, currency)
		{
		}

		public Money(decimal amount, string currencyCode)
		{
			this.Amount = amount;
			this.Currency = Currency.GetForCode(currencyCode);
		}

		public Money(decimal amount, Currency currency)
		{
			this.Amount = amount;
			this.Currency = currency;
		}

		public Money(Money money) : this(money.Amount, money.Currency)
		{
		}

		#endregion


		#region MoneyConversion

		public static Money Convert(Money from, Currency toCurrency)
		{
			decimal toAmount = from.Amount * GetExchangeRate(from.Currency, toCurrency);

			return new Money(toAmount, toCurrency);
		}

		public Money Convert(Currency toCurrency)
		{
			return Convert(this, toCurrency);
		}

		private static decimal GetExchangeRate(Currency from, Currency to)
		{
			return 1;
		}

		#endregion


		#region Properties

		public decimal Amount { get; set; }
		public Currency Currency { get; private set; }

		/// <summary>
		/// V pripade prepoctu men obsahuje pouzity kurs
		/// </summary>
		public decimal? Rate { get; private set; }

		#endregion


		#region Private Methods

		#endregion


		#region Public Methods

		public void RoundByCurrency(int? decimalPlaces = null)
		{
			this.Amount = this.Currency.RoundToDecimal(this.Amount, decimalPlaces);
		}

		public string ToString(int decimalPlaces)
		{
			if (this.Currency != null)
			{
				return this.Currency.ToStringIsoCurrency(Amount, decimalPlaces);
			}

			return string.Format("{0} ?", this.Amount);
		}

		public string ToString(string numberFormat)
		{
			if (this.Currency != null)
			{
				return this.Currency.ToStringIsoCurrency(Amount, numberFormat);
			}

			return string.Format("{0} ?", this.Amount);
		}

		public void Round(int? decimalPlaces = null)
		{
			if (Currency != null)
			{
				Amount = Currency.RoundToDecimal(Amount, decimalPlaces);
			}
		}

		public void Ceiling()
		{
			if (Currency != null)
			{
				Amount = Currency.CeilingToDecimal(Amount);
			}
		}


		/*public Money ConvertTo(Currency currency)
		{
			if (this.Currency.Equals(currency))
			{
				return new Money(this.Amount, this.Currency);
			}


			decimal? rate = Business.APP.Currency.GetCurrencyRate(this.Currency, currency, DateTime.Now);

			if (rate == null) // smenny kurz neni definovan!
			{
				this.Currency.LoadFromDB();
				currency.LoadFromDB();
				string errMsg = string.Format("Směnný kurz není definován; CurFrom=[{0}], CurTo=[{1}]", this.Currency.Code, currency.Code);
				_Logger.Error(errMsg);
				throw new ApplicationException(errMsg);
			}

			Money m = new Money(currency);
			m.Currency = currency;

			if (this.Currency.Equals(Global.StationSettings.BaseCurrency))
			{
				// Konvertuji z CZK na cizí měnu
				m.Amount = this.Amount / (decimal)rate;
			}
			else
			{
				// Konvertuji z cizí měny na CZK
				m.Amount = this.Amount * (decimal)rate;
			}

			m.Rate = rate;

			return m;
		}*/

		#endregion


		#region Override from Object

		public override string ToString()
		{
			if (this.Currency != null)
			{
				switch (MoneyString)
				{
					case MoneyString.ShortCode:
						return this.Currency.ToStringCurrency(Amount);
					case MoneyString.ISOCode:
						return this.Currency.ToStringIsoCurrency(Amount);
					case MoneyString.ShortCodeWithFormatString:
						return this.Currency.ToStringCurrency(Amount, string.Empty);
				}
			}

			return string.Format("{0} ?", this.Amount);
		}

		public override bool Equals(object obj)
		{
			if (obj != null && obj is Money)
			{
				Money mobj = (Money)obj;

				if (mobj.Currency != null && this.Currency != null && mobj.Amount == this.Amount && mobj.Currency.Equals(this.Currency))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			string ccyPart = (this.Currency != null) ? this.Currency.Code : "?";

			string text = this.Amount.ToString() + ccyPart;
			return text.GetHashCode();
		}

		#endregion


		#region Override Operators

		public static Money operator -(Money rm)
		{
			return new Money(-rm.Amount, rm.Currency);
		}

		public static Money operator +(Money lm, decimal val)
		{
			return new Money(lm.Amount + val, lm.Currency);
		}

		public static Money operator -(Money lm, decimal val)
		{
			return new Money(lm.Amount - val, lm.Currency);
		}

		public static Money operator +(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return new Money(lm.Amount + rm.Amount, lm.Currency);
		}

		public static Money operator -(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return new Money(lm.Amount - rm.Amount, lm.Currency);
		}

		public static Money operator /(Money lm, int num)
		{
			return new Money(lm.Amount / (decimal)num, lm.Currency);
		}

		public static Money operator *(Money lm, decimal num)
		{
			return new Money(lm.Amount * num, lm.Currency);
		}

		public static Money operator /(Money lm, decimal val)
		{
			return new Money(lm.Amount / val, lm.Currency);
		}

		public static decimal operator /(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount / rm.Amount;
		}

		public static bool operator >(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount > rm.Amount;
		}

		public static bool operator <(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount < rm.Amount;
		}

		public static bool operator <(Money lm, decimal rm)
		{
			return lm.Amount < rm;
		}


		public static bool operator >(Money lm, decimal rm)
		{
			return lm.Amount > rm;
		}

		public static bool operator >(decimal lm, Money rm)
		{
			return rm < lm;
		}

		public static bool operator <(decimal lm, Money rm)
		{
			return rm > lm;
		}

		public static decimal operator %(Money lm, Money rm)
		{
			if (lm == null || rm == null)
			{
				throw new ArgumentNullException("Both money must be not null!");
			}

			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount % rm.Amount;
		}

		public static bool operator >=(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount >= rm.Amount;
		}

		public static bool operator <=(Money lm, Money rm)
		{
			if (!lm.Currency.Equals(rm.Currency))
			{
				throw new InvalidOperationException("Money currencies are not the same.");
			}

			return lm.Amount <= rm.Amount;
		}

		public static implicit operator PaymentCurrencyComposition(Money money)
		{
			return new PaymentCurrencyComposition(money);
		}

		#endregion

	}
}
