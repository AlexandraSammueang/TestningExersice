﻿using System;
using Xunit;
using Lektion2Exersice;

namespace Lektion2.UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void Account_ChecksIfAmountIsEmpty()
        {
            var account = new Account();
            Assert.True(account.Amount.isZero());

        }

        [Fact]
        public void Deposit_CheckIfMoneyIsAdded()
        {
            var account = new Account();
            account.Amount = new Kronor(5, 0);
            var kronor = new Kronor(2, 0);

            account.Deposit(kronor);
            var actualValue1 = account.Amount.KronorPart();
            //var actualValue2 = account.Amount.ÖrenPart();

            Assert.Equal(7, actualValue1);
            //Assert.Equal(2, actualValue2);

        }

        [Fact]
        public void Withdraw_WhenAccountIsPosetive_OrInAccountMore90Persont()
        {
            var account = new Account();
            account.Amount = new Kronor(9, 0);
            var kronor = new Kronor(10, 0);

            account.Withdraw(kronor);
            var actualValue1 = account.Amount.KronorPart();
            //var actualValue2 = account.Amount.ÖrenPart();

            Assert.Equal(-1, actualValue1);
            //Assert.Equal(2, actualValue2);

        }

        [Fact]
        public void Withdraw_WhenMoneyLessThan90_ReturnExeption()
        {
            //Arrange
            var account = new Account();
            account.Amount = new Kronor(5, 0);
            var kronor = new Kronor(7, 0);

            //Act
            Action act = () => account.Withdraw(kronor);

            //Assert
            Assert.Throws<ArgumentException>(act);

        }

        [Fact]
        public void RemoveAll_WhenCalled_RemovesAllTheMoneyFrom_Account()
        {
            //Arrange
            var account = new Account(new Kronor(10, 0));

            //Act
            account.RemoveAll();
            var actualValue = account.Amount.KronorPart();

            //Assert
            Assert.Equal(0, actualValue);

        }

        [Fact]
        public void Transfer_money_from_to()
        {
           
            {
                var kronor = new Kronor(11, 11);
                var account1 = new Account(kronor);
                var account2 = new Account();
                Account.Transfer(account1, account2, kronor);
                Assert.True(account1.Amount.isZero());
                Assert.True(account2.Amount.isPositive());

               

            }

        }

    }
}
