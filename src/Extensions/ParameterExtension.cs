///************************************************************************************
///   Author:Tony Stark
///   CreateTime:2023/4/3 14:49:19
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

namespace Tuna.Revit.Extension.Extensions
{
    public static class ParameterExtension
    {
        /// <summary>
        /// Obtain valid values of parameters based on StorageType
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>parameters value</returns>
        public static string GetParameterValue(this Parameter parameter)
        {
            string value = string.Empty;
            switch (parameter?.StorageType)
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
        /// Set valid values for parameters based on StorageType
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="propertyValue"></param>
        /// <returns>Whether the parameters were set successfully</returns>
        public static bool? SetParameterValue(this Parameter parameter, string propertyValue)
        {
            if (parameter.IsReadOnly)
            {
                return false;
            }
            bool? result = false;
            var storageType = parameter.StorageType;
            switch (storageType)
            {
                case StorageType.None:
                    break;
                case StorageType.Integer:
                    var intValue = propertyValue.ToInt32();
                    result = parameter?.Set(intValue ?? 0);
                    break;
                case StorageType.Double:
                    var doubleValue = propertyValue.ToDouble();
                    result = parameter?.Set(doubleValue ?? 0.0);
                    break;
                case StorageType.String:
                    result = parameter?.Set(propertyValue ?? string.Empty);
                    break;
                case StorageType.ElementId:
                    var intId = propertyValue.ToInt32();
                    if (intId == null)
                    {
                        return false;
                    }
                    result = parameter?.Set(new ElementId(intId.Value));
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
