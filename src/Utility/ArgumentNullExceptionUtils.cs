/************************************************************************************
   Author:十五
   CretaeTime:2023/5/29 23:14:05
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// Exception utils
/// </summary>
internal static class ArgumentNullExceptionUtils
{
    /// <summary>
    /// Throw null exception if parameter is null
    /// </summary>
    /// <param name="parameter"></param>
    [DebuggerStepThrough]
    public static void ThrowIfNull(object parameter)
    {
        if (parameter == null)
        {
            throw new System.ArgumentNullException(nameof(parameter), $"{parameter} can not be null");
        }
    }

    /// <summary>
    /// Throw null exception if element is null or invalid
    /// </summary>
    /// <param name="element"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ThrowIfNullOrInvalid(Element element)
    {
        ThrowIfNull(element);
        if (!element.IsValidObject)
        {
            throw new System.ArgumentNullException(nameof(element), $"element must be valid object");
        }
    }

    /// <summary>
    /// Throw null exception if document is null or invalid
    /// </summary>
    /// <param name="document"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ThrowIfNullOrInvalid(Document document)
    {
        ThrowIfNull(document);
        if (!document.IsValidObject)
        {
            throw new System.ArgumentNullException(nameof(document), $"document must be valid object");
        }
    }

    /// <summary>
    /// Throw null exception if ui document is null or invalid
    /// </summary>
    /// <param name="document"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ThrowIfNullOrInvalid(UIDocument document)
    {
        ThrowIfNull(document);
        if (!document.IsValidObject)
        {
            throw new System.ArgumentNullException(nameof(document), $"ui document must be valid object");
        }
    }

    /// <summary>
    /// Throw null exception if revit color is null or invalid
    /// </summary>
    /// <param name="color"></param>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static void ThrowIfNullOrInvalid(Color color)
    {
        ThrowIfNull(color);
        if (!color.IsValid)
        {
            throw new System.ArgumentNullException(nameof(color), $"color must be valid object");
        }
    }
}