using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class XyzExtension
    {

        public static bool IsEqualExt(this XYZ first, XYZ second, double tolerance = 0.0)
        {
            return Math.Abs(first.X - second.X) <= tolerance &&
                Math.Abs(first.Y - second.Y) <= tolerance &&
                Math.Abs(first.Z - second.Z) <= tolerance;
        }

        public static XYZ AddX(this XYZ point, double x)
        {
            return new XYZ(point.X + x, point.Y, point.Z);
        }
        public static XYZ AddY(this XYZ point, double y)
        {
            return new XYZ(point.X, point.Y + y, point.Z);
        }
        public static XYZ AddZ(this XYZ point, double z)
        {
            return new XYZ(point.X, point.Y, point.Z + z);
        }

        public static XYZ NewZExt(this XYZ point, double newz = 0.0)
        {
            return new XYZ(point.X, point.Y, newz);
        }

        public static Line NewLineExt(this XYZ firstPoint,XYZ secondPoint ) 
        {
            if (firstPoint.IsEqualExt(secondPoint,GlobalData.GlobalTolerance))
            {
                throw new Exception("The first point is equal to the second point");
            }
            return Line.CreateBound(firstPoint, secondPoint);
        }

    }
}
