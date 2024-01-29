/************************************************************************************
   Author:十五
   CretaeTime:2023/1/27 11:15:30
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Tuna.Revit.Extension;

/// <summary>
/// Revit geometry extension
/// </summary>
public static class TransientElementExtensions
{
    private static readonly List<ElementId> _transientElementIds = new List<ElementId>();

    private static readonly string _displayMethod = "SetForTransientDisplay";

    private static readonly MethodInfo _method = GetTransientDisplayMethod() ?? throw new Exception($"No target method");

    /// <summary>
    /// 在项目中创建临时显示的图元，临时图元将不会被保存在项目中，在项目关闭后，临时图元将被删除
    /// <para>Creates geometry of transient (temporary) element for application display which will not be saved with the model.</para>
    /// </summary>
    /// <param name="document">Revit document</param>
    /// <param name="objects">Transient element geometry</param>
    /// <param name="graphicsStyleId">Transient element  graphics element style element id</param>
    /// <returns>
    /// 创建的临时图元的 <see cref="Autodesk.Revit.DB.ElementId"/>
    /// <para>The element id of the created element</para>
    /// </returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    /// <exception cref="System.Exception"></exception>
    public static ElementId TransientDisplay(this Document document, IList<GeometryObject> objects, ElementId graphicsStyleId = null)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);
        ElementId elementId = (ElementId)_method.Invoke(null, parameters: new object[4]
        {
               document,
               ElementId.InvalidElementId,
               objects,
               graphicsStyleId ?? ElementId.InvalidElementId
        });
        _transientElementIds.Add(elementId);
        return elementId;
    }

    /// <summary>
    /// 在项目中创建临时显示的图元，临时图元将不会被保存在项目中，在项目关闭后，临时图元将被删除
    /// <para>Creates geometry of transient (temporary) element for application display which will not be saved with the model.</para>
    /// </summary>
    /// <param name="document">Revit document</param>
    /// <param name="geometryObject">Transient element geometry</param>
    /// <param name="graphicsStyleId">Transient element  graphics element style element id</param>
    /// <returns>
    /// 创建的临时图元的 <see cref="Autodesk.Revit.DB.ElementId"/>
    /// <para>The element id of the created element</para>
    /// </returns>
    public static ElementId TransientDisplay(this Document document, GeometryObject geometryObject, ElementId graphicsStyleId = null)
    {
        return document.TransientDisplay(new List<GeometryObject>() { geometryObject }, graphicsStyleId);
    }

    /// <summary>
    /// 清理金枪鱼扩展包创建的所有临时图元
    /// <para>Clean up all transient (temporary) elements produced by tuna in the document</para>
    /// </summary>
    /// <param name="document">要执行操作的文档</param>
    public static void CleanTransientElements(this Document document)
    {
        if (_transientElementIds.Count == 0)
        {
            return;
        }

        document.NewTransaction(() => document.Delete(_transientElementIds.ToArray()));
        _transientElementIds.Clear();
    }

    /// <summary>
    /// 重新设置临时图元的图形
    /// <para>Reset transient (temporary) element geometry</para>
    /// </summary>
    /// <param name="document">Revit document</param>
    /// <param name="transientElementId">transient element id</param>
    /// <param name="objects">transient element geometries</param>
    /// <param name="graphicsStyleId">transient element graphics style element id </param>
    public static void ResetTransientElementGeometry(this Document document, ElementId transientElementId, IList<GeometryObject> objects, ElementId graphicsStyleId = null) => _method.Invoke(null, parameters: new object[4]
    {
        document,
        transientElementId,
        objects,
        graphicsStyleId ?? ElementId.InvalidElementId
    });

    /// <summary>
    /// 重新设置临时图元的图形
    /// <para>Reset transient (temporary) element geometry</para>
    /// </summary>
    /// <param name="document">Revit document</param>
    /// <param name="transientElementId">Transient element id</param>
    /// <param name="geometryObject">Transient element geometries</param>
    /// <param name="graphicsStyleId">Transient element graphics style element id </param>
    public static void ResetTransientElementGeometry(this Document document, ElementId transientElementId, GeometryObject geometryObject, ElementId graphicsStyleId = null)
    {
        document.ResetTransientElementGeometry(transientElementId, new List<GeometryObject>() { geometryObject }, graphicsStyleId);
    }

    /// <summary>
    /// get revit internal method where is from geometry element
    /// </summary>
    /// <returns></returns>
    private static MethodInfo GetTransientDisplayMethod()
    {
        return typeof(GeometryElement)
            .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.Name == _displayMethod);
    }
}