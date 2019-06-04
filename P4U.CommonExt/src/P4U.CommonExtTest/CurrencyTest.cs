using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P4U.CommonExt;

namespace P4U.CommonExtTest
{
	[TestClass]
	public class CurrencyTest
	{
		public CurrencyTest()
		{
		}

		[TestMethod]
		public void TestMethod_ToStringCurrency()
		{
			Currency currency = new Currency(1, "CZK", "česká koruna", "Kč", "N0", 0);

			string result = currency.ToStringCurrency(1);

			Assert.IsTrue(result == "1 Kč");
		}

		[TestMethod]
		public void TestMethod_ToStringCurrencyDecimal()
		{
			Currency currency = new Currency(1, "CZK", "česká koruna", "Kč", "N0", 2);

			string result = currency.ToStringCurrency(1.11111111m);

			Assert.IsTrue(result == "1,11 Kč");

			result = currency.ToStringCurrency(1.11111111m, "N2");

			Assert.IsTrue(result == "1,11 Kč");
		}

		[TestMethod]
		public void TestMethod_ToStringIsoCurrency()
		{
			Currency currency = new Currency(1, "CZK", "česká koruna", "Kč", "N0", 0);

			string result = currency.ToStringIsoCurrency(1);

			Assert.IsTrue(result == "1 CZK");
		}
	}
}
