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
        /// <summary>
        /// This is a function which used to start a document transaction
        /// </summary>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <param name="name"></param>
        /// <returns>If document is read only,return <see cref="Autodesk.Revit.DB.TransactionStatus.Error"/></returns>
        public static TransactionStatus NewTransaction(this Document document, Action action, bool rollback = false, string name = "Default Transaction Name")
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (document.IsReadOnly)
            {
                return TransactionStatus.Error;
            }

            using (Transaction transaction = new Transaction(document, name))
            {
                if (transaction.Start() == TransactionStatus.Started)
                {
                    action.Invoke();
                    if (!rollback)
                    {
                        return transaction.Commit();
                    }
                }
                return transaction.RollBack();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="action"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <param name="name"></param>
        /// <returns></returns>
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
