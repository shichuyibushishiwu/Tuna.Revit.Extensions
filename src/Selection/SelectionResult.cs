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
/// 定义的类用于保存和Revit进行交互后的结果
/// <para>Revit selection result</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public class SelectionResult<T> : TunaAPIResult
{
    /// <summary>
    /// message
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// result
    /// </summary>
    public T? Value { get; internal set; }

    /// <summary>
    /// selction state
    /// </summary>
    public SelectionStatus SelectionStatus { get; set; }
}
