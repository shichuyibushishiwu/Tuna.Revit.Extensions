using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Abstraction;

/// <summary>
/// 下拉按钮
/// </summary>
public interface IRibbonPulldownButton : IRibbonButtonConfigurable<IRibbonPulldownButton>, IRibbonPushButtonContainer<IRibbonPulldownButton>
{

}
