///************************************************************************************
///   Author:十五
///   CretaeTime:2021/12/10 19:47:31
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
    /// <summary>
    /// revit element extension
    /// </summary>
    public static class ElementExtension
    {
        /// <summary>
        /// Get element <see cref="Parameter"/> by <see cref="Autodesk.Revit.DB.ElementId"/>
        /// </summary>
        /// <param name="element">host element</param>
        /// <param name="parameterId">target parameter id</param>
        /// <returns>element <see cref="Parameter"/></returns>
        public static Parameter GetParameter(this Element element, ElementId parameterId)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

            if (parameterId != ElementId.InvalidElementId)
            {
                foreach (Parameter item in element.Parameters)
                {
                    if (item.Id == parameterId)
                    {
                        return item;
                    }
                }
            }
            return default;
        }

        /// <summary>
        /// Get element type instances count in the document
        /// </summary>
        /// <typeparam name="T"><see cref="Autodesk.Revit.DB.Element"/> what is <see cref="Autodesk.Revit.DB.ElementType"/> typical corresponding pair </typeparam>
        /// <param name="types"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static IDictionary<ElementType, int> GetElementTypeInstancesCount<T>(this IEnumerable<ElementType> types) where T : Element
        {
            ArgumentNullExceptionUtils.ThrowIfNull(types);
         

            Dictionary<ElementType, int> result = new Dictionary<ElementType, int>();
            if (types.Any())
            {
                Dictionary<ElementId, int> counts = types.ToDictionary((e) => e?.Id, _ => 0);
                Document document = types.First().Document;
                var elements = document.GetElements<T>();
                foreach (var element in elements)
                {
                    var id = element.GetTypeId();

                    if (counts.TryGetValue(id, out int count))
                    {
                        counts[id] = count + 1;
                        continue;
                    }
                    counts.Add(id, 0);
                }
                result = counts.ToDictionary(p => document.GetElement(p.Key) as ElementType, p => p.Value);
            }
            return result;
        }


        /// <summary>
        /// Get element types which has instances in the document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<ElementType> WhereHasInstances<T>(this IEnumerable<ElementType> types) where T : Element
        {
            return types.GetElementTypeInstancesCount<T>().Where(p => p.Value > 0).ToDictionary(p => p.Key, p => p.Value).Keys.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static FilteredElementCollector TryGetIntersectElements(this Element element, View view)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);

            Document document = element.Document;
            BoundingBoxXYZ boundingBox = element.get_BoundingBox(view);
            Outline outline = new Outline(boundingBox.Min, boundingBox.Max);
            FilteredElementCollector elements = document.GetElements(new BoundingBoxIntersectsFilter(outline));
            if (elements.Any())
            {
                elements = document.GetElementIntersectsInCollector(elements.ToElementIds(), element);
            }
            return elements;
        }
    }
}
