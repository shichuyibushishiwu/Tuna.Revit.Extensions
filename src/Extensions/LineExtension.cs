///************************************************************************************
///   Author:zmz
///   CretaeTime:2023/2/26 
///   Mail:
///   Github:
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
    public static class LineExtension
    {
		public static Line CreateBoundExt(this XYZ firstPoint, XYZ secondPoint)
		{
			if (!firstPoint.IsEqualExt(secondPoint, GlobalData.GlobalTolerance))
				throw new Exception("The first point is equal to the second point");
			return Line.CreateBound(firstPoint, secondPoint);
		}

		public static Line CreateUnBoundExt(this XYZ firstPoint, XYZ secondPoint)
		{
			if (!firstPoint.IsEqualExt(secondPoint, GlobalData.GlobalTolerance))
				throw new Exception("The first point is equal to the second point");
			return Line.CreateUnbound(firstPoint, secondPoint);
		}
	}
}
