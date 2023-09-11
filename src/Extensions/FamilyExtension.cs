/************************************************************************************
   Author:十五
   CretaeTime:2023/4/22 1:08:36
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
    /// 
    /// </summary>
    public static class FamilyExtension
    {
        /// <summary>
        /// Convert FamilyParameterSet to 
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
        /// Convert ParameterSet to 
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

        /// <summary>
        /// 获取族的所有类型
        /// <para>Get all family symbols of family</para>
        /// </summary>
        /// <param name="family">族</param>
        /// <returns>从族所在的文档中查询的结果 <see cref="IEnumerable{T}"/></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static IEnumerable<FamilySymbol> GetFamilySymbols(this Family family)
        {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(family);
            return family.Document.GetFamilySymbols(family.Id);
        }
    }
}
