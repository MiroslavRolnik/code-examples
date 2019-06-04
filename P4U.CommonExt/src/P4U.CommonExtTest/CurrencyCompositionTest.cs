using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P4U.CommonExt;

namespace P4U.CommonExtTest
{
	[TestClass]
	public class CurrencyCompositionTest
	{
		public CurrencyCompositionTest()
		{
			InitCurrency();
		}

		private void InitCurrency()
		{
			Currency.AddObject(new Currency(1, "CZK", "česká koruna", "Kč", "N0", 0));
			Currency.AddObject(new Currency(2, "EUR", "euro", "€", "N2", 2));
		}

		[TestMethod]
		public void EqualsTest()
		{
			Currency CZK = Currency.GetForCode("CZK");
			Currency EUR = Currency.GetForCode("EUR");

			PaymentCurrencyComposition moneysA = new PaymentCurrencyComposition();
			moneysA.AddMoney(new Money(5, CZK));
			moneysA.AddMoney(new Money(10, CZK));
			moneysA.AddMoney(new Money(3, EUR));
			moneysA.AddMoney(new Money(4, EUR));

			PaymentCurrencyComposition moneysB = new PaymentCurrencyComposition();
			moneysB.AddMoney(new Money(15, CZK));
			moneysB.AddMoney(new Money(7, EUR));

			PaymentCurrencyComposition moneysC = new PaymentCurrencyComposition();
			moneysC.AddMoney(new Money(15, CZK));

			PaymentCurrencyComposition moneysD = new PaymentCurrencyComposition();
			moneysD.AddMoney(new Money(15, CZK));
			moneysD.AddMoney(new Money(3, EUR));

			Assert.IsTrue(moneysA.Equals(moneysB));

			Assert.IsFalse(moneysC.Equals(moneysD));
		}
	}
}
