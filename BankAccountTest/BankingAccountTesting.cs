using BankAccountTest;

namespace BankAccountTest
{
    public class BankingAccountTesting
    {
        [Fact]
        public void CallingConstructorThrowFormatExceptionTest()
        {
            BankingAccount bankingAccount;
            Assert.Throws<FormatException>(() => bankingAccount = new BankingAccount("123", "Duy", 100));
            Assert.Throws<FormatException>(() => bankingAccount = new BankingAccount("A", "Duy", 100));
        }
        [Fact]
        public void PrintAccountReturnTheRightString()
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", 100);
            Assert.Equal("Account ID: 1234567890\nCustomer Name: Duy" +
                "\nBalance: 100", account.ToString());
        }

        [Fact]
        public void DepositFunctionReturnRightValueTest()
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", 0);
            account.Deposit(100);
            Assert.Equal(100, account.Balance);
        }

        [Fact]
        public void DepositFunctionThrowArgumentOutOfRangeExceptionTest()
        {
            BankingAccount bankingAccount = new BankingAccount("1234567890", "Duy", 0);
            Assert.Throws<ArgumentOutOfRangeException>( () => bankingAccount.Deposit(-1));
        }

        [Fact]
        public void WithDrawFuncReturnRightValueTest()
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", 100);
            account.WithDraw(100);
            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void WithDrawFunThrowArgumentOutOfRangeExceptionTest()
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", 10);
            Assert.Throws<ArgumentOutOfRangeException>(() => account.WithDraw(100));
            Assert.Throws<ArgumentOutOfRangeException>(() => account.WithDraw(-1));
        }

        [Fact]
        public void CombineDepositAndWithDrawReturnRightResultTest()
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", 100);
            account.Deposit(10);
            Assert.Equal(110, account.Balance);
            account.WithDraw(100);
            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void ExchangeMoneyReturnRightValueTest()
        {
            double result = BankingAccount.ExchangeMoneyFromVndToDolar(48000);
            Assert.Equal(2, result);
        }

        [Fact]
        public void ExchangeMonetThrowArgumentOutOfRangeExceptionTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BankingAccount.ExchangeMoneyFromVndToDolar(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => BankingAccount.ExchangeMoneyFromVndToDolar(20000));
        }

        //using Theory to initialize data
        [Theory]
        [InlineData(100, 100, 0)]
        [InlineData(110, 90, 20)]
        [InlineData(50, 20, 30)]
        public void WithDrawFuncReturnRightValueUsingTheoryTest(double balance, double amount, double newBalance)
        {
            BankingAccount account = new BankingAccount("1234567890", "Duy", balance);
            account.WithDraw(amount);
            Assert.Equal(newBalance, account.Balance);
        }
    }
}