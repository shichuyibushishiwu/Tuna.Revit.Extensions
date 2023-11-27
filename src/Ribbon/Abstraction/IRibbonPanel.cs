using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension;

public interface IRibbonPanel
{
    string Name { get; }

    void AddSlideOut();

    void AddSeparator();

    void AddPushButton<T>() where T : class, IExternalCommand, IRibbonButton, new();

    //public void CreatePulldownButton();

    //public void CreatePushButton<TCommand>() where TCommand : IExternalCommand;

    //public void CreateSplitButton();

    //public void CreateRadioButtonGroup();

    //public void CreateTextBox();

    //public void CreateComboBox();
}
