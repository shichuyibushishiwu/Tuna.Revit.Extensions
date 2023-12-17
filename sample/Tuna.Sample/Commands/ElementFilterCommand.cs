///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/15 11:54:10
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using Tuna.Revit.Extension;

namespace Tuna.Sample.Commands;

[CommandButton(Image = "compass.png")]
[Transaction(TransactionMode.Manual)]
public class ElementFilterCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uIDocument = commandData.Application.ActiveUIDocument;
        Document document = uIDocument.Document;


        //这些方法可以获取到项目中的图元，不包括图元类型，所以如果在使用 BuiltInCategory 的时候，不需要再对类型进行过滤
        document.GetElements<Wall>();

        document.GetElements(typeof(Wall));

        document.GetElements(typeof(Wall), typeof(Floor));

        document.GetElements(new ElementClassFilter(typeof(Wall)));

        document.GetElements(BuiltInCategories.Walls, BuiltInCategories.Walls);

        document.GetElements(BuiltInCategory.OST_Walls);

        document.GetElements(BuiltInCategory.OST_Walls, BuiltInCategory.OST_WallsCutPattern);

        document.GetElements(StructuralWallUsage.Bearing);

        document.GetElements(StructuralMaterialType.Steel);

        document.GetElements(StructuralInstanceUsage.Column);

        document.GetElements(StructuralType.Column);

        document.GetElements(CurveElementType.ModelCurve);

        document.GetElements(document.GetFamilySymbols(document.GetElements(typeof(Family)).FirstElementId()).FirstOrDefault());

        document.GetElements(document.GetElements<Level>().FirstOrDefault());


        //这些方法可以获取到项目中的类型
        document.GetElementTypes(BuiltInCategories.Walls);

        document.GetElementTypes(BuiltInCategory.OST_Walls);

        document.GetElementTypes<WallType>();


        //这个方法可以获取结构相关的族
        document.GetStructualFamilies(StructuralMaterialType.Steel);


        var elems = uIDocument.ActiveGraphicalView.GetElements(BuiltInCategory.OST_Walls);


        uIDocument.SelectObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, element => element.Category.Id == BuiltInCategories.Doors, "选择门");

        uIDocument.SelectElement(BuiltInCategory.OST_Walls, "选择墙体");









        //document.GetElements()
        //    .OfCategories(BuiltInCategory.OST_Walls)
        //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_MODEL, ParameterFilterStringOperator.BeginWith, "m")
        //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_COST, ParameterFilterStringOperator.Contains, "m")
        //    .WithParameterStringValue(BuiltInParameter.ALL_MODEL_FAMILY_NAME, ParameterFilterStringOperator.BeginWith, "m")
        //    .WithParameterStringValue(BuiltInParameter.ALLOW_AUTO_EMBED, ParameterFilterStringOperator.BeginWith, "m")
        //    .ToFilter()
        //    .ToElements();



        //document.GetElements<FamilyInstance>(instance => instance.Symbol.FamilyName == "预制");

        //var elems = document.GetGraphicElements<FamilyInstance>(instance => instance.Name == "name");

        //Enumerator.Range(1, 100);

        return Result.Succeeded;
    }
}
