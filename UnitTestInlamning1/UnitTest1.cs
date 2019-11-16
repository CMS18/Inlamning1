using Inlamning1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestInlamning1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Deposit()
        {
            //Arrange
            var account = new Account { balance = 500, accountId = 444 };
            var amountToDeposit = 300m;
            var repo = new BankRepository();
            var remain = 200m;

            //Act
            repo.Deposit(account, amountToDeposit);

            //Assert
            Assert.AreEqual(remain, account.balance);
        }
        

        [TestMethod]
        public void Withdraw()
        {
            //Arrange
            var account = new Account { balance = 500m, accountId = 444 };
            var amountToWithdraw = 200m;
            var repo = new BankRepository();
            var remain = 300m;

            //Act
            repo.Withdraw(account, amountToWithdraw);

            //Assert
            Assert.AreEqual(remain, account.balance);
        }

       

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WithdrawExceeded()
        {
            //Arrange
            var account = new Account { balance = 500m, accountId = 444 };
            var amountToWithdraw = 501m;
            var repo = new BankRepository();

            //Act and Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repo.Withdraw(account, amountToWithdraw));
        }


    }
}
