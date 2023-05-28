using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension.Data.SelectionFilters
{
    public static partial class SelectionFilterExtension
    {
        /// <summary>
        /// this class is used to filter element in link document object class is the same as input class 
        /// 链接构件过滤器，用于选择时过滤指定链接文件中的指定类型的构件
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        public class RevitLinkElementFilter<TElement> : ISelectionFilter where TElement : Element
        {
            private readonly IEnumerable<RevitLinkInstance> _linkInstances;
            private readonly Func<TElement, bool> _filterCondition;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="linkInstances">指定过滤的链接模型</param>
            /// <param name="filterCondition">自定义目标类别构件的过滤条件</param>
            public RevitLinkElementFilter(IEnumerable<RevitLinkInstance> linkInstances = null, Func<TElement, bool> filterCondition = null)
            {
                _linkInstances = linkInstances;
                _filterCondition = filterCondition;
            }


            public bool AllowElement(Element elem)
            {
                if (_linkInstances == null)
                {
                    return true;
                }
                else
                {
                    var resultLinkInstance = _linkInstances.Where(x => x.Id == elem.Id);
                    //指定选择的元素位于哪些链接模型中
                    if (resultLinkInstance != null && resultLinkInstance.Any())
                    {
                        return true;
                    }
                    return false;
                }
            }

            public bool AllowReference(Reference reference, XYZ position)
            {
                foreach (var linkInstance in _linkInstances)
                {
                    try
                    {
                        var element = linkInstance.GetLinkDocument()?.GetElement(reference.LinkedElementId) is TElement tElement ? tElement : null;
                        if (element == null && element.IsValidObject != true)
                        {
                            element = null;
                        }
                        if (_filterCondition != null && !_filterCondition.Invoke(element))
                        {
                            element = null;
                        }
                        if (element != null)
                        { return true; }
                        return false;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                return false;
            }
        }
    }
}