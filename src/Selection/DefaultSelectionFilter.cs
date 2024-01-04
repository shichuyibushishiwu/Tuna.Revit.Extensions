/************************************************************************************
   Author:十五
   CretaeTime:2023/4/6 0:25:10
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 默认的选择过滤器
/// <para>The default selection filter</para>
/// </summary>
public class DefaultSelectionFilter : ISelectionFilter
{
    private readonly Func<Element, bool> _elementPredicate;
    private readonly Func<(Reference Reference, XYZ XYZ), bool> _referencePredicate;

    /// <summary>
    /// <para>Definition of selection filter</para>
    /// </summary>
    /// <param name="elementPredicate">Allow element</param>
    /// <param name="referencePredicate">Allow reference</param>
    public DefaultSelectionFilter(Func<Element, bool> elementPredicate = null, Func<(Reference Reference, XYZ XYZ), bool> referencePredicate = null)
    {
        _elementPredicate = elementPredicate;
        _referencePredicate = referencePredicate;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="elem"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public virtual bool AllowElement(Element elem)
    {
        if (elem == null)
        {
            return false;
        }

        if (_elementPredicate != null)
        {
            return _elementPredicate(elem);
        }

        return true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="reference"><inheritdoc/></param>
    /// <param name="position"><inheritdoc/></param>
    /// <returns><inheritdoc/></returns>
    public virtual bool AllowReference(Reference reference, XYZ position)
    {
        if (reference == null || position == null)
        {
            return false;
        }

        if (_referencePredicate != null)
        {
            return _referencePredicate((reference, position));
        }

        return true;
    }
}
