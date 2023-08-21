using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// 字符串计算符
    /// </summary>
    public enum ParameterFilterStringOperator
    {
        /// <summary>
        /// 字符串开始字符是
        /// </summary>
        BeginWith,

        /// <summary>
        /// 字符串包含
        /// </summary>
        Contains,

        /// <summary>
        /// 字符串结束是
        /// </summary>
        /// 
        EndsWith,

        /// <summary>
        /// 等于
        /// </summary>
        Equals,

        /// <summary>
        /// 大于
        /// </summary>
        Greater,

        /// <summary>
        /// 大于等于
        /// </summary>
        GreatorOrEqual,

        /// <summary>
        /// 小于
        /// </summary>
        Less,

        /// <summary>
        /// 小于等于
        /// </summary>
        LessOrEqual
    }
}
