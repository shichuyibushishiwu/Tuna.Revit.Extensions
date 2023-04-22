///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/22 1:08:36
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
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit family api extension
    /// </summary>
    public static class FamilyExtension
    {
        /// <summary>
        /// Get family symbol elements
        /// </summary>
        /// <param name="family"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static IEnumerable<FamilySymbol> GetFamilySymbols(this Family family)
        {
            if (family == null)
            {
                throw new ArgumentNullException(nameof(family));
            }
            return family.Document.GetFamilySymbols(family.Id);
        }
    }
}
