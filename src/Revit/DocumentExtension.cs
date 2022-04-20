///************************************************************************************
///   Author:十五
///   CretaeTime:2021/11/19 21:41:53
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class DocumentExtension
    {
        public static void NewTransaction(this Document document, Action action, string name = "Default Transaction Name")
        {
            using (Transaction transaction = new Transaction(document, name))
            {
                transaction.Start();
                action?.Invoke();
                transaction.Commit();
            }
        }

        public static void NewSubTransaction(this Document document, Action action)
        {
            using (SubTransaction transaction = new SubTransaction(document))
            {
                transaction.Start();
                action?.Invoke();
                transaction.Commit();
            }
        }

        public static TransactionStatus NewTransactionGroup(this Document document, string name, Func<bool> func)
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


        public static IEnumerable<T> GetElements<T>(this Document document, Func<T, bool> func = null) where T : Element
        {
            FilteredElementCollector elements = new FilteredElementCollector(document).WhereElementIsNotElementType();
            var elems = elements.OfClass(typeof(T)).ToElements().ToList().Cast<T>();
            if (func != null)
            {
                elems = elems.Where(func).ToList();
            }
            return elems;
        }

        public static IEnumerable<T> GetElementTypes<T>(this Document document, Func<T, bool> func = null) where T : ElementType
        {
            FilteredElementCollector elements = new FilteredElementCollector(document).WhereElementIsElementType();
            var elems = elements.OfClass(typeof(T)).ToElements().ToList().Cast<T>();
            if (func != null)
            {
                elems = elems.Where(func).ToList();
            }
            return elems;
        }
    }
}
