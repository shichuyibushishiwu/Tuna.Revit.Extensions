namespace Tuna.Revit.Extension;

/// <summary>
/// 界面元素
/// </summary>
public interface IRibbonItem
{
    /// <summary>
    /// 界面元素的名称
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 界面元素类型
    /// </summary>
    RibbonItemType Type { get; }
}
