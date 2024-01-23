/************************************************************************************
   Author:十五
   CretaeTime:2022/11/29 0:08:10
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit selection extensions
/// </summary>
public static class SelectionExtension
{
    /// <summary>
    /// 当前方法用于提示用户选择对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="selectionFilter">选择过滤器</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static SelectionResult<Reference> SelectObject(this UIDocument uiDocument, ObjectType objectType, ISelectionFilter selectionFilter = null, string prompt = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(uiDocument);

        SelectionResult<Reference> selectionResult = new SelectionResult<Reference>();
        try
        {
            selectionFilter ??= new DefaultSelectionFilter();

            selectionResult.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickObject(objectType, selectionFilter)
                : uiDocument.Selection.PickObject(objectType, selectionFilter, prompt);

            selectionResult.Succeeded = true;
            selectionResult.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = exception.Message;
            throw exception;
        }
        return selectionResult;
    }

    /// <summary>
    /// 当前方法用于提示用户选择对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Reference> SelectObject(this UIDocument uiDocument, ObjectType objectType, Func<Element, bool> elementPredicate, string prompt = null)
    {
        return uiDocument.SelectObject(objectType, new DefaultSelectionFilter(elementPredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="referencePredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Reference> SelectObject(this UIDocument uiDocument, ObjectType objectType, Func<(Reference Reference, XYZ XYZ), bool> referencePredicate, string prompt = null)
    {
        return uiDocument.SelectObject(objectType, new DefaultSelectionFilter(referencePredicate: referencePredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="referencePredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Reference> SelectObject(this UIDocument uiDocument, ObjectType objectType, Func<Element, bool> elementPredicate, Func<(Reference Reference, XYZ XYZ), bool> referencePredicate, string prompt = null)
    {
        return uiDocument.SelectObject(objectType, new DefaultSelectionFilter(elementPredicate, referencePredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, Func<Element, bool> elementPredicate, string prompt = null)
    {
        SelectionResult<Reference> result = uiDocument.SelectObject(ObjectType.Element, elementPredicate, prompt);
        return new SelectionResult<Element>()
        {
            Message = result.Message,
            Succeeded = result.Succeeded,
            Value = result.Succeeded ? uiDocument.Document.GetElement(result.Value) : default(Element)
        };
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategory">要选择的图元类别</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElement(element => element.Category?.Id == new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, string prompt = null)
    {
        return uiDocument.SelectElement(_ => true, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="selectionFilter">选择过滤器</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, ObjectType objectType, ISelectionFilter selectionFilter = null, string prompt = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(uiDocument);
        SelectionResult<IList<Reference>> selectionResult = new SelectionResult<IList<Reference>>();
        try
        {
            selectionFilter ??= new DefaultSelectionFilter();

            selectionResult.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickObjects(objectType, selectionFilter)
                : uiDocument.Selection.PickObjects(objectType, selectionFilter, prompt);

            selectionResult.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = exception.Message;
            throw exception;
        }
        return selectionResult;
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="referencePredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, ObjectType objectType, Func<Element, bool> elementPredicate, Func<(Reference Reference, XYZ XYZ), bool> referencePredicate, string prompt = null)
    {
        return uiDocument.SelectObjects(objectType, new DefaultSelectionFilter(elementPredicate, referencePredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, ObjectType objectType, Func<Element, bool> elementPredicate, string prompt = null)
    {
        return uiDocument.SelectObjects(objectType, new DefaultSelectionFilter(elementPredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="referencePredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, ObjectType objectType, Func<(Reference Reference, XYZ XYZ), bool> referencePredicate, string prompt = null)
    {
        return uiDocument.SelectObjects(objectType, new DefaultSelectionFilter(referencePredicate: referencePredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="elementPredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, Func<Element, bool> elementPredicate, string prompt = null)
    {
        SelectionResult<IList<Reference>> result = uiDocument.SelectObjects(ObjectType.Element, new DefaultSelectionFilter(elementPredicate), prompt);
        return new SelectionResult<IEnumerable<Element>>()
        {
            Message = result.Message,
            Succeeded = result.Succeeded,
            Value = result.Succeeded ? result.Value.Select(referebce => uiDocument.Document.GetElement(referebce)) : Enumerable.Empty<Element>()
        };
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategory">要选择的图元类别</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElements(element => element.Category?.Id == new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, string prompt = null)
    {
        return uiDocument.SelectElements(_ => true, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to pick a point on the active work plane , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="snapTypes">点的类型</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<XYZ> SelectPoint(this UIDocument uiDocument, ObjectSnapTypes snapTypes, string prompt = null)
    {
        SelectionResult<XYZ> result = new SelectionResult<XYZ>();
        try
        {
            result.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickPoint(snapTypes)
                : uiDocument.Selection.PickPoint(snapTypes, prompt);

            result.Succeeded = true;
            result.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            result.Succeeded = false;
            result.Message = "Canceled";
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.Message = e.Message;
            throw e;
        }
        return result;
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to pick a point on the active work plane , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<XYZ> SelectPoint(this UIDocument uiDocument, string prompt = null)
    {
        SelectionResult<XYZ> result = new SelectionResult<XYZ>();
        try
        {
            result.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickPoint()
                : uiDocument.Selection.PickPoint(prompt);

            result.Succeeded = true;
            result.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            result.Succeeded = false;
            result.Message = "Canceled";
        }
        catch (Exception e)
        {
            result.Succeeded = false;
            result.Message = e.Message;
            throw e;
        }
        return result;
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="selectionFilter">选择过滤器</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, ISelectionFilter selectionFilter = null, string prompt = null)
    {
        SelectionResult<IList<Element>> selectionResult = new SelectionResult<IList<Element>>();
        try
        {
            selectionFilter ??= new DefaultSelectionFilter();

            selectionResult.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickElementsByRectangle(selectionFilter)
                : uiDocument.Selection.PickElementsByRectangle(selectionFilter, prompt);

            selectionResult.Succeeded = true;
            selectionResult.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = exception.Message;
            throw exception;
        }

        return selectionResult;
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="elementPredicate">对要选择的图元进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, Func<Element, bool> elementPredicate, string prompt = null)
    {
        return uiDocument.SelectElementsByRectangle(new DefaultSelectionFilter(elementPredicate), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategory">要选择的图元对象</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElementsByRectangle(element => element.Category?.Id == new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, string prompt = null)
    {
        return uiDocument.SelectElementsByRectangle(_ => true, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户进行框选确定选择框的范围，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// </summary>
    /// <param name="uIDocument">要操作的文档</param>
    /// <param name="pickBoxStyle">盒子的类型</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    public static SelectionResult<PickedBox> SelectBox(this UIDocument uIDocument, PickBoxStyle pickBoxStyle = PickBoxStyle.Crossing, string prompt = null)
    {
        SelectionResult<PickedBox> selectionResult = new SelectionResult<PickedBox>();
        try
        {
            PickedBox pickBox = string.IsNullOrWhiteSpace(prompt) ? uIDocument.Selection.PickBox(pickBoxStyle) : uIDocument.Selection.PickBox(pickBoxStyle, prompt);

            selectionResult.Succeeded = true;
            selectionResult.Message = "Succeeded";
            selectionResult.Value = pickBox;
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.Succeeded = false;
            selectionResult.Message = "Canceled";
            throw exception;
        }

        return selectionResult;
    }
}
