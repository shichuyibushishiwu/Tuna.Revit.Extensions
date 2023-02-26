using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class CurveExtension
    {
        /// <summary>
        /// 起点
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static XYZ StartPointExt(this Curve curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            return curve.IsBound ? curve.GetEndPoint(0) : null;
        }

        /// <summary>
        /// 终点
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static XYZ EndPointExt(this Curve curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            return curve.IsBound ? curve.GetEndPoint(1) : null;
        }

        /// <summary>
        /// 中点
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static XYZ MiddlePointExt(this Curve curve)
        {
            if (curve == null)
                throw new ArgumentNullException(nameof(curve));
            if (!curve.IsBound)
                return null;
            double startParameter = curve.GetEndParameter(0);
            double endParameter = curve.GetEndParameter(1);
            return curve.Evaluate((startParameter + endParameter) / 2.0, false);
        }

        /// <summary>
        /// 线是否相等
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="sameDir">是否要求同向</param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        public static bool IsEqualExt(this Line line1, Line line2, bool sameDir = false, double tolerance = 0.0)
        {
            if (sameDir)
                return line1.StartPointExt().IsEqualExt(line2.StartPointExt(), tolerance) && line1.EndPointExt().IsEqualExt(line2.EndPointExt(), tolerance);
            return (line1.StartPointExt().IsEqualExt(line2.StartPointExt(), tolerance) && line1.EndPointExt().IsEqualExt(line2.EndPointExt(), tolerance)) ||
                (line1.StartPointExt().IsEqualExt(line2.EndPointExt(), tolerance) && line1.EndPointExt().IsEqualExt(line2.StartPointExt(), tolerance));
        }

        public static Curve OffsetVectorExt(this Curve curve, XYZ vec)
        {
            return curve.CreateTransformed(Transform.CreateTranslation(vec));
        }

        /// <summary>
        /// 绕点旋转（逆时针）
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="angle">角度（弧度）</param>
        /// <param name="pt"></param>
        /// <param name="axis">旋转轴</param>
        /// <returns></returns>
        public static Curve RotateByPointExt(this Curve curve, double angle, XYZ pt, XYZ axis = null)
        {
            if (axis == null)
                axis = XYZ.BasisZ;
            Transform transform = Transform.CreateRotationAtPoint(axis, angle, pt);
            return curve.CreateTransformed(transform);
        }

        /// <summary>
        /// 点到线的最近点
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        public static XYZ GetProjectExt(this Curve curve, XYZ pt)
        {
            IntersectionResult intersectionResult = curve.Project(pt);
            return intersectionResult?.XYZPoint;
        }
    }
}
