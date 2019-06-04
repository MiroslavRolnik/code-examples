using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P4U.CommonExt;

namespace P4U.CommonExtTest
{
	/// <summary>
	/// Summary description for MoneyTest
	/// </summary>
	[TestClass]
	public class MoneyTest
	{
		public MoneyTest()
		{
			InitCurrency();
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		private void InitCurrency()
		{
			Currency.AddObject(new Currency(1, "CZK", "česká koruna", "Kč", "N0", 0));
			Currency.AddObject(new Currency(2, "EUR", "euro", "€", "N2", 2));
		}

		[TestMethod]
		public void EqualTest()
		{
			Money a = new Money(5, "CZK");
			Money b = new Money(5, "CZK");
			Money c = new Money(5, "EUR");

			Assert.IsTrue(a != null);

			Assert.IsFalse(a == null);

			Assert.IsTrue(a.Equals(b));

			Assert.IsFalse(a.Equals(c));

			Assert.ThrowsException<InvalidOperationException>(() => a + c);
		}

		[TestMethod]
		public void ToStringTest()
		{
			InitCurrency();

			Currency c = null;
			Money b = new Money(5, c);

			Assert.IsTrue(b.ToString().Equals("5 ?"));


			Money a = new Money(5, "CZK");


			Assert.IsTrue(a.ToString().Equals("5 Kč"));
			Assert.IsTrue(a.Currency.ToStringCurrency(a.Amount).Equals("5 Kč"));


			Money.MoneyString = MoneyString.ISOCode;

			Assert.IsTrue(b.ToString().Equals("5 ?"));

			Assert.IsTrue(a.ToString().Equals("5 CZK"));
			Assert.IsTrue(a.Currency.ToStringIsoCurrency(a.Amount).Equals("5 CZK"));


			Assert.ThrowsException<ArgumentException>(() => { Money.MoneyString = MoneyString.ShortCode; });
		}
	}
}
