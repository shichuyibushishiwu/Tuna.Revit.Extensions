using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuna.Revit.Extension.Ribbon.Abstraction;

namespace Tuna.Revit.Extension.Ribbon.Proxy
{
    internal class RibbonPulldownButtonProxy : RibbonElementProxy<PulldownButton>, IRibbonPulldownButton
    {
        private readonly List<IRibbonItem> _items = new();

        public RibbonItemType Type => RibbonItemType.PulldownButton;

        public void AddPushButton<TCommand>() where TCommand : class, IExternalCommand, IRibbonButton, new()
        {
            RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();
            RibbonButtonProxy ribbonButtonProxy = new()
            {
                OriginalObject = ribbonButton,
                Name = ribbonButton.Name,
            };
            _items.Add(ribbonButtonProxy);
        }

        public string Text { get; set; }

        public IEnumerable<IRibbonItem> GetItems() => _items;
    }
}
