///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/3/22 10:31:20
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using Autodesk.Revit.DB;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit外部参数特性以获取元素的参数
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class ExternalDefinitionAttribute : Attribute
{
    /// <summary>
    /// 参数的名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 参数所在组
    /// </summary>
    public BuiltInParameterGroup ParameterGroup { get; set; } = BuiltInParameterGroup.INVALID;



#if Rvt_22|| Rvt_23 || Rvt_24
    public ExternalDefinitionAttribute(string name, BuiltInParameterGroup builtInParameterGroup)
    {
        Name = name;
        ParameterGroup = builtInParameterGroup;
    }
#else
    public ExternalDefinitionAttribute(string name, BuiltInParameterGroup builtInParameterGroup, ParameterType parameterType, UnitType unitType = UnitType.UT_Number)
    {
        Name = name;
        ParameterGroup = builtInParameterGroup;
        ParameterType = parameterType;
        UnitType = unitType;
    }

    public ParameterType ParameterType { get; set; }

    public UnitType UnitType { get; set; }
#endif

    /// <summary>
    /// 判断两个参数是否完全一致
    /// </summary>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool Equal(Definition definition)
    {
        if (definition == null) return false;
        if (definition.Name != Name) return false;
        if (definition.ParameterGroup != ParameterGroup) return false;
#if Rvt_16 || Rvt_17|| Rvt_18|| Rvt_19|| Rvt_20|| Rvt_21
        if (definition.ParameterType != ParameterType) return false;
        if (definition.UnitType != UnitType) return false;
#endif
        return true;
    }
}


/// <summary>
/// 标记Revit内部参数属性以获取其参数
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class InternalDefinitionAttribute : Attribute
{
    public InternalDefinitionAttribute(BuiltInParameter builtInParameter)
    {
        BuiltInParameter = builtInParameter;
    }

    /// <summary>
    /// Revit内置参数
    /// </summary>
    public BuiltInParameter BuiltInParameter { get; set; } = BuiltInParameter.INVALID;

}
