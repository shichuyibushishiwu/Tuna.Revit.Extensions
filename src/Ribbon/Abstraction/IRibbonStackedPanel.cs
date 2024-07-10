using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

/// <summary>
/// 堆叠式面板
/// </summary>
public interface IRibbonStackedPanel
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TComandA"></typeparam>
    /// <typeparam name="TCommandB"></typeparam>
    /// <typeparam name="TCommandC"></typeparam>
    public void AddPushButton<TComandA, TCommandB, TCommandC>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TComandA"></typeparam>
    /// <typeparam name="TCommandB"></typeparam>
    public void AddPushButton<TComandA, TCommandB>();
}
