using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class TranactionManager
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();

        public bool HasPendingTransaction
        {
            get { return _transactions.Any(x => !x.IsCompleted);  } 
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void ProcessPendingTransaction()
        {
            foreach (var transaction in _transactions.Where(x => !x.IsCompleted))
            {
                transaction.Execute();
            }
        }
    }
}
