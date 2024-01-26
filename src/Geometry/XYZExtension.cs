/************************************************************************************
   Author:Tony Stark
   CreateTime:2023/5/17 星期三 15:09:02
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

namespace Tuna.Revit.Extension
{
    public static class XYZExtension
    {   
        /// <summary>
        /// Deep coup origin,convert the distance into revit internal units,and move according to direction and distance.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="orientation"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static XYZ Calculate(this XYZ origin, XYZ orientation, double distance)
        {
            var originClone = new XYZ(origin.X, origin.Y, origin.Z);
            var shift = orientation.Normalize() * (distance.ConvertToFeet());
            var result = originClone + shift;
            return result;
        }
    }
}
