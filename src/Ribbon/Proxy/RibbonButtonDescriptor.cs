
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Ribbon.Proxy;

internal class RibbonButtonDescriptor
{
    public Action<RibbonButtonData> Handle { get; set; }

    public Type CommandType { get; set; }

    public IRibbonButtonData RibbonButtonData { get; set; }

    public PushButtonData PushButtonData { get; set; }

    public static RibbonButtonDescriptor CreateRibbonButtonDescriptor(Action<PushButtonData> handle, Type commandType)
    {
        //按钮的名称
        string name = commandType.Name;

        //实例化一个按钮的数据
        PushButtonData pushButtonData = new($"btn_{name}", name ?? name, commandType.Assembly.Location, commandType.FullName);

        //如果命令实现了 IExternalCommandAvailability 接口
        if (typeof(IExternalCommandAvailability).IsAssignableFrom(commandType))
        {
            pushButtonData.AvailabilityClassName = commandType.FullName;
        }

        //方式三，通过属性进行配置，优先级第三
        IRibbonButtonData ribbonButtonData = commandType.GetCustomAttribute<CommandButtonAttribute>();
        if (ribbonButtonData != null)
        {
            UIExtension.SetPushButtonData(pushButtonData, ribbonButtonData);
        }

        //方式二，通过接口进行配置，优先级第二
        if (typeof(IRibbonButtonData).IsAssignableFrom(commandType))
        {
            ribbonButtonData = Activator.CreateInstance(commandType) as IRibbonButtonData;
            UIExtension.SetPushButtonData(pushButtonData, ribbonButtonData);
        }

        //方式一，通过回调进行配置，优先级第一
        handle?.Invoke(pushButtonData);

        return new RibbonButtonDescriptor()
        {
            PushButtonData = pushButtonData,
            RibbonButtonData = ribbonButtonData,
            CommandType = commandType
        };
    }
}
