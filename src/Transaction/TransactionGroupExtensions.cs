using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

public static class TransactionGroupExtensions
{
    /// <summary>
    /// This is a function which used to start a document Transaction Group
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <param name="rollback"></param>
    /// <param name="assimilate"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static TransactionStatus NewTransactionGroup(this Document document, Action action, string name = "Default Transaction Group Name", bool rollback = false, bool assimilate = true)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        using (TransactionGroup tsg = new TransactionGroup(document, name))
        {
            if (tsg.Start() == TransactionStatus.Started)
            {
                action.Invoke();
                if (!rollback)
                {
                    return assimilate ? tsg.Assimilate() : tsg.Commit();
                }
            }
            return tsg.RollBack();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="document"></param>
    /// <param name="action"></param>
    /// <param name="name"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static void NewTransactionGroup(this Document document, Action<TransactionGroup> action, string name = "Default Transaction Group Name")
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ArgumentNullExceptionUtils.ThrowIfNull(action);

        using (TransactionGroup tsg = new TransactionGroup(document, name))
        {
            if (tsg.Start() == TransactionStatus.Started)
            {
                action.Invoke(tsg);
            }
        }
    }
}
