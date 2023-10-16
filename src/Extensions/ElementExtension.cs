/************************************************************************************
   Author:十五
   CretaeTime:2021/12/10 19:47:31
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/



using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuna.Revit.Extension;

/// <summary>
/// revit element extension
/// </summary>
public static class ElementExtension
{
    /// <summary>
    /// 获取图元的参数
    /// <para>Get element <see cref="Parameter"/> by <see cref="Autodesk.Revit.DB.ElementId"/></para>
    /// </summary>
    /// <param name="element">host element</param>
    /// <param name="parameterId">target parameter id</param>
    /// <returns>element <see cref="Parameter"/></returns>
    public static Parameter GetParameter(this Element element, ElementId parameterId)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);
        return parameterId != ElementId.InvalidElementId ? element.Parameters.ToList(p => p.Id == parameterId).First() : default;
    }

    /// <summary>
    /// 获取类型为 <typeparamref name="T"/> 的图元类型和实例的数量
    /// <para>Get element instances count in the document</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="document"></param>
    /// <returns></returns>
    public static IDictionary<ElementType, int> GetElementTypesAndInstancesCount<T>(this Document document) where T : HostObject
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        Dictionary<ElementId, int> amount = new Dictionary<ElementId, int>();
        var elements = document.GetElements<T>();
        foreach (var element in elements)
        {
            ElementId id = element.GetTypeId();

            if (amount.TryGetValue(id, out int count))
            {
                amount[id] = count + 1;
                continue;
            }
            amount.Add(id, 1);
        }

        return amount.ToDictionary(p => document.GetElement(p.Key) as ElementType, p => p.Value);
    }

    /// <summary>
    /// 统计类型在文档中存在的实例的数量
    /// </summary>
    /// <typeparam name="T">类型所对应的实力的类</typeparam>
    /// <param name="elementTypes"></param>
    /// <returns></returns>
    public static IDictionary<ElementType, int> Counts<T>(this IEnumerable<ElementType> elementTypes) where T : HostObject
    {
        Dictionary<ElementId, int> amount = elementTypes.ToDictionary(t => t.Id, _ => 0);
        if (!elementTypes.Any())
        {
            return new Dictionary<ElementType, int>();
        }

        Document document = elementTypes.FirstOrDefault().Document;
        IEnumerable<T> elements = document.GetElements<T>();
        foreach (var element in elements)
        {
            ElementId id = element.GetTypeId();
            if (amount.TryGetValue(id, out int count))
            {
                amount[id] = count + 1;
                continue;
            }
        }
        return amount.ToDictionary(p => document.GetElement(p.Key) as ElementType, p => p.Value);
    }

    /// <summary>
    /// 获取具有图元实例的图元类型
    /// <para>Get the elements in the document whose has instances exist</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="document"></param>
    /// <returns>从文档中查询到的图元集合 <see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<ElementType> GetElementTypesWhereHasInstances<T>(this Document document) where T : HostObject
    {
        return document.GetElementTypesAndInstancesCount<T>().Where(p => p.Value > 0).ToDictionary(p => p.Key, p => p.Value).Keys.ToList();
    }

    /// <summary>
    /// 尝试去获取文档中与图元相交的对象
    /// <para>Try to get elements in the document which intersects with the primitive</para>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="view"></param>
    /// <returns>图元所在的文档中与图元相交的对象</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static FilteredElementCollector TryGetIntersectElements(this Element element, View view)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(view);

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
