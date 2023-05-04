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
        /// <summary>
        /// Spatial element types
        /// </summary>
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
        /// Get elements by <see cref="Autodesk.Revit.DB.ElementFilter"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据元素过滤器过滤出符合条件的图元对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="filter">element filter</param>
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
        /// Get elements by <see cref="System.Type"/>
        /// which type support following types:<br/>
        /// <see cref="Autodesk.Revit.DB.Architecture.Room"/><br/>
        /// <see cref="Autodesk.Revit.DB.Architecture.RoomTag"/><br/>
        /// <see cref="Autodesk.Revit.DB.Area"/><br/>
        /// <see cref="Autodesk.Revit.DB.AreaTag"/><br/>
        /// <see cref="Autodesk.Revit.DB.Mechanical.Space"/><br/>
        /// <see cref="Autodesk.Revit.DB.Mechanical.SpaceTag"/><br/>
        /// </summary>
        /// <remarks>
        /// 根据类型（包括以上列出的类型）过滤出文档中的图元对象，该类型必须继承于 <see cref="Autodesk.Revit.DB.Element"/>,
        /// 但不是所有<see cref="Autodesk.Revit.DB.Element"/>派生的类都可以通过<see cref="Autodesk.Revit.DB.ElementClassFilter"/>进行过滤
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="type">type of element</param>
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
        /// Get elements by <see cref="Autodesk.Revit.DB.BuiltInCategory"/>
        /// <para><c>[Quick Filter]</c>根据内置类别过滤出文档中的图元对象</para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="category"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document,  BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsNotElementType();
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.Structure.StructuralWallUsage"/>
        /// <para><c>[Slow Filter]</c>根据结构墙体实例参数 <b>「结构用途」</b> 过滤出文档中的结构墙体图元对象</para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="structuralWallUsage"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralWallUsage structuralWallUsage)
        {
            return document.GetElements(new StructuralWallUsageFilter(structuralWallUsage));
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.Structure.StructuralMaterialType"/>
        /// </summary>
        /// <remarks>
        /// <c>[Slow Filter]</c>
        /// 根据结构族参数 <b>「用于模型行为的材质」</b> 过滤出文档中的结构图元对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="structuralMaterialType"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new StructuralMaterialTypeFilter(structuralMaterialType));
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.Structure.StructuralInstanceUsage"/>
        /// </summary>
        /// <remarks>
        /// <c>[Slow Filter]</c>
        /// 根据结构图元的实例参数<b>「结构用途」</b> 过滤出文档中的结构图元对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="structuralInstanceUsage"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralInstanceUsage structuralInstanceUsage)
        {
            return document.GetElements(new StructuralInstanceUsageFilter(structuralInstanceUsage));
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.FamilySymbol"/>
        /// </summary>
        /// <remarks>
        /// <c>[Slow Filter]</c>根据族类型过滤出文档中的族实例对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="familySymbol"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, FamilySymbol familySymbol)
        {
            return document.GetElements(new FamilyInstanceFilter(document, familySymbol.Id));
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.Level"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据标高过滤出文档中约束为当前标高的对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="level">host level</param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, Level level)
        {
            return document.GetElements(new ElementLevelFilter(level.Id));
        }

        /// <summary>
        /// Get elements by element category id , you can used <see cref="Constants.BuiltInParameters"/> to get parameter id
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据内置类别的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的图元对象,
        /// 扩展包提供了常量类型<see cref="Tuna.Revit.Extension.Constants.BuiltInCategories"/>可进行<c>Id</c>的调用
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="categoryId"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsNotElementType();
        }

        /// <summary>
        ///  Get structural elements by <see cref="Autodesk.Revit.DB.Structure.StructuralType"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据结构图元的实例属性 <c>StructuralType</c> 过滤出文档中的结构图元对象,同一个族类型从不同的按钮创建出来后的结构类型不同
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="structuralType"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralType structuralType)
        {
            return document.GetElements(new ElementStructuralTypeFilter(structuralType));
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.CurveElementType"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据线性类型获取图元对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="curveElementType"></param>
        /// <returns></returns>
        public static FilteredElementCollector GetElements(this Document document, CurveElementType curveElementType)
        {
            return document.GetElements(new CurveElementFilter(curveElementType));
        }

        /// <summary>
        /// Get elements by category <see cref="Autodesk.Revit.DB.ElementId"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据内置类别的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的图元类型对象,
        /// 扩展包提供了常量类型<see cref="Tuna.Revit.Extension.Constants.BuiltInCategories"/>可进行<c>Id</c>的调用
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="categoryId"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElementTypes(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsElementType();
        }

        /// <summary>
        /// Get elements by <see cref="Autodesk.Revit.DB.BuiltInCategory"/>
        /// </summary>
        /// <remarks>
        /// <c>[Quick Filter]</c>根据内置类别过滤出文档中的图元类型对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="category"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElementTypes(this Document document, BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsElementType();
        }

        /// <summary>
        /// Get elements types by <typeparamref name="T"/>
        /// </summary>
        /// <remarks>
        /// 根据类型过滤出文档中的图元类型对象
        /// </remarks>
        /// <typeparam name="T"><see cref="Autodesk.Revit.DB.ElementType"/></typeparam>
        /// <param name="document">revit document</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetElementTypes<T>(this Document document, Func<T, bool> predicate = null) where T : ElementType
        {
            return document.GetElements(predicate);
        }

        /// <summary>
        /// Get elements by <typeparamref name="T"/>
        /// </summary>
        /// <remarks>
        /// 根据类型过滤出文档中的图元对象
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">revit document</param>
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
        /// Get structual families by <see cref="Autodesk.Revit.DB.Structure.StructuralMaterialType"/>
        /// </summary>
        /// <remarks>
        /// <c>[Slow Filter]</c>
        /// 根据结构族参数 <b>「用于模型行为的材质」</b> 过滤出文档中的结构族对象
        /// </remarks>
        /// <param name="document">revit document</param>
        /// <param name="structuralMaterialType"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static IEnumerable<Family> GetStructualFamilies(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new FamilyStructuralMaterialTypeFilter(structuralMaterialType)).Cast<Family>();
        }

        /// <summary>
        /// Get family symbol elements by family <see cref="Autodesk.Revit.DB.ElementId"/> 
        /// <para><c>[Quick Filter]</c>根据族的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的族类型</para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="familyId"></param>
        /// <returns><see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static IEnumerable<FamilySymbol> GetFamilySymbols(this Document document, ElementId familyId)
        {
            return document.GetElements(new FamilySymbolFilter(familyId)).Cast<FamilySymbol>();
        }
    }
}
