﻿using BankApp.BLL.DepositRules;
using BankApp.BLL.WithdrawRules;
using BankApp.Models;
using BankApp.Models.Interfaces;
using BankApp.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("22222", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account accountDesposit = new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };
            AccountDepositResponse Response = deposit.Deposit(accountDesposit, amount);
            Assert.AreEqual(expectedResult, Response.Success);
        }

        [TestCase("22222", "Premium Account", 150, AccountType.Premium, -1000, 1500, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("22222", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -150, -60, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdrawal = new PremiumAccountWithdrawRule();
            Account accountWithdraw = new Account() { AccountNumber = accountNumber, Type = accountType, Balance = balance };
            AccountWithdrawResponse response = withdrawal.Withdraw(accountWithdraw, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
