using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandPattern;

namespace CommandPatternTest.UnitTest
{
    [TestClass]   
    public class SomeTests
    {
        
        [TestMethod]
        public void Test_DepositTransactionSuccessfull()
        {
            TranactionManager transactionManager = new TranactionManager();

            Account asifAccount = new Account("Muhammad Asif", 0);
            
            Deposit deposit = new Deposit(asifAccount, 100);
            transactionManager.AddTransaction(deposit);

            transactionManager.ProcessPendingTransaction();
            Assert.IsFalse(transactionManager.HasPendingTransaction);
            Assert.AreEqual(100, asifAccount.Balance);

        }
        [TestMethod]
        public void Test_WithdrawTransactionSuccessfull()
        {
            TranactionManager transactionManager = new TranactionManager();

            Account asifAccount = new Account("Muhammad Asif", 100);

            Withdraw withdrawal = new Withdraw(asifAccount, 100);
            transactionManager.AddTransaction(withdrawal);
            transactionManager.ProcessPendingTransaction();

            Assert.IsFalse(transactionManager.HasPendingTransaction);
            Assert.AreEqual(0, asifAccount.Balance);
            
        }

        [TestMethod]
        public void Test_TransferTransactionSuccessfull()
        {
            TranactionManager transactionManager = new TranactionManager();

            Account asifAccount = new Account("Muhammad Asif", 100);
            Account shumailaAccount = new Account("Shumaila Firdous", 25);

            Transfer transfer = new Transfer(asifAccount, shumailaAccount, 50);
            transactionManager.AddTransaction(transfer);
            transactionManager.ProcessPendingTransaction();

            Assert.IsFalse(transactionManager.HasPendingTransaction);
            Assert.AreEqual(75, shumailaAccount.Balance);
            Assert.AreEqual(50, asifAccount.Balance);

        }
    }
}
