/************************************************************************************
   Author:十五
   CretaeTime:2021/11/19 21:41:53
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;

#if Rvt_16|| Rvt_17
using Autodesk.Revit.Utility;
#else
using Autodesk.Revit.DB.Visual;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// revit document extension
/// </summary>
public static class DocumentExtension
{
    /// <summary>
    /// Is check element exist
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="document"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool ElementExist<T>(this Document document, Func<T, bool> predicate) where T : Element
    {
        return document.GetElements<T>().Any(predicate);
    }

    /// <summary>
    /// 通过 <see cref="Autodesk.Revit.DB.ElementId"/> 获取图元
    /// <para>Get element by <see cref="Autodesk.Revit.DB.ElementId"/></para>
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <param name="document"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static TElement GetElement<TElement>(this Document document, ElementId id) where TElement : Element
    {
        return document.GetElement(id) as TElement ?? throw new Exception($"target can not be convert to {typeof(TElement)}");
    }

    /// <summary>
    /// Get revit unique element name
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="document"></param>
    /// <param name="basicName"></param>
    /// <returns></returns>
    public static string GetUniqueName<T>(this Document document, string basicName) where T : Element
    {
        int number = 0;
        string name = basicName;
        while (document.ElementExist<T>(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase)))
        {
            number++;
            name = $"{basicName}({number})";
        }
        return name;
    }


    /// <summary>
    /// Get parameter filter element
    /// </summary>
    /// <param name="document"></param>
    /// <param name="name"></param>
    /// <param name="ids"></param>
    /// <param name="filterRule"></param>
    /// <returns></returns>
    public static ParameterFilterElement CreateParameterFilterElement(this Document document, string name, ICollection<ElementId> ids, FilterRule filterRule)
    {
#if Rvt_16 || Rvt_17 || Rvt_18
        return ParameterFilterElement.Create(document, name, ids, new List<FilterRule>() { filterRule });

#else
        ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
        return ParameterFilterElement.Create(document, name, ids, elementParameterFilter);
#endif
    }
}
