using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// 考虑因素较多.暂不可使用
    /// </summary>
    [Obsolete]
    public static class Enumerator
    {
        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static IEnumerable<int> Range(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
                yield return i;
        }

        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<int> Range(int start, int end)
        {
            for (int i = start; i <= end; i++)
                yield return i;
        }

        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<int> Range(int end)
        {
            for (int i = 0; i <= end; i++)
                yield return i;
        }

        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static IEnumerable<double> Range(double start, double end, double step)
        {
            for (double i = start; i <= end; i += step)
                yield return Math.Round(i, 10);
        }

        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<double> Range(double start, double end)
        {
            for (double i = start; i <= end; i++)
                yield return Math.Round(i, 10);
        }

        /// <summary>
        /// 按指定范围创建一系列数字
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public static IEnumerable<double> Range(double end)
        {
            for (double i = 0; i <= end; i++)
                yield return Math.Round(i, 10);
        }

        ///// <summary>
        ///// 按指定范围创建一系列数字
        ///// </summary>
        ///// <param name="start"></param>
        ///// <param name="amount"></param>
        ///// <param name="step"></param>
        ///// <returns></returns>
        //public static IEnumerable<int> Sequence(int start, int amount, int step)
        //{
        //    for (int i = start; i <= end; i += step)
        //        yield return i;
        //}
    }
}
