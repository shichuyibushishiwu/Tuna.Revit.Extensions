using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Utility
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ParameterValueUtils
    {
        internal static dynamic ConvertTo<T>(string value)
        {
            var typeField = typeof(T).ToString();
            switch (typeField)
            {
                case "System.String":
                    return value;

                case "System.Int32":
                    if (string.IsNullOrEmpty(value))
                    {
                        return 0;
                    }
                    int intResult = Convert.ToInt32(value);
                    return intResult;

                case "System.Double":
                    if (string.IsNullOrEmpty(value))
                    {
                        return 0.0;
                    }
                    double doubleResult = Convert.ToDouble(value);
                    return doubleResult;

                case "Autodesk.Revit.DB.ElementId":
                    if (!int.TryParse(value, out int intValue))
                    {
                        return ElementId.InvalidElementId;
                    }
                    var elementId = ElementId.InvalidElementId;
                    if (intValue == -1)
                    {
                        elementId = ElementId.InvalidElementId;
                    }
                    else
                    {
                        elementId = new ElementId(intValue);
                    }
                    return elementId;
            }
            throw new FormatException("Invalid parameter type");
        }

        internal static T ConvertTo<T>(double value)
        {
            var stringValue = value.ToString();
            return ConvertTo<T>(stringValue);
        }

        internal static T ConvertTo<T>(int value)
        {
            var stringValue = value.ToString();
            return ConvertTo<T>(stringValue);
        }

        internal static T ConvertTo<T>(ElementId elementId)
        {
            var id = elementId.IntegerValue.ToString();
            return ConvertTo<T>(id);
        }


    }
}
