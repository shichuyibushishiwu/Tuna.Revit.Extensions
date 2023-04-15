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
    public static partial class CollectorExtension
    {
        private static readonly Dictionary<Type, Type> FilterTypes = new Dictionary<Type, Type>()
        {
            [typeof(Room)] = typeof(RoomFilter),
            [typeof(RoomTag)] = typeof(RoomTagFilter),
            [typeof(Area)] = typeof(AreaFilter),
            [typeof(AreaTag)] = typeof(AreaTagFilter),
            [typeof(Space)] = typeof(SpaceFilter),
            [typeof(SpaceTag)] = typeof(SpaceTagFilter),
        };

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
        /// <see cref="Autodesk.Revit.DB.Architecture.RoomTag"/><br/>
        /// <see cref="Autodesk.Revit.DB.Area"/><br/>
        /// <see cref="Autodesk.Revit.DB.AreaTag"/><br/>
        /// <see cref="Autodesk.Revit.DB.Mechanical.Space"/><br/>
        /// <see cref="Autodesk.Revit.DB.Mechanical.SpaceTag"/><br/>
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

            if (FilterTypes.TryGetValue(type, out Type filterType))
            {
                return document.GetElements(Activator.CreateInstance(filterType) as ElementFilter);
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

        public static FilteredElementCollector GetElements(this Document document, StructuralWallUsage structuralWallUsage)
        {
            return document.GetElements(new StructuralWallUsageFilter(structuralWallUsage));
        }

        public static FilteredElementCollector GetElements(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new StructuralMaterialTypeFilter(structuralMaterialType));
        }

        public static FilteredElementCollector GetElements(this Document document, StructuralInstanceUsage structuralInstanceUsage)
        {
            return document.GetElements(new StructuralInstanceUsageFilter(structuralInstanceUsage));
        }

        public static FilteredElementCollector GetElements(this Document document, FamilySymbol familySymbol)
        {
            return document.GetElements(new FamilyInstanceFilter(document, familySymbol.Id));
        }

        public static FilteredElementCollector GetElements(this Document document, Level level)
        {
            return document.GetElements(new ElementLevelFilter(level.Id));
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

        public static FilteredElementCollector GetElements(this Document document, StructuralType structuralType)
        {
            return document.GetElements(new ElementStructuralTypeFilter(structuralType));
        }

        public static FilteredElementCollector GetElementTypes(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsElementType();
        }

        public static FilteredElementCollector GetElementTypes(this Document document, BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsElementType();
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

        public static FilteredElementCollector GetStructualFamilies(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new FamilyStructuralMaterialTypeFilter(structuralMaterialType));
        }

    }
}
