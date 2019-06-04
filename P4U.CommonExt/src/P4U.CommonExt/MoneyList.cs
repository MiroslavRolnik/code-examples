using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4U.CommonExt
{
	public class MoneyList : List<Money>
	{
		public static bool IsNullOrZero(MoneyList list)
		{
			return (list == null || list.Count == 0);
		}

		public decimal GetAmountSumForCurrency(Currency ccy)
		{
			return this.Where(x => x.Currency.Equals(ccy)).Sum(x => x.Amount);
		}

		public Dictionary<Currency, decimal> GetAmountSumsByCurrency()
		{
			Dictionary<Currency, decimal> list = new Dictionary<Currency, decimal>();
			foreach (Currency ccy in this.Select(x => x.Currency).Distinct())
			{
				list.Add(ccy, GetAmountSumForCurrency(ccy));
			}

			return list;
		}

		public override string ToString()
		{
			string result = $"MoneyList; {Count} item(s); Sums:";
			foreach (var item in GetAmountSumsByCurrency())
			{
				result += $" {item.Key.Code}={item.Value};";
			}
			return result;
		}
	}
}
