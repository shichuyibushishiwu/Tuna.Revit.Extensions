using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy
{
    internal class RibbonPulldownButtonProxy : RibbonElementProxy<PulldownButton>, IRibbonItem, IRibbonItemsCollector
    {
        private readonly List<IRibbonItem> _items = new();

        public RibbonItemType Type => RibbonItemType.PulldownButton;

        public void AddPushButton<TCommand>() where TCommand : class, IExternalCommand, IRibbonButton, new()
        {
            RibbonButton ribbonButton = this.OriginalObject.CreatePushButton<TCommand>();
            RibbonButtonProxy ribbonButtonProxy = new RibbonButtonProxy()
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
