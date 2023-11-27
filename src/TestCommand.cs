using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Tuna.Revit.Extension;

[Transaction(TransactionMode.Manual)]
internal class TestCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uiDocument = commandData.Application.ActiveUIDocument;
        Document document = uiDocument.Document;
        var cs = new List<BuiltInCategory>
            {
              BuiltInCategory.OST_PipeCurves,
              BuiltInCategory.OST_PipeFitting,
              BuiltInCategory.OST_PipeAccessory,
              BuiltInCategory.OST_FlexPipeCurves,
              BuiltInCategory.OST_Sprinklers,

              //Equipements
              BuiltInCategory.OST_SpecialityEquipment,
              BuiltInCategory.OST_NurseCallDevices,
              BuiltInCategory.OST_TelephoneDevices,
              BuiltInCategory.OST_FireAlarmDevices,
              BuiltInCategory.OST_GenericModel,
              //MEP NetWork
              BuiltInCategory.OST_FabricationPipework,
              BuiltInCategory.OST_FabricationDuctwork,
              BuiltInCategory.OST_FabricationHangers,

              //CVC
              BuiltInCategory.OST_DuctTerminal,
              BuiltInCategory.OST_MechanicalEquipment,
              BuiltInCategory.OST_DuctCurves,
              BuiltInCategory.OST_DuctAccessory,
              BuiltInCategory.OST_DuctFitting,
              BuiltInCategory.OST_FlexDuctCurves,

              //Electricite
              BuiltInCategory.OST_Conduit,
              BuiltInCategory.OST_CableTray,
              BuiltInCategory.OST_ConduitFitting,
              BuiltInCategory.OST_CableTrayFitting,
              BuiltInCategory.OST_ElectricalEquipment,
              BuiltInCategory.OST_Casework,
              BuiltInCategory.OST_ElectricalFixtures,

              //GC
              #region GC
              BuiltInCategory.OST_Stairs,
           
              BuiltInCategory.OST_StructuralFoundation,
              BuiltInCategory.OST_Ceilings,
              BuiltInCategory.OST_Gutter,
              BuiltInCategory.OST_StairsRailing,
              BuiltInCategory.OST_Walls,
              BuiltInCategory.OST_StructuralFraming,
              BuiltInCategory.OST_CurtainWallPanels,
              BuiltInCategory.OST_CurtainWallMullions,
              BuiltInCategory.OST_Doors,
              BuiltInCategory.OST_Columns,
              BuiltInCategory.OST_StructuralColumns,
              BuiltInCategory.OST_Floors,
              BuiltInCategory.OST_Roofs,
            #endregion
        };

        Stopwatch Stopwatch = new Stopwatch();
        Stopwatch.Start();
        document.GetElements(BuiltInCategory.OST_Windows,cs.ToArray());
        Stopwatch.Stop();
        System.Windows.MessageBox.Show(Stopwatch.Elapsed.ToString());
        return Result.Succeeded;
    }
}

internal class TestApplication : IExternalApplication
{
    public Result OnShutdown(UIControlledApplication application)
    {
        throw new NotImplementedException();
    }

    public Result OnStartup(UIControlledApplication application)
    {
        application.CreateRibbonTab("tuna", tab => tab

        .CreateRibbonPanel("archi", panel => panel
            .AddPulldownButton()
            .AddSplitButton()
            .AddTextBox()
            .AddComboBox()
            .AddSlideOut(panel => panel
                .AddSplitButton()))

        .CreateRibbonPanel("struct", panel => panel
            .AddSplitButton()));


        return Result.Succeeded;
    }
}
