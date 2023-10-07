/************************************************************************************
   Author:十五
   CretaeTime:2023/3/3 21:46:09
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// Revit parameter filter extensions
    /// </summary>
    public static class ParameterFilterElementExtension
    {
        /// <summary>
        /// Get parameter filter element's filter
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ElementFilter GetElementFilter(this ParameterFilterElement element)
        {
#if Rvt_16 || Rvt_17 || Rvt_18
            var rules = element.GetRules();
            if (rules.Count > 0)
            {
                return new ElementParameterFilter(rules);
            }
            return null;
#else
            return element.GetElementFilter();
#endif
        }
    }
}
