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
            var account = new Account { balance = 500m, accountId = 444 };
            var amountToDeposit = 300m;
            var repo = new BankRepository();

            //här var remain variabeln 200m innan, nog räknat på withdraw av summan :)
            var remain = 800m;

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

            // raden nedanför behövs inte, metoden tar själv hand om att ett förväntat exception kastas
            // Assert.ThrowsException<ArgumentOutOfRangeException>(() => repo.Withdraw(account, amountToWithdraw));

            //raden nedanför räcker :) 
            repo.Withdraw(account, amountToWithdraw);

        }

        [TestMethod]
        public void TestTransfer()
        {
            var fromaccount = new Account { balance = 200, accountId = 1 };
            var toaccount = new Account { balance = 200, accountId = 2 };
            var amount = 100;
            var newfromaccBalance = fromaccount.balance - amount;
            var newtoaccBalance = toaccount.balance + amount;

            var bank = new BankRepository();
            bank.Transfer(fromaccount, toaccount, amount);

            Assert.AreEqual(newfromaccBalance, fromaccount.balance);
            Assert.AreEqual(newtoaccBalance, toaccount.balance);
        }


    }
}
