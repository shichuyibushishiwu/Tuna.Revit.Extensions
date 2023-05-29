using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension.Data.SelectionFilters
{
    /// <summary>
    /// this class is used to filter geometry object class is the same as input class
    /// this class is also used to filter geometry object where is belong to assign element class
    /// 几何选择过滤器，这个类用于选择时过滤指定类型的几何图形，且可指定目标构件
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TGeometryObject"></typeparam>
    public class GeometrySelectionFilter<TGeometryObject> : ISelectionFilter where TGeometryObject : GeometryObject
    {
        private readonly Document _document;
        private readonly BuiltInCategory _builtInCategory = BuiltInCategory.INVALID;
        private readonly IEnumerable<ElementId> _elementIds;
        private readonly Func<TGeometryObject, bool> _filterCondition;

        /// <summary>
        /// 构造函数，当不需要指定构件类型时使用
        /// </summary>
        /// <param name="document">当前文档</param>
        /// <param name="elementIds">限定构件</param>
        /// <param name="filterCondition">自定义条件限制选取的几何形状</param>
        public GeometrySelectionFilter(Document document, IEnumerable<ElementId> elementIds = null, Func<TGeometryObject, bool> filterCondition = null)
        {
            _document = document;
            _elementIds = elementIds;
            _filterCondition = filterCondition;
        }

        /// <summary>
        /// 构造函数，需要指定构件类型时使用
        /// </summary>
        /// <param name="document"></param>
        /// <param name="builtInCategory">指定构件类别</param>
        /// <param name="elementIds"></param>
        /// <param name="filterCondition"></param>
        public GeometrySelectionFilter(Document document, BuiltInCategory builtInCategory, IEnumerable<ElementId> elementIds = null, Func<TGeometryObject, bool> filterCondition = null)
        {
            _document = document;
            _builtInCategory = builtInCategory;
            _elementIds = elementIds;
            _filterCondition = filterCondition;
        }

        public bool AllowElement(Element element)
        {
            var result = element;
            if (_builtInCategory != BuiltInCategory.INVALID && element.Category != null)
            {
                if (element.Category.Id.IntegerValue != (int)_builtInCategory)
                {
                    result = null;
                }
            }
            if (_elementIds != null && _elementIds.FirstOrDefault(x => x == element.Id) == null)
            {
                result = null;
            }
            if (result == element)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            if (_document.GetElement(reference).GetGeometryObjectFromReference(reference) is TGeometryObject)
            {
                if (_filterCondition != null)
                {
                    var geometryObject = _document.GetElement(reference).GetGeometryObjectFromReference(reference);
                    if (geometryObject != null && geometryObject is TGeometryObject item)
                    {
                        return _filterCondition.Invoke(item);
                    }
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}