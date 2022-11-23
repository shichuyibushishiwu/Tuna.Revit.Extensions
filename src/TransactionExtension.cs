using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class TransactionExtension
    {
        public static TransactionStatus NewTransaction(this Document document, Func<bool> func, string name = "Default Transaction Name")
        {
            TransactionStatus status = TransactionStatus.Uninitialized;
            using (Transaction transaction = new Transaction(document, name))
            {
                transaction.Start();
                var result = func.Invoke();
                status = result ? transaction.Commit() : transaction.RollBack();
            }
            return status;
        }

        public static TransactionStatus NewSubTransaction(this Document document, Action action)
        {
            TransactionStatus status = TransactionStatus.Uninitialized;
            using (SubTransaction transaction = new SubTransaction(document))
            {
                transaction.Start();
                action?.Invoke();
                transaction.Commit();
            }
            return status;
        }

        public static TransactionStatus NewTransactionGroup(this Document document, Func<bool> func, string name = "Default Transaction Group Name")
        {
            TransactionStatus status = TransactionStatus.Uninitialized;
            using (TransactionGroup ts = new TransactionGroup(document, name))
            {
                ts.Start();
                bool result = func.Invoke();
                status = result ? ts.Assimilate() : ts.RollBack();
            }
            return status;
        }

    }
}
