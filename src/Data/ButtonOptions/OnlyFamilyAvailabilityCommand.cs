///************************************************************************************
///   Author:十五
///   CretaeTime:2023/2/27 21:41:20
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Data.ButtonOptions
{
    internal class OnlyFamilyAvailabilityCommand : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (!applicationData.IsValidObject)
            {
                return false;
            }

            if (applicationData.ActiveUIDocument == null)
            {
                return false;
            }

            if (applicationData.ActiveUIDocument.Document == null)
            {
                return false;
            }

            return applicationData.ActiveUIDocument.Document.IsFamilyDocument;
        }
    }
}
