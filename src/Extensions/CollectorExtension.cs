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
using Tuna.Revit.Extension;
using Tuna.Revit.Extension.Data;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit element filters extension
    /// </summary>
    public static class CollectorExtension
    {
        /// <summary>
        /// Spatial element types
        /// </summary>
        internal static readonly Dictionary<Type, Type> FilterTypes = new Dictionary<Type, Type>()
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
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        /// <exception cref="Autodesk.Revit.Exceptions.ArgumentNullException"></exception>
        internal static FilteredElementCollector GetElements(this Document document)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
            return new FilteredElementCollector(document);
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据元素过滤器过滤出符合条件的图元对象
        /// <para>Get elements by <see cref="Autodesk.Revit.DB.ElementFilter"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="filter">element filter</param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementFilter filter)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(filter);
            return GetElements(document).WherePasses(filter);
        }

        /// <summary>
        /// 根据类型（包括以下列出的类型）过滤出文档中的图元对象，该类型必须继承于 <see cref="Autodesk.Revit.DB.Element"/>,
        /// 但不是所有<see cref="Autodesk.Revit.DB.Element"/>派生的类都可以通过<see cref="Autodesk.Revit.DB.ElementClassFilter"/>进行过滤
        /// <para>Get the element in the document which type is subclass of <see cref="Autodesk.Revit.DB.Element"/></para>
        /// <list type="bullet">
        /// <item><see cref="Autodesk.Revit.DB.Architecture.Room"/></item>
        /// <item><see cref="Autodesk.Revit.DB.Architecture.RoomTag"/></item>
        /// <item><see cref="Autodesk.Revit.DB.Area"/></item>
        /// <item><see cref="Autodesk.Revit.DB.AreaTag"/></item>
        /// <item><see cref="Autodesk.Revit.DB.Mechanical.Space"/></item>
        /// <item><see cref="Autodesk.Revit.DB.Mechanical.SpaceTag"/></item>
        /// </list>
        /// </summary>
        /// <remarks>如果是上面列表中的类型，将不会使用<see cref="Autodesk.Revit.DB.ElementClassFilter"/>，而是选择慢速过滤器</remarks>
        /// <param name="document">revit document</param>
        /// <param name="type">type of element</param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        /// <exception cref="System.ArgumentException">类型必须继承于<see cref="Autodesk.Revit.DB.Element"/></exception>
        public static FilteredElementCollector GetElements(this Document document, Type type)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(type);
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
        /// 根据类型过滤出文档中的图元对象，该类型必须继承于<see cref="Autodesk.Revit.DB.Element"/>
        /// <para>Get the element in the document which type is subclass of <see cref="Autodesk.Revit.DB.Element"/></para>
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="type">element type</param>
        /// <param name="types">element types</param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, Type type, params Type[] types)
        {
            if (types.Length == 0)
            {
                return document.GetElements(type);
            }
            List<Type> allTypes = types.ToList();
            allTypes.Add(type);
            return document.GetElements(new ElementMulticlassFilter(allTypes));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别过滤出文档中的图元对象
        /// <para>Get elements in the document by <see cref="Autodesk.Revit.DB.BuiltInCategory"/></para>
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="category">内置类别<see cref="Autodesk.Revit.DB.BuiltInCategory"/></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsNotElementType();
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别过滤出文档中的图元对象
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="category"></param>
        /// <param name="categories"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, BuiltInCategory category, params BuiltInCategory[] categories)
        {
            if (categories.Length == 0)
            {
                return document.GetElements(category);
            }
            List<BuiltInCategory> allCategories = categories.ToList();
            allCategories.Add(category);
            return document.GetElements(new ElementMulticategoryFilter(allCategories)).WhereElementIsNotElementType();
        }

        /// <summary>
        /// <c>[Slow Filter]</c>根据结构墙体实例参数 <b>「结构用途」</b> 过滤出文档中的结构墙体图元对象
        /// <para>Get structural walls in the document by <see cref="Autodesk.Revit.DB.Structure.StructuralWallUsage"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="structuralWallUsage"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralWallUsage structuralWallUsage)
        {
            return document.GetElements(new StructuralWallUsageFilter(structuralWallUsage));
        }

        /// <summary>
        /// <c>[Slow Filter]</c>根据结构族内部的参数 <b>「用于模型行为的材质」</b> 过滤出文档中的结构图元对象
        ///<para> Get structural elements in the document by <see cref="Autodesk.Revit.DB.Structure.StructuralMaterialType"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="structuralMaterialType"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new StructuralMaterialTypeFilter(structuralMaterialType));
        }

        /// <summary>
        /// <c>[Slow Filter]</c>根据结构图元的实例参数<b>「结构用途」</b> 过滤出文档中的结构图元对象
        /// <para>Get elements by <see cref="Autodesk.Revit.DB.Structure.StructuralInstanceUsage"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="structuralInstanceUsage"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralInstanceUsage structuralInstanceUsage)
        {
            return document.GetElements(new StructuralInstanceUsageFilter(structuralInstanceUsage));
        }

        /// <summary>
        /// <c>[Slow Filter]</c>根据族类型过滤出文档中的族实例对象
        /// <para>Get elements by <see cref="Autodesk.Revit.DB.FamilySymbol"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="familySymbol"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, FamilySymbol familySymbol)
        {
            return document.GetElements(new FamilyInstanceFilter(document, familySymbol.Id));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据标高过滤出文档中约束为当前标高的对象
        /// <para>Get elements by <see cref="Autodesk.Revit.DB.Level"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="level">host level</param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, Level level)
        {
            return document.GetElements(new ElementLevelFilter(level.Id));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的图元对象,
        /// 扩展包提供了常量类型<see cref="Tuna.Revit.Extension.Constants.BuiltInCategories"/>可进行<c>Id</c>的调用
        /// <para>Get elements in the document by element category id , you can used <see cref="Constants.BuiltInParameters"/> to get parameter id</para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="categoryId"><see cref="Autodesk.Revit.DB.ElementId"/></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsNotElementType();
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据<see cref="Autodesk.Revit.DB.FamilyInstance"/> 的属性 <c>StructuralType</c> 过滤出文档中的结构图元对象
        /// <para>Get structural elements in the document by <see cref="Autodesk.Revit.DB.Structure.StructuralType"/></para>
        /// </summary>
        /// <remarks>同一个族类型从不同的命令创建出来后的结构类型不同</remarks>
        /// <param name="document">revit document</param>
        /// <param name="structuralType"><see cref="Autodesk.Revit.DB.Structure.StructuralType"/></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, StructuralType structuralType)
        {
            return document.GetElements(new ElementStructuralTypeFilter(structuralType));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据线性类型获取文档中图元对象
        /// <para>Get curve elements by <see cref="Autodesk.Revit.DB.CurveElementType"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="curveElementType"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElements(this Document document, CurveElementType curveElementType)
        {
            return document.GetElements(new CurveElementFilter(curveElementType));
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的图元类型对象,
        /// 扩展包提供了常量类型<see cref="Tuna.Revit.Extension.Constants.BuiltInCategories"/>可进行<c>Id</c>的调用
        /// <para>Get elements by category <see cref="Autodesk.Revit.DB.ElementId"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="categoryId"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElementTypes(this Document document, ElementId categoryId)
        {
            return document.GetElements(new ElementCategoryFilter(categoryId)).WhereElementIsElementType();
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据内置类别过滤出文档中的图元类型对象
        /// <para>Get element types in the document by <see cref="Autodesk.Revit.DB.BuiltInCategory"/></para>
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="category">Revit内置的类别</param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static FilteredElementCollector GetElementTypes(this Document document, BuiltInCategory category)
        {
            return document.GetElements(new ElementCategoryFilter(category)).WhereElementIsElementType();
        }

        /// <summary>
        /// 根据类型过滤出文档中的图元类型对象
        /// <para>Get elements types by <typeparamref name="T"/></para>
        /// </summary>
        /// <typeparam name="T"><see cref="Autodesk.Revit.DB.ElementType"/></typeparam>
        /// <param name="document">revit document</param>
        /// <param name="predicate"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<T> GetElementTypes<T>(this Document document, Func<T, bool> predicate = null) where T : ElementType
        {
            return document.GetElements(predicate);
        }

        /// <summary>
        /// 根据类型过滤出文档中的图元对象
        /// <para>Get the element in the document which type is <typeparamref name="T"/></para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">revit document</param>
        /// <param name="predicate"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="IEnumerable{T}"/></returns>
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
        /// <c>[Slow Filter]</c>
        /// 根据结构族参数 <b>「用于模型行为的材质」</b> 过滤出文档中的结构族对象
        /// <para>Get structual families by <see cref="Autodesk.Revit.DB.Structure.StructuralMaterialType"/></para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="structuralMaterialType"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static IEnumerable<Family> GetStructualFamilies(this Document document, StructuralMaterialType structuralMaterialType)
        {
            return document.GetElements(new FamilyStructuralMaterialTypeFilter(structuralMaterialType)).Cast<Family>();
        }

        /// <summary>
        /// <c>[Quick Filter]</c>根据族的<see cref="Autodesk.Revit.DB.ElementId"/>过滤出文档中的族类型
        /// <para>Get family symbol elements by family <see cref="Autodesk.Revit.DB.ElementId"/> </para>
        /// </summary>
        /// <param name="document">revit document</param>
        /// <param name="familyId"></param>
        /// <returns>从文档中查询到的图元集合 <see cref="Autodesk.Revit.DB.FilteredElementCollector"/></returns>
        public static IEnumerable<FamilySymbol> GetFamilySymbols(this Document document, ElementId familyId)
        {
            return document.GetElements(new FamilySymbolFilter(familyId)).Cast<FamilySymbol>();
        }

        /// <summary>
        /// 获取文档中的所有三维图形图元
        ///  <para>Get all of the 3d model elements from target document</para>
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="predicate">predicate</param>
        /// <returns>从文档中查询到的图元集合 <see cref="IEnumerable{T}"/></returns>
        public static IEnumerable<Element> GetGraphicElements(this Document document, Func<Element, bool> predicate)
        {
            var elements = document.GetElements(new ElementIsElementTypeFilter(true))
                .ToElements()
                .Where(element => element.Category != null && element.Category.HasMaterialQuantities);
            if (predicate != null)
            {
                elements = elements.Where(predicate);
            }
            return elements;
        }
    }
}
