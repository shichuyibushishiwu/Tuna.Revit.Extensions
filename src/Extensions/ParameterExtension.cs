///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/4/6 9:46:29
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
    /// <summary>
    /// 与Parameter相关的方法扩展
    /// </summary>
    public static class ParameterExtension
    {
        /// <summary>
        /// Obtain parameter value based on StorageType
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Parameter value</returns>
        public static string GetParameterValue(this Parameter parameter)
        {
            if (parameter == null)
            {
                return null;
            }
            string value = string.Empty;
            switch (parameter.StorageType)
            {
                case StorageType.None:
                    break;
                case StorageType.Integer:
                    value = parameter.AsInteger().ToString();
                    break;
                case StorageType.Double:
                    value = parameter.AsDouble().ToString();
                    break;
                case StorageType.String:
                    value = parameter.AsString();
                    break;
                case StorageType.ElementId:
                    value = parameter.AsElementId().ToString();
                    break;
                default:
                    break;
            }
            return value;
        }

        /// <summary>
        /// Set parameter value based on StorageType
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="propertyValue"></param>
        /// <returns>Is the parameter set successful</returns>
        public static bool SetParameterValue(this Parameter parameter, string propertyValue)
        {
            bool result = false;
            if (parameter.IsReadOnly || parameter == null || propertyValue == null)
            {
                return result;
            }
            var storageType = parameter.StorageType;
            switch (storageType)
            {
                case StorageType.None:
                    break;
                case StorageType.Integer:
                    var intFlag = int.TryParse(propertyValue, out int intValue);
                    if (intFlag)
                    {
                        result = parameter.Set(intValue);
                    }
                    break;
                case StorageType.Double:
                    var doubleFlag = double.TryParse(propertyValue, out double doubleValue);
                    if (doubleFlag)
                    {
                        result = parameter.Set(doubleValue);
                    }
                    break;
                case StorageType.String:
                    result = parameter.Set(propertyValue);
                    break;
                case StorageType.ElementId:
                    var idFlag = int.TryParse(propertyValue, out int idValue);
                    if (idFlag)
                    {
                        result = parameter.Set(new ElementId(idValue));
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
