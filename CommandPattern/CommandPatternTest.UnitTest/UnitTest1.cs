using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandPattern;

namespace CommandPatternTest.UnitTest
{
    [TestClass]   
    public class TestAllTransactions
    {
        [TestMethod]
        public void Test_AllTransactionsSuccessfull()
        {
            TranactionManager transactionManager = new TranactionManager();

            Account asifAccount = new Account("Muhammad Asif", 0);
            Account shumailaAccount = new Account("Shumaila Firdous", 0);

            Deposit deposit = new Deposit(asifAccount, 100);
            transactionManager.AddTransaction(deposit);

            Assert.IsTrue(transactionManager.HasPendingTransaction);
            Assert.AreEqual(0, asifAccount.Balance);

            transactionManager.ProcessPendingTransaction();

            Assert.IsFalse(transactionManager.HasPendingTransaction);
            Assert.AreEqual(100, asifAccount.Balance);

            Withdraw withDrawal = new Withdraw(asifAccount, 50);
            transactionManager.AddTransaction(withDrawal);

            transactionManager.ProcessPendingTransaction();

            Assert.IsFalse(transactionManager.HasPendingTransaction);
            Assert.AreEqual(50, asifAccount.Balance);
            
        }
    }
}
