/************************************************************************************
   Author:十五
   CretaeTime:2023/4/22 1:08:36
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit family extension
/// </summary>
public static class FamilyExtension
{
    /// <summary>
    /// Converter <see cref="IEnumerable"/> to <see cref="List{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TParent"></typeparam>
    /// <param name="set"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    private static List<T> ToList<T, TParent>(TParent set, Predicate<T> predicate = null) where TParent : IEnumerable
    {
        return (predicate == null ? ToList(set) : ToList(set).Where(p => predicate(p))).ToList();

        static IEnumerable<T> ToList(TParent set)
        {
            foreach (T parameter in set)
            {
                yield return parameter;
            }
        }
    }

    /// <summary>
    /// 从 <see cref="FamilyParameterSet"/> 创建一个 <see cref="List{T}"/>
    /// <para>Create a <see cref="List{T}"/> from <see cref="FamilyParameterSet"/> </para>
    /// </summary>
    /// <param name="familyParameterSet">族参数集</param>
    /// <param name="predicate">对集合进行过滤</param>
    /// <returns>参数集 <see cref="List{T}"/> </returns>
    public static List<FamilyParameter> ToList(this FamilyParameterSet familyParameterSet, Predicate<FamilyParameter> predicate = null) => ToList<FamilyParameter, FamilyParameterSet>(familyParameterSet, predicate);

    /// <summary>
    /// 从 <see cref="ParameterSet"/> 创建一个 <see cref="List{T}"/>
    /// <para>Create a <see cref="List{T}"/> from <see cref="ParameterSet"/> </para>
    /// </summary>
    /// <param name="parameterSet">参数集</param>
    /// <param name="predicate">对集合进行过滤</param>
    /// <returns>参数集 <see cref="List{T}"/> </returns>
    public static List<Parameter> ToList(this ParameterSet parameterSet, Predicate<Parameter> predicate = null) => ToList<Parameter, ParameterSet>(parameterSet, predicate);

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
