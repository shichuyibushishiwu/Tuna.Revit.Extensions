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
using Autodesk.Revit.DB.Structure;
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
    public static class CollectorInViewExtension
    {
        /// <summary>
        /// 根据视图获取视图中的所有图元对象
        /// <para>Get elements in view <see cref="Autodesk.Revit.DB.View"/></para>
        /// </summary>
        /// <param name="view">host view</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static FilteredElementCollector GetElements(this View view)
        {
            ArgumentNullException.ThrowIfNullOrInvalid(view);
            if (view.IsTemplate)
            {
                throw new System.ArgumentNullException(nameof(view), "view is a template");
            }
            return new FilteredElementCollector(view.Document, view.Id);
        }

        /// <summary>
        /// 根据元素过滤器获取视图中的图元对象
        /// <para>Get elements in view by <see cref="Autodesk.Revit.DB.ElementFilter"/></para>
        /// </summary>
        /// <param name="view">host view</param>
        /// <param name="elementFilter"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, ElementFilter elementFilter)
        {
            ArgumentNullException.ThrowIfNull(elementFilter);
            return view.GetElements().WherePasses(elementFilter);
        }

        /// <summary>
        /// 根据类型获取视图中的图元对象
        /// <para>Get elements in view by <see cref="System.Type"/></para>
        /// </summary>
        /// <param name="view">Revit view</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, Type type)
        {
            if (!type.IsSubclassOf(typeof(Element)))
            {
                throw new ArgumentException("type is not a subclass of element");
            }

            if (CollectorExtension.FilterTypes.TryGetValue(type, out Type filterType))
            {
                return view.GetElements(Activator.CreateInstance(filterType) as ElementFilter);
            }
            return view.GetElements(new ElementClassFilter(type));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别过滤出视图中的图元对象
        /// <para>Get elements by <see cref="Autodesk.Revit.DB.BuiltInCategory"/></para> 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, BuiltInCategory category)
        {
            return view.GetElements(new ElementCategoryFilter(category)).WhereElementIsNotElementType();
        }

        public static FilteredElementCollector GetElements(this View view, StructuralWallUsage structuralWallUsage)
        {
            return view.GetElements(new StructuralWallUsageFilter(structuralWallUsage));
        }

        public static FilteredElementCollector GetElements(this View view, StructuralMaterialType structuralMaterialType)
        {
            return view.GetElements(new StructuralMaterialTypeFilter(structuralMaterialType));
        }

        /// <summary>
        /// <c>[Slow Filter]</c>根据结构图元的实例参数<b>「结构用途」</b> 过滤出当前视图中的结构图元对象
        /// </summary>
        /// <param name="view"></param>
        /// <param name="structuralInstanceUsage"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this View view, StructuralInstanceUsage structuralInstanceUsage)
        {
            return view.GetElements(new StructuralInstanceUsageFilter(structuralInstanceUsage));
        }

        public static FilteredElementCollector GetElements(this View view, FamilySymbol familySymbol)
        {
            return view.GetElements(new FamilyInstanceFilter(view.Document, familySymbol.Id));
        }

        public static FilteredElementCollector GetElements(this View view, ElementId categoryId)
        {
            return view.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsNotElementType();
        }

        public static FilteredElementCollector GetElements(this View view, StructuralType structuralType)
        {
            return view.GetElements(new ElementStructuralTypeFilter(structuralType));
        }

        public static FilteredElementCollector GetElements(this View view, CurveElementType curveElementType)
        {
            return view.GetElements(new CurveElementFilter(curveElementType));
        }

        public static FilteredElementCollector GetElementTypes(this View view, ElementId categoryId)
        {
            return view.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsElementType();
        }

        public static FilteredElementCollector GetElementTypes(this View view, BuiltInCategory category)
        {
            return view.GetElements(new ElementCategoryFilter(category)).WhereElementIsElementType();
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
