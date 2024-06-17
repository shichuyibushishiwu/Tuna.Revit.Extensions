/************************************************************************************
   Author:Tony Stark
   CreateTime:2023/4/6 9:46:29
   Mail:2609639898@qq.com
   Github:https://github.com/getup700

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Utility;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// revit parameter extension
    /// </summary>
    public static class ParameterExtension
    {
        /// <summary>
        /// Obtain parameter value based on StorageType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static T GetParameterValue<T>(this Parameter parameter)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(parameter);

            try
            {
                switch (parameter.StorageType)
                {
                    case StorageType.Integer:
                        return (T)(object)parameter.AsInteger();
                    case StorageType.Double:
                        return (T)(object)parameter.AsDouble();
                    case StorageType.String:
                        return (T)(object)parameter.AsString();
                    case StorageType.ElementId:
                        return (T)(object)parameter.AsElementId();
                    default:
                        return (T)(object)parameter.AsValueString();
                }
            }
            catch (Exception)
            {
                throw new Exception($"Invalid value conversion , revit parameter storage type is {parameter.StorageType}");
            }
        }

        /// <summary>
        /// Set parameter value based on StorageType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static bool SetParameterValue<T>(this Parameter parameter, T value)
        {
            ArgumentNullExceptionUtils.ThrowIfNull(parameter);
            ArgumentNullExceptionUtils.ThrowIfNull(value);

            if (parameter.IsReadOnly)
            {
                throw new System.ArgumentNullException(nameof(parameter), "parameter is read only");
            }

            bool result = false;
            var storageType = parameter.StorageType;
            switch (storageType)
            {
                case StorageType.Integer:
                    if (value is not int intValue)
                    {
                        throw new Exception($"Invalid value conversion , revit parameter storage type is {parameter.StorageType} ");
                    }
                    result = parameter.Set(intValue);
                    break;
                case StorageType.Double:
                    if (value is not double doubleValue)
                    {
                        throw new Exception($"Invalid value conversion , revit parameter storage type is {parameter.StorageType} ");
                    }
                    result = parameter.Set(doubleValue);
                    break;
                case StorageType.String:
                    if (value is not string stringValue)
                    {
                        throw new Exception($"Invalid value conversion , revit parameter storage type is {parameter.StorageType} ");
                    }
                    result = parameter.Set(stringValue);
                    break;
                case StorageType.ElementId:
                    if (value is not ElementId idValue)
                    {
                        throw new Exception($"Invalid value conversion , revit parameter storage type is {parameter.StorageType} ");
                    }
                    result = parameter.Set(idValue);
                    break;
            }
            return result;
        }


        /// <summary>
        /// Get Parameter value
        /// </summary>
        /// <typeparam name="T">Generic constraint can be int,double,string,ElementId</typeparam>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static T GetParameterValueAuto<T>(this Parameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter), "Parameter cannot be null while obtaining the value of parameter.");
            }
            try
            {
                return parameter.StorageType switch
                {
                    StorageType.Integer => ParameterValueUtils.ConvertTo<T>(parameter.AsInteger()),
                    StorageType.Double => ParameterValueUtils.ConvertTo<T>(parameter.AsDouble()),
                    StorageType.String => ParameterValueUtils.ConvertTo<T>(parameter.AsString()),
                    StorageType.ElementId => ParameterValueUtils.ConvertTo<T>(parameter.AsElementId()),
                    _ => (T)ParameterValueUtils.ConvertTo<T>(parameter.AsValueString()),
                };
            }
            catch (Exception)
            {
                throw new Exception($"Invalid value conversion, revit parameter storage type is {parameter.StorageType}, cannot convert to {typeof(T).FullName}");
            }
        }

        /// <summary>
        /// Return true if get value successful from given parameter
        /// </summary>
        /// <typeparam name="T">>Generic constraint can be int,double,string,ElementId</typeparam>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SetParameterValueAuto(this Parameter parameter, dynamic value)
        {
            if (parameter == null && parameter.StorageType != StorageType.String)
            {
                throw new ArgumentNullException(nameof(parameter), "parameter can not be null");
            }

            if (parameter.IsReadOnly)
            {
                throw new ArgumentNullException(nameof(parameter), "parameter is read only");
            }

            var storageType = parameter.StorageType;
            dynamic dynameValue = default;
            switch (storageType)
            {
                case StorageType.Integer:
                    dynameValue = ParameterValueUtils.ConvertTo<int>(value);
                    break;
                case StorageType.Double:
                    dynameValue = ParameterValueUtils.ConvertTo<double>(value);
                    break;
                case StorageType.String:
                    if (value == null)
                    {
                        dynameValue = string.Empty;
                    }
                    dynameValue = ParameterValueUtils.ConvertTo<string>(value);
                    break;
                case StorageType.ElementId:
                    dynameValue = ParameterValueUtils.ConvertTo<ElementId>(value);
                    break;
            }
            var result = parameter.Set(dynameValue);
            return result;
        }
    }
}
