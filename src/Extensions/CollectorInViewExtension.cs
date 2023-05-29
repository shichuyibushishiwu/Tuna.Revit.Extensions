///************************************************************************************
///   Author:十五
///   CretaeTime:2022/11/27 23:58:13
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit element filters extension
    /// </summary>
    public static partial class CollectorExtension
    {
        /// <summary>
        /// 根据视图获取视图中的所有图元
        /// <para>Get elements in view <see cref="Autodesk.Revit.DB.View"/></para>
        /// </summary>
        /// <param name="view">host view</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static FilteredElementCollector GetElements(this View view)
        {
            if (view == null || !view.IsValidObject)
            {
                throw new ArgumentNullException(nameof(view), "view is null or invalid object");
            }

            if (view.IsTemplate)
            {
                throw new ArgumentNullException(nameof(view), "view is a template");
            }

            return new FilteredElementCollector(view.Document, view.Id);
        }

        /// <summary>
        /// 根据元素过滤器获取视图中的图元
        /// <para>Get elements in view by <see cref="Autodesk.Revit.DB.ElementFilter"/></para>
        /// </summary>
        /// <param name="view">host view</param>
        /// <param name="elementFilter"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, ElementFilter elementFilter)
        {
            return view.GetElements().WherePasses(elementFilter);
        }

        /// <summary>
        /// 根据类型获取视图中的图元
        /// <para>Get elements in view by <see cref="System.Type"/></para>
        /// </summary>
        /// <param name="view"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, Type type)
        {
            return view.GetElements(new ElementClassFilter(type));
        }

        /// <summary>
        /// 根据类型获取视图中的图元
        /// <para>Get element in view by <typeparamref name="T"/></para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="view">host view</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElements<T>(this View view, Func<T, bool> predicate = null) where T : Element
        {
            IEnumerable<T> elements = view.GetElements(typeof(T)).Cast<T>();
            if (predicate != null)
            {
                elements = elements.Where(predicate);
            }
            return elements;
        }
    }
}
