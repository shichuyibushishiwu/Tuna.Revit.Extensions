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
        /// <summary>
        /// Create A Document Transaction
        /// example:
        /// doc.TransactionRaise(()=>{ do sometion},"name")
        /// </summary>
        /// <param name="document">active document</param>
        /// <param name="action"></param>
        /// <param name="name"></param>
        public static void TransactionRaise(this Document document, Action action, string name)
        {
            using (Transaction ts = new Transaction(document))
            {
                ts.Start(name);
                action.Invoke();
                ts.Commit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<T> GetElements<T>(this Document document, Func<T, bool> func = null) where T : Element
        {
            FilteredElementCollector elements = new FilteredElementCollector(document);
            List<T> elems = elements.OfClass(typeof(T)).ToElements().ToList().ConvertAll(x => x as T);
            if (func != null)
            {
                elems = elems.Where(func).ToList();
            }
            return elems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool Exist<T>(this Document document, Func<Element, bool> func) where T : Element
        {
            return document.GetElements<T>(func).Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="basicName"></param>
        /// <returns></returns>
        public static string GetUniqueName<T>(this Document document, string basicName) where T : Element
        {
            int number = 0;
            string name = basicName;
            while (document.Exist<T>(e => e.Name == name))
            {
                number++;
                name = $"{basicName}({number})";
            }
            return name;
        }
    }
}
