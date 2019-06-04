using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace P4U.CommonExt
{
	public class PaymentCurrencyComposition: IEnumerable<Money>,IEquatable<PaymentCurrencyComposition>
	{
		private Dictionary<Currency,Money> _CurrencyComposition = new Dictionary<Currency,Money>();

		public PaymentCurrencyComposition(Money money)
		{
			if (money != null)
			{
				_CurrencyComposition.Add(money.Currency, money);
			}
		}

		public PaymentCurrencyComposition(IEnumerable<Money> moneys)
		{
			if (moneys != null)
			{
				foreach (Money money in moneys)
				{
					_CurrencyComposition.Add(money.Currency, money);
				}
			}
		}

		public PaymentCurrencyComposition()
		{
		}

		public void Clear()
		{
			_CurrencyComposition.Clear();
		}

		public PaymentCurrencyComposition AddMoney(Money money)
		{
			if (_CurrencyComposition.ContainsKey(money.Currency))
			{
				_CurrencyComposition[money.Currency] += money;
			}
			else
			{
				_CurrencyComposition.Add(money.Currency, money);
			}

			return this;
		}

		public Money GetMoneyForCurrency(Currency currency)
		{
			if (currency != null && _CurrencyComposition.ContainsKey(currency))
			{
				return _CurrencyComposition[currency];
			}
			else
			{
				return new Money(0, currency);
			}
		}

		public Money GetMoneyForCurrency(string currencyCode)
		{
			Currency currency = Currency.GetForCode(currencyCode);

			return GetMoneyForCurrency(currency);
		}

		public Money this[Currency currency]
		{
			get
			{
				return GetMoneyForCurrency(currency);
			}
		}

		public Money this[string currencyCode]
		{
			get
			{
				return GetMoneyForCurrency(currencyCode);
			}
		}

		public bool HasSomeNonzeroAmount
		{
			get
			{
				foreach (var kvp in _CurrencyComposition)
				{
					if (kvp.Value.Amount != 0)
					{
						return true;
					}
				}
				return false;
			}
		}

		public string ToString(string separator)
		{
			string[] list = new string[_CurrencyComposition.Count];

			int i = 0;
			foreach (var kvp in _CurrencyComposition)
			{
				list[i++] = kvp.Value.ToString();
			}

			string ret = string.Empty;

			if (list.Length > 0)
			{
				ret = string.Join(separator, list);
			}

			return ret;
		}

		public static PaymentCurrencyComposition operator +(PaymentCurrencyComposition ls, PaymentCurrencyComposition rs)
		{
			PaymentCurrencyComposition result = new PaymentCurrencyComposition();
			foreach (Money money in ls)
			{
				result.AddMoney(money);
			}
			foreach (Money money in rs)
			{
				result.AddMoney(money);
			}

			return result;
		}

		public static PaymentCurrencyComposition operator -(PaymentCurrencyComposition ls, PaymentCurrencyComposition rs)
		{
			return ls + (-rs);
		}

		public static PaymentCurrencyComposition operator -(PaymentCurrencyComposition rs)
		{
			PaymentCurrencyComposition result = new PaymentCurrencyComposition();

			foreach (Money money in rs)
			{
				result.AddMoney(-money);
			}

			return result;
		}

		public static explicit operator Money(PaymentCurrencyComposition currencyComposition)
		{
			Money retval = null;

			foreach (var money in currencyComposition)
			{
				if (money > 0 || money < 0)
				{
					if (retval == null)
					{
						retval = money;
					}
					else
					{
						retval = null;
						break;
					}
				}
			}

			if (retval == null)
				throw new InvalidCastException("Cannot convert to Money");

			return retval;
		}

		public override string ToString()
		{
			return ToString(" + ");
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			return this.Equals((PaymentCurrencyComposition) obj);
		}

		// override object.GetHashCode
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		IEnumerator<Money> IEnumerable<Money>.GetEnumerator()
		{
			return _CurrencyComposition.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Money>)this).GetEnumerator();
		}

		public bool Equals(PaymentCurrencyComposition other)
		{
			if (other == null)
				return false;

			foreach (Currency currency in Currency.GetObjects())
			{
				if (!this[currency].Equals(other[currency]))
					return false;
			}

			return true;
		}
	}
}
