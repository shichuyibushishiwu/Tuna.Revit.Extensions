///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/5/17 星期三 14:34:53
///   Mail:2609639898@qq.com
///   Github:https://github.com/getup700
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
    public static class FamilyExtension
    {
        /// <summary>
        /// Convert FamilyParameterSet to List<FamilyParameter>
        /// </summary>
        /// <param name="familyParameterSet"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<FamilyParameter> ToList(this FamilyParameterSet familyParameterSet, Predicate<FamilyParameter> predicate = null)
        {
            var familyParameters = new List<FamilyParameter>();
            foreach (var item in familyParameterSet)
            {
                var familyParameter = item as FamilyParameter;
                if (familyParameter == null)
                {
                    continue;
                }
                if (predicate != null && predicate(familyParameter) || predicate == null)
                {
                    familyParameters.Add(familyParameter);
                }
            }
            return familyParameters;
        }

        /// <summary>
        /// Convert ParameterSet to List<Parameter>
        /// </summary>
        /// <param name="parameterSet"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<Parameter> ToList(this ParameterSet parameterSet, Predicate<Parameter> predicate = null)
        {
            var parameters = new List<Parameter>();
            var iterator = parameterSet.ForwardIterator();
            while (iterator.MoveNext())
            {
                var parameter = iterator.Current as Parameter;
                if (parameter == null)
                {
                    continue;
                }
                if (predicate == null || predicate(parameter))
                {
                    parameters.Add(parameter);
                }
            }
            return parameters;
        }

    }
}
