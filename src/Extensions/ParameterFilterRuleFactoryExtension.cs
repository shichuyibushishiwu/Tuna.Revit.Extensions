/************************************************************************************
   Author:十五
   CretaeTime:2023/4/3 23:55:24
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
    /// Revit parameter filter rule extensions
    /// </summary>
    public static class ParameterFilterRuleFactoryExtension
    {
        /// <summary>
        /// Creates a filter rule that determines whether strings from the document equal a certain value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public static FilterRule CreateEqualsRule(ElementId id, string name, bool caseSensitive = false)
        {
#if Rvt_23||Rvt_24
            return ParameterFilterRuleFactory.CreateEqualsRule(id, name);
#else
            return ParameterFilterRuleFactory.CreateEqualsRule(id, name, caseSensitive);
#endif
        }
    }
}
