using Xunit.Sdk;

namespace BankAccountDDTTest
{
    public class BankingAccountDDTTestingData
    {
        private static readonly List<object[]> dataWithDraw = new List<object[]>
        {
            new object[] {100, 100, 0},
            new object[] {110, 90, 20},
            new object[] {50, 20, 30 }
        };

        public static IEnumerable<object[]> TestWithDrawData { get { return dataWithDraw; } }

        private static readonly List<object[]> dataDeposit = new List<object[]>
        {
            new object[] {0, 100, 100},
            new object[] {90, 20, 110},
            new object[] {123, 321, 444}
        };

        public static IEnumerable<object[]> TestDepositData { get { return dataDeposit; } }

        private static readonly List<object[]> dataExchangeMoney = new List<object[]>
        {
            new object[] {48000, 2},
            new object[] {1992000, 83},
            new object[] {576000, 24}
        };
        public static IEnumerable<object[]> TestExchangeMoneyData { get { return dataExchangeMoney; } }
    }

    public class TestBankingAccountUsingDDT
    {
        [Theory]
        [MemberData("TestWithDrawData", MemberType = typeof(BankingAccountDDTTestingData))]
        public void WithDrawFuncReturnRightValueTest(double balance, double amount, double newBalance)
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", balance);
            account.WithDraw(amount);
            Assert.Equal(newBalance, account.Balance);
        }

        [Theory]
        [MemberData("TestDepositData", MemberType = typeof(BankingAccountDDTTestingData))]
        public void DepositFunctionReturnRightValueTest(double balance, double amount, double newBalance)
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", balance);
            account.Deposit(amount);
            Assert.Equal(newBalance, account.Balance);
        }

        [Theory]
        [MemberData("TestExchangeMoneyData", MemberType = typeof(BankingAccountDDTTestingData))]
        public void ExchangeMoneyFunctionReturnRightValue(double amount, double expected)
        {
            double actual = BankingAccount.ExchangeMoneyFromVndToDolar(amount);
            Assert.Equal(expected, actual);
        }
    }
}