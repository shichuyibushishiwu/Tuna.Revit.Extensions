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

namespace Tuna.Revit.Extension.Extensions
{
    public static class ParameterExtension
    {
        /// <summary>
        /// Obtain parameter value based on StorageType
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Parameter value</returns>
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
                    var intValue = propertyValue.ToInt32();
                    if (intValue == null)
                    {
                        return result;
                    }
                    result = parameter.Set(intValue.Value);
                    break;
                case StorageType.Double:
                    var doubleValue = propertyValue.ToDouble();
                    if (doubleValue == null)
                    {
                        return result;
                    }
                    result = parameter.Set(doubleValue.Value);
                    break;
                case StorageType.String:
                    result = parameter.Set(propertyValue);
                    break;
                case StorageType.ElementId:
                    var intId = propertyValue.ToInt32();
                    if (intId == null)
                    {
                        return result;
                    }
                    result = parameter.Set(new ElementId(intId.Value));
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
