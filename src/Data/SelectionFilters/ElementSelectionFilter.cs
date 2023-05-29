using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension.Data.SelectionFilters
{
    /// <summary>
    /// this class is used to filter elements where class is the same as input class
    /// this class is also used to filter where is loacted in assign level's elements
    /// 构件选择过滤器，可用于选择时，自定义条件过滤选择需要的元素构件
    /// </summary>
    /// <typeparam name="TElement">element target class</typeparam>
    public class ElementSelectionFilter<TElement> : ISelectionFilter where TElement : Element
    {
        private IEnumerable<ElementId> _levelIds = null;
        private readonly Func<TElement, bool> _filterCondition;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="levelIds">指定楼层的Id</param>
        /// <param name="filterCondition">自定义过滤条件</param>
        public ElementSelectionFilter(IEnumerable<ElementId> levelIds = null, Func<TElement, bool> filterCondition = null)
        {
            _levelIds = levelIds;
            _filterCondition = filterCondition;
        }

        public bool AllowElement(Element element)
        {
            if (element is TElement)
            {
                TElement result = element is TElement tElement ? tElement : null;
                if (_levelIds != null)
                {
                    if (element.LevelId != ElementId.InvalidElementId && _levelIds.FirstOrDefault(x => x == element.LevelId) == null)
                    {
                        result = null;
                    }
                }
                if (_filterCondition != null && !_filterCondition.Invoke(result))
                {
                    result = null;
                }
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            return false;

        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}