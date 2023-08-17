///************************************************************************************
///   Author:十五
///   CretaeTime:2023/1/27 11:15:30
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// revit geometry extension
    /// </summary>
    public static class GeometryExtension
    {
        private static List<ElementId> _transientElementIds = new List<ElementId>();

        private static readonly string _displayMethod = "SetForTransientDisplay";

        private static MethodInfo _method = GetTransientDisplayMethod() ?? throw new Exception($"No target method");

        /// <summary>
        /// Creates geometry of transient (temporary) element for application display which will not be saved with the model.
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="objects">Transient element geometry</param>
        /// <param name="graphicsStyleId">Transient element  graphics element style element id</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
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
        /// Creates geometry of transient (temporary) element for application display which will not be saved with the model.
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="geometryObject">Transient element geometry</param>
        /// <param name="graphicsStyleId">Transient element  graphics element style element id</param>
        /// <returns>The element id of the created element</returns>
        public static ElementId TransientDisplay(this Document document, GeometryObject geometryObject, ElementId graphicsStyleId = null)
        {
            return document.TransientDisplay(new List<GeometryObject>() { geometryObject }, graphicsStyleId);
        }

        /// <summary>
        /// Clean up all transient (temporary) elements produced by tuna in the document
        /// </summary>
        /// <param name="document">Revit document</param>
        public static void CleanTransientElements(this Document document)
        {
            if (_transientElementIds.Count == 0)
            {
                return;
            }
            document.NewTransaction((d) => d.Delete(_transientElementIds.ToArray()));
            _transientElementIds.Clear();
        }

        /// <summary>
        /// Reset transient (temporary) element geometry
        /// </summary>
        /// <param name="document">Revit document</param>
        /// <param name="transientElementId">transient element id</param>
        /// <param name="objects">transient element geometries</param>
        /// <param name="graphicsStyleId">transient element graphics style element id </param>
        public static void ResetTransientElementGeometry(this Document document, ElementId transientElementId, IList<GeometryObject> objects, ElementId graphicsStyleId = null)
        {
            _method.Invoke(null, parameters: new object[4]
            {
               document,
               transientElementId,
               objects,
               graphicsStyleId ?? ElementId.InvalidElementId
            });
        }

        /// <summary>
        /// Reset transient (temporary) element geometry
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
}
