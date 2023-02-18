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
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException("document is null or invalid object");
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
        /// This is a function which used to start a document SubTransaction 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static TransactionStatus NewSubTransaction(this Document document, Action action)
        {
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException("document is null or invalid object");
            }

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
        /// This is a function which used to start a document Transaction Group
        /// </summary>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TransactionStatus NewTransactionGroup(this Document document, Action action, bool rollback = false, bool assimilate = true, string name = "Default Transaction Group Name")
        {
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException("document is null or invalid object");
            }

            TransactionStatus status = TransactionStatus.Uninitialized;
            using (TransactionGroup ts = new TransactionGroup(document, name))
            {
                ts.Start();
                action.Invoke();
                if (rollback)
                {
                    status = ts.RollBack();
                }
                else
                {
                    status = assimilate ? ts.Assimilate() : ts.Commit();
                }
            }
            return status;
        }
    }
}
