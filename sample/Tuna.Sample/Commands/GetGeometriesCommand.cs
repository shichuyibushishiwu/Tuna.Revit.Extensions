using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tuna.Revit.Extension;

namespace Tuna.Sample.Commands
{
    /// <summary>
    /// 获取几何信息的演示样例
    /// 此处先使用扩展获取了几何块，再对几何块进行进一步的解析；
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class GetGeometriesCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDocument = commandData.Application.ActiveUIDocument;

            Document document = uiDocument.Document;

            var element = uiDocument.SelectElement().Value;
            //get solids before get faces
            var solids = GeometryExtensions.ResolveSolids(element, (option) => { 
               option.DetailLevel=ViewDetailLevel.Fine;
            });
            //get faces from solids 
            var faces = GeometryExtensions.ResolveFaces(element, (option) => {
                option.DetailLevel = ViewDetailLevel.Fine;
                option.GeometryType=GeometryType.Symbol;
            });
            //show result solids count
            MessageBox.Show(solids.Count().ToString());
            //show result faces count
            MessageBox.Show(faces.Count().ToString());


            return Result.Succeeded;
        }
    }
}
