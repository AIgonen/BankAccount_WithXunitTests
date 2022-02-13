using Bank;
using System;
using Xunit;

namespace BankXunitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Adds_Funds_Updates_Balance()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act
            account.Add(100);

            //Assert
            Assert.Equal(1100, account.Balance);
        }

        [Fact]
        public void Adds_NegativeFunds_Throws()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

        [Fact]
        public void Withdraw_Funds_Updates_Balance()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act
            account.Withdraw(200);

            //Assert
            Assert.Equal(800, account.Balance);
        }

        [Fact]
        public void Withdraw_NegativeFunds_Throws()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdraw_MoreThenFunds_Throws()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));

        }



        [Fact]
        public void Transfering_Funds_Updates_BothAccounts()
        {
            //Arrange
            var firtsAccount = new BankAccount(1000);
            var secondAccount = new BankAccount();

            //Act
            firtsAccount.TransferFundsTo(secondAccount, 300);


            //Assert
            Assert.Equal(700, firtsAccount.Balance);
            Assert.Equal(300, secondAccount.Balance);
        }

        [Fact]
        public void Transfers_Funds_ToNonExistenAccount_Throws()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 100));

        }
    }
}
