/************************************************************************************
   Author:十五
   CretaeTime:2023/4/6 0:41:45
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using System;
using Tuna.Revit.Extension;

namespace Tuna.Revit.Extension;

/// <summary>
/// 和Revit进行交互后的结果
/// <para>Revit selection result</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public class SelectionResult<T>
{
    /// <summary>
    /// message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// result
    /// </summary>
    public T Value { get; internal set; } = default(T);

    /// <summary>
    /// selction state
    /// </summary>
    public SelectionStatus SelectionStatus { get; set; }

    /// <summary>
    /// exception
    /// </summary>
    public Exception Exception { get; internal set; }

    /// <summary>
    /// Has exception
    /// </summary>
    public bool HasException => Exception != null;
}
