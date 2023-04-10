///************************************************************************************
///   Author:十五
///   CretaeTime:2021/12/10 19:47:31
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
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
    /// revit element extension
    /// </summary>
    public static class ElementExtension
    {
        /// <summary>
        /// Get element <see cref="Parameter"/> by <see cref="Autodesk.Revit.DB.ElementId"/>
        /// </summary>
        /// <param name="element">host element</param>
        /// <param name="parameterId">target parameter id</param>
        /// <returns>element <see cref="Parameter"/></returns>
        public static Parameter GetParameter(this Element element, ElementId parameterId)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element), "element can not be null");
            }

            if (parameterId != ElementId.InvalidElementId)
            {
                foreach (Parameter item in element.Parameters)
                {
                    if (item.Id == parameterId)
                    {
                        return item;
                    }
                }
            }
            return default;
        }
    }
}
