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
    public static class ElementExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="parameterId"></param>
        /// <returns></returns>
        public static Parameter GetParameter(this Element element, ElementId parameterId)
        {
            foreach (Parameter item in element.Parameters)
            {
                if (item.Id == parameterId)
                {
                    return item;
                }
            }
            return default;
        }
    }
}
