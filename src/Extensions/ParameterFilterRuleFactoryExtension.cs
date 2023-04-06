///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/3 23:55:24
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
    public static class ParameterFilterRuleFactoryExtension
    {
        public static FilterRule CreateEqualsRule(ElementId id, string name, bool caseSensitive = false)
        {
#if Rvt_23
            return ParameterFilterRuleFactory.CreateEqualsRule(id, name);
#else
            return ParameterFilterRuleFactory.CreateEqualsRule(id, name, caseSensitive);
#endif
        }
    }
}
