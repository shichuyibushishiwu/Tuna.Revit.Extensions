///************************************************************************************
///   Author:十五
///   CretaeTime:2022/11/27 23:57:45
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
    public static partial class CollectorExtension
    {
        /// <summary>
        /// Get Elements
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static FilteredElementCollector GetElements(this Document document)
        {
            if (document == null || !document.IsValidObject)
            {
                throw new ArgumentNullException("document is null or invalid object");
            }
            return new FilteredElementCollector(document);
        }

        /// <summary>
        /// Get Elements
        /// </summary>
        /// <param name="document"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementFilter filter)
        {
            return document.GetElements().WherePasses(filter);
        }

        /// <summary>
        /// Get Elements
        /// </summary>
        /// <param name="document"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this Document document, Type type)
        {
            return document.GetElements(new ElementClassFilter(type));
        }

        /// <summary>
        /// Get Elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElements<T>(this Document document, Func<T, bool> predicate = null) where T : Element
        {
            IEnumerable<T> elements = document.GetElements(typeof(T)).Cast<T>();
            if (predicate != null)
            {
                elements = elements.Where(predicate);
            }
            return elements;
        }

        /// <summary>
        /// Get Element Types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElementTypes<T>(this Document document, Func<T, bool> func = null) where T : ElementType
        {
            IEnumerable<T> elementTypes = document.GetElements(typeof(T)).Cast<T>();
            if (func != null)
            {
                elementTypes = elementTypes.Where(func);
            }
            return elementTypes;
        }
    }
}
