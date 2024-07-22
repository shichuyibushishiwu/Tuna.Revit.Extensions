using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
	/// <summary>
	/// 几何获取配置选项
	/// </summary>
    public class GeometryOptions:Options
    {
		private GeometryType _geometryType;
		/// <summary>
		/// 几何类型
		/// </summary>

		public GeometryType GeometryType
        {
			get { return _geometryType; }
			set { _geometryType = value; }
		}


	}
}
