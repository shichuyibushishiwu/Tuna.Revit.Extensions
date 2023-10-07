/************************************************************************************
   Author:十五
   CretaeTime:2023/4/6 0:41:45
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

namespace Tuna.Revit.Extension;

/// <summary>
/// 和Revit进行交互后的结果
/// <para>Revit selection result</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public class SelectionResult<T>
{
    /// <summary>
    /// succeeded
    /// </summary>
    public SelectionResult()
    {
        Succeeded = true;
    }

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
    public bool Succeeded { get; set; }
}
