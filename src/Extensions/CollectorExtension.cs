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
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
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
        /// This is a function which used to new <see cref="Autodesk.Revit.DB.FilteredElementCollector"/> instance
        /// </summary>
        /// <param name="document"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        /// <exception cref="Autodesk.Revit.Exceptions.ArgumentNullException"></exception>
        internal static FilteredElementCollector GetElements(this Document document)
        {
            if (!document!.IsValidObject)
            {
                throw new ArgumentNullException(nameof(document), "document is null or invalid object");
            }
            return new FilteredElementCollector(document);
        }

        /// <summary>
        /// This is a function which used to get elements 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="filter"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter can not be null");
            }
            return document.GetElements().WherePasses(filter);
        }

        /// <summary>
        /// This is a function which used to get elements which type support following types:<br/>
        /// <see cref="Autodesk.Revit.DB.Architecture.Room"/><br/>
        /// <see cref="Area"/><br/>
        /// <see cref="Space"/><br/>
        /// <see cref="RoomTag"/><br/>
        /// <see cref="AreaTag"/><br/>
        /// <see cref="SpaceTag"/><br/>
        /// </summary>
        /// <param name="document"></param>
        /// <param name="type"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, Type type)
        {
            if (!type.IsSubclassOf(typeof(Element)))
            {
                throw new ArgumentException("type is not a subclass of element");
            }

            if (type.IsSubclassOf(typeof(SpatialElement)))
            {
                if (type == typeof(Room))
                {
                    return document.GetElements(new RoomFilter());
                }
                else if (type == typeof(Area))
                {
                    return document.GetElements(new AreaFilter());
                }
                else if (type == typeof(Space))
                {
                    return document.GetElements(new SpaceFilter());
                }
            }
            else if (type.IsSubclassOf(typeof(SpatialElementTag)))
            {
                if (type == typeof(RoomTag))
                {
                    return document.GetElements(new RoomTagFilter());
                }
                else if (type == typeof(AreaTag))
                {
                    return document.GetElements(new AreaTagFilter());
                }
                else if (type == typeof(SpaceTag))
                {
                    return document.GetElements(new SpaceTagFilter());
                }
            }


            return document.GetElements(new ElementClassFilter(type));
        }

        /// <summary>
        /// This is a function which used to get elements 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="category"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsNotElementType();
        }

        /// <summary>
        /// Get elements by element category id , you can used <see cref="Constants.BuiltInParameters"/> to get parameter id
        /// </summary>
        /// <param name="document"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsNotElementType();
        }


        /// <summary>
        /// This is a function which used to get elements 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="predicate"></param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
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
        /// This is a function which used to get elements types
        /// </summary>
        /// <typeparam name="T"><see cref="Autodesk.Revit.DB.ElementType"/></typeparam>
        /// <param name="document"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElementTypes<T>(this Document document, Func<T, bool> predicate = null) where T : ElementType
        {
            return document.GetElements(predicate);
        }
    }
}
