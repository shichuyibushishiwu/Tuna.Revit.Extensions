///************************************************************************************
///   Author:十五
///   CretaeTime:2022/11/29 0:08:10
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Data;

namespace Tuna.Revit.Extension
{
    public static class SelectionExtension
    {
        /// <summary>
        /// Prompts the user to select one element , if the user cancels the operation (for example, through ESC), the method will return null. 
        /// </summary>
        /// <param name="uiDocument"></param>
        /// <returns></returns>
        public static Element SelectElement(this UIDocument uiDocument)
        {
            var result = uiDocument.SelectObject(ObjectType.Element);
            if (!result.Succeeded)
            {
                return default;
            }
            return uiDocument.Document.GetElement(result.Value);
        }

        /// <summary>
        /// Prompts the user to select one object , if the user cancels the operation (for example, through ESC), the method will return null. 
        /// </summary>
        /// <param name="uiDocument"></param>
        /// <param name="objectType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SelectionResult<Reference> SelectObject(this UIDocument uiDocument, Autodesk.Revit.UI.Selection.ObjectType objectType)
        {
            if (uiDocument == null)
            {
                throw new ArgumentNullException(nameof(uiDocument), "UIDocument can not be null");
            }

            SelectionResult<Reference> selectionResult = new SelectionResult<Reference>();

            try
            {
                selectionResult.Value = uiDocument.Selection.PickObject(objectType);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException exception)
            {
                selectionResult.Succeeded = false;
                selectionResult.Message = exception.Message;
            }

            return selectionResult;
        }

        public static SelectionResult<IList<Reference>> SelectObjects(this UIDocument uiDocument, 
            ObjectType objectType, 
            ISelectionFilter selectionFilter = null, 
            string prompt = null)
        {
            if (uiDocument == null)
            {
                throw new ArgumentNullException(nameof(uiDocument), "UIDocument can not be null");
            }
            SelectionResult<IList<Reference>> selectionResult = new SelectionResult<IList<Reference>>();
            try
            {
                if (selectionFilter == null)
                {
                    selectionFilter = new DefaultSelectionFilter();
                }
                selectionResult.Value = uiDocument.Selection.PickObjects(objectType, selectionFilter);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException exception)
            {
                selectionResult.Succeeded = false;
                selectionResult.Message = exception.Message;
            }
            return selectionResult;
        }
    }
}
