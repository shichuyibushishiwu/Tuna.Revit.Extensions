///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/3/22 10:36:57
///   Mail:2609639898@qq.com
///   GitHub:https://github.com/getup700
///
///   Description:
///
///************************************************************************************

using System;
using System.Linq;
using Autodesk.Revit.DB;
using System.Reflection;

namespace Tuna.Revit.Extension;

/// <summary>
/// <see cref="ExternalDefinitionAttribute"/>与<see cref="InternalDefinitionAttribute"/>的解析方法
/// </summary>
public static class RevitDefinitionAttributeExtension
{
    /// <summary>
    /// 根据<see cref="ExternalDefinitionAttribute"/>以获取元素的指定参数
    /// </summary>
    /// <param name="externalDefinitionAttribute">外部参数定义</param>
    /// <param name="element">参数所在的元素</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">外部参数为null，或元素为空，或未在元素中找到指定外部参数</exception>
    public static Parameter GetUniqueParameter(this ExternalDefinitionAttribute externalDefinitionAttribute, Element element)
    {
            ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);
            if (externalDefinitionAttribute == null)
            {
                throw new ArgumentNullException($"ExternalDefinitionAttribute is null");
            }
            var parameters = element.GetParameters(externalDefinitionAttribute.Name);
            if (parameters.Count == 0)
            {
                throw new ArgumentNullException($"Element {element.Name} dose not have a parameter {externalDefinitionAttribute.Name}");
            }
            var parameter = parameters?.FirstOrDefault(x => externalDefinitionAttribute.Equal(x.Definition));
            return parameter;
    }

    /// <summary>
    /// 根据<see cref="InternalDefinitionAttribute"/>获取元素指定内部参数
    /// </summary>
    /// <param name="internalDefinitionAttribute">内部参数定义</param>
    /// <param name="element">参数所在的元素</param>
    /// <returns>参数</returns>
    /// <exception cref="ArgumentNullException">内部参数为null，或元素为空，或未在元素中找到指定外部参数</exception>
    /// <exception cref="Exception">无效的参数定义</exception>
    public static Parameter GetUniqueParameter(this InternalDefinitionAttribute internalDefinitionAttribute, Element element)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(element);
        if (internalDefinitionAttribute.BuiltInParameter == BuiltInParameter.INVALID)
        {
            throw new Exception("Invalid BuiltInParameter");
        }
        var parameter = element.get_Parameter(internalDefinitionAttribute.BuiltInParameter);
        return parameter;
    }

}
