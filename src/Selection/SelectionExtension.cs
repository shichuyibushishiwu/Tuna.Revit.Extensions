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
using System.Diagnostics;
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
    [DebuggerStepThrough]
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

            selectionResult.SelectionStatus = SelectionStatus.Succeeded;
            selectionResult.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.SelectionStatus = SelectionStatus.Cancelled;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.SelectionStatus = SelectionStatus.Failed;
            selectionResult.Message = exception.Message;
            selectionResult.Exception = exception;
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, Func<Element, bool> elementPredicate, string prompt = null)
    {
        SelectionResult<Reference> result = uiDocument.SelectObject(ObjectType.Element, elementPredicate, prompt);
        return new SelectionResult<Element>()
        {
            Message = result.Message,
            SelectionStatus = result.SelectionStatus,
            Value = result.SelectionStatus == SelectionStatus.Succeeded ? uiDocument.Document.GetElement(result.Value) : default
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
    [DebuggerStepThrough]
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElement(new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategoryId">要选择的图元类别的 <see cref="Autodesk.Revit.DB.ElementId"/></param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, ElementId builtInCategoryId, string prompt = null)
    {
        return uiDocument.SelectElement(element => element.Category?.Id == builtInCategoryId, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<Element> SelectElement(this UIDocument uiDocument, string prompt = null)
    {
        return uiDocument.SelectElement(_ => true, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="elementPredicate">给用户的提示</param>
    /// <param name="prompt"></param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static SelectionResult<T> SelectElement<T>(this UIDocument uiDocument, Func<T, bool> elementPredicate = null, string prompt = null) where T : Element
    {
        SelectionResult<Element> result = uiDocument.SelectElement(element =>
        {
            if (element is not T targetElement)
            {
                return false;
            }

            if (elementPredicate != null)
            {
                return elementPredicate(targetElement);
            }

            return true;
        }, prompt);

        return new SelectionResult<T>()
        {
            Exception = result.Exception,
            Message = result.Message,
            SelectionStatus = result.SelectionStatus,
            Value = result.SelectionStatus == SelectionStatus.Succeeded ? result.Value as T : default
        };
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
    [DebuggerStepThrough]
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
            selectionResult.SelectionStatus = SelectionStatus.Succeeded;
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.SelectionStatus = SelectionStatus.Cancelled;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.SelectionStatus = SelectionStatus.Failed;
            selectionResult.Message = exception.Message;
            selectionResult.Exception = exception;
        }

        return selectionResult;
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个对象，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="objectType">选择的对象类型</param>
    /// <param name="pPreSelected">预选择的对象</param>
    /// <param name="prompt">给用户的提示</param>
    /// <param name="selectionFilter">选择过滤器</param>
    /// <returns>用户选择的结果</returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    [DebuggerStepThrough]
    public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, ObjectType objectType, List<Reference> pPreSelected, string prompt, ISelectionFilter selectionFilter = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(uiDocument);
        ArgumentNullExceptionUtils.ThrowIfNull(pPreSelected);
        ArgumentNullExceptionUtils.ThrowIfNull(prompt);

        SelectionResult<IList<Reference>> selectionResult = new SelectionResult<IList<Reference>>();
        try
        {
            selectionFilter ??= new DefaultSelectionFilter();
            uiDocument.Selection.PickObjects(objectType, selectionFilter, prompt, pPreSelected);

            selectionResult.Message = "Succeeded";
            selectionResult.SelectionStatus = SelectionStatus.Succeeded;
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.SelectionStatus = SelectionStatus.Cancelled;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.SelectionStatus = SelectionStatus.Failed;
            selectionResult.Message = exception.Message;
            selectionResult.Exception = exception;
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, Func<Element, bool> elementPredicate, string prompt = null)
    {
        SelectionResult<IList<Reference>> result = uiDocument.SelectObjects(ObjectType.Element, new DefaultSelectionFilter(elementPredicate), prompt);
        return new SelectionResult<IEnumerable<Element>>()
        {
            Message = result.Message,
            SelectionStatus = result.SelectionStatus,
            Value = result.SelectionStatus == SelectionStatus.Succeeded ? result.Value.Select(reference => uiDocument.Document.GetElement(reference)) : Enumerable.Empty<Element>()
        };
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="type">要选择的图元类型</param>
    /// <param name="elementPredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, Type type, Func<Element, bool> elementPredicate = null, string prompt = null)
    {
        return uiDocument.SelectElements(e =>
        {
            if (e.GetType() != type)
            {
                return false;
            }

            if (elementPredicate != null)
            {
                return elementPredicate(e);
            }

            return true;
        }, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="elementPredicate">对要选择的引用进行筛选</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<IEnumerable<T>> SelectElements<T>(this UIDocument uiDocument, Func<T, bool> elementPredicate = null, string prompt = null) where T : Element
    {
        SelectionResult<IEnumerable<Element>> result = uiDocument.SelectElements(element =>
        {
            if (element is not T targetElement)
            {
                return false;
            }

            if (elementPredicate != null)
            {
                return elementPredicate(targetElement);
            }

            return true;
        }, prompt);

        return new SelectionResult<IEnumerable<T>>()
        {
            Exception = result.Exception,
            Message = result.Message,
            SelectionStatus = result.SelectionStatus,
            Value = result.SelectionStatus == SelectionStatus.Succeeded ? result.Value.Cast<T>() : Enumerable.Empty<T>()
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
    [DebuggerStepThrough]
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElements(new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategoryId">要选择的图元类别的<see cref="Autodesk.Revit.DB.ElementId"/></param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<IEnumerable<Element>> SelectElements(this UIDocument uiDocument, ElementId builtInCategoryId, string prompt = null)
    {
        return uiDocument.SelectElements(element => element.Category?.Id == builtInCategoryId, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择多个图元，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple objects , if the user cancels the operation (for example, through ESC), the method will return failed result. otherwise true</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
    public static SelectionResult<XYZ> SelectPoint(this UIDocument uiDocument, ObjectSnapTypes snapTypes, string prompt = null)
    {
        SelectionResult<XYZ> result = new SelectionResult<XYZ>();
        try
        {
            result.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickPoint(snapTypes)
                : uiDocument.Selection.PickPoint(snapTypes, prompt);

            result.SelectionStatus = SelectionStatus.Succeeded;
            result.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            result.SelectionStatus = SelectionStatus.Cancelled;
            result.Message = "Canceled";
        }
        catch (Exception e)
        {
            result.SelectionStatus = SelectionStatus.Failed;
            result.Message = e.Message;
            result.Exception = e;
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
    [DebuggerStepThrough]
    public static SelectionResult<XYZ> SelectPoint(this UIDocument uiDocument, string prompt = null)
    {
        SelectionResult<XYZ> result = new SelectionResult<XYZ>();
        try
        {
            result.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickPoint()
                : uiDocument.Selection.PickPoint(prompt);

            result.SelectionStatus = SelectionStatus.Succeeded;
            result.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            result.SelectionStatus = SelectionStatus.Cancelled;
            result.Message = "Canceled";
        }
        catch (Exception exception)
        {
            result.SelectionStatus = SelectionStatus.Failed;
            result.Message = exception.Message;
            result.Exception = exception;
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
    [DebuggerStepThrough]
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, ISelectionFilter selectionFilter = null, string prompt = null)
    {
        SelectionResult<IList<Element>> selectionResult = new SelectionResult<IList<Element>>();
        try
        {
            selectionFilter ??= new DefaultSelectionFilter();

            selectionResult.Value = string.IsNullOrWhiteSpace(prompt)
                ? uiDocument.Selection.PickElementsByRectangle(selectionFilter)
                : uiDocument.Selection.PickElementsByRectangle(selectionFilter, prompt);

            selectionResult.SelectionStatus = SelectionStatus.Succeeded;
            selectionResult.Message = "Succeeded";
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.SelectionStatus = SelectionStatus.Cancelled;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.SelectionStatus = SelectionStatus.Failed;
            selectionResult.Message = exception.Message;
            selectionResult.Exception = exception;
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
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, BuiltInCategory builtInCategory, string prompt = null)
    {
        return uiDocument.SelectElementsByRectangle(new ElementId(builtInCategory), prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="builtInCategoryId">要选择的图元对象的 <see cref="Autodesk.Revit.DB.ElementId"/></param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
    public static SelectionResult<IList<Element>> SelectElementsByRectangle(this UIDocument uiDocument, ElementId builtInCategoryId, string prompt = null)
    {
        return uiDocument.SelectElementsByRectangle(element => element.Category?.Id == builtInCategoryId, prompt);
    }

    /// <summary>
    /// 当前方法用于提示用户选择一个项目中的点，如果用户取消了操作（比如用户按下 ESC），那么将会返回一个失败的结果，即 <see cref="SelectionResult{T}"/> 的属性 Succeeded 将为false，反之，为true
    /// <para>Prompts the user to select multiple elements by drawing a rectangle, if the user cancels the operation (for example, through ESC), the method will return failed result, otherwise true.</para>
    /// </summary>
    /// <param name="uiDocument">要操作的文档</param>
    /// <param name="prompt">给用户的提示</param>
    /// <returns>用户选择的结果</returns>
    [DebuggerStepThrough]
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
    [DebuggerStepThrough]
    public static SelectionResult<PickedBox> SelectBox(this UIDocument uIDocument, PickBoxStyle pickBoxStyle = PickBoxStyle.Crossing, string prompt = null)
    {
        SelectionResult<PickedBox> selectionResult = new SelectionResult<PickedBox>();
        try
        {
            PickedBox pickBox = string.IsNullOrWhiteSpace(prompt) ? uIDocument.Selection.PickBox(pickBoxStyle) : uIDocument.Selection.PickBox(pickBoxStyle, prompt);

            selectionResult.SelectionStatus = SelectionStatus.Succeeded;
            selectionResult.Message = "Succeeded";
            selectionResult.Value = pickBox;
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException)
        {
            selectionResult.SelectionStatus = SelectionStatus.Cancelled;
            selectionResult.Message = "Canceled";
        }
        catch (Exception exception)
        {
            selectionResult.SelectionStatus = SelectionStatus.Failed;
            selectionResult.Message = exception.Message;
            selectionResult.Exception = exception;
        }

        return selectionResult;
    }
}
