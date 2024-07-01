using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension;

namespace Tuna.Sample.Commands;

[Transaction(TransactionMode.Manual)]
internal class CommandA : IExternalCommand, IRibbonButtonData
{
    public string Title => "ss";

    public string LongDescription => "";

    public string ToolTip => "";

    public object Image => "gift16.png";

    public object LargeImage => "gift32.png";

    public object ToolTipImage => "";

    public ContextualHelp ContextualHelp => new ContextualHelp(ContextualHelpType.Url, "https://shichuyibushishiwu.github.io/");

    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        TaskDialog.Show("msg", "A");
        return Result.Succeeded;
    }
}

[CommandButton(LargeImage = "gift32.png", Image = "gift16.png")]
[Transaction(TransactionMode.Manual)]
internal class CommandB : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
       

        TaskDialog.Show("msg", "B");
        return Result.Succeeded;
    }
}
