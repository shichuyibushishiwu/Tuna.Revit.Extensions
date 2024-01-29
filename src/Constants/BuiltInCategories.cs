/************************************************************************************
   Author:十五
   CretaeTime:2023/3/9 0:35:01
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace Tuna.Revit.Extension;

/// <summary>
/// Revit 中部分常用的内置类别
/// <para>Revit builtin categories</para>
/// </summary>
public class BuiltInCategories
{
    /// <summary>
    /// 无效的类别
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.INVALID"/></para>
    /// </summary>
    public static ElementId Invaild { get; } = new ElementId(BuiltInCategory.INVALID);

    /// <summary>
    /// 视图标题
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ViewportLabel"/></para>
    /// </summary>
    public static ElementId ViewportLabel { get; } = new ElementId(BuiltInCategory.OST_ViewportLabel);

    /// <summary>
    /// 视口
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Viewports"/></para>
    /// </summary>
    public static ElementId Viewports { get; } = new ElementId(BuiltInCategory.OST_Viewports);

    /// <summary>
    /// 灯具
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LightingDevices"/></para>
    /// </summary>
    public static ElementId LightingDevices { get; } = new ElementId(BuiltInCategory.OST_LightingDevices);

    /// <summary>
    /// 家具
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Furniture"/></para>
    /// </summary>
    public static ElementId Furniture { get; } = new ElementId(BuiltInCategory.OST_Furniture);

    /// <summary>
    /// 自适应点
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AdaptivePoints"/></para>
    /// </summary>
    public static ElementId AdaptivePoints { get; } = new ElementId(BuiltInCategory.OST_AdaptivePoints);

    /// <summary>
    /// 文字注释
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_TextNotes"/></para>
    /// </summary>
    public static ElementId TextNotes { get; } = new ElementId(BuiltInCategory.OST_TextNotes);

    /// <summary>
    /// 机电设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MechanicalEquipmentTags"/></para>
    /// </summary>
    public static ElementId MechanicalEquipmentTags { get; } = new ElementId(BuiltInCategory.OST_MechanicalEquipmentTags);

    /// <summary>
    /// 管道隔热层
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeInsulations"/></para>
    /// </summary>
    public static ElementId PipeInsulations { get; } = new ElementId(BuiltInCategory.OST_PipeInsulations);

    /// <summary>
    /// 专用设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpecialityEquipmentTags"/></para>
    /// </summary>
    public static ElementId SpecialityEquipmentTags { get; } = new ElementId(BuiltInCategory.OST_SpecialityEquipmentTags);

    /// <summary>
    /// 结构区域钢筋符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AreaReinSpanSymbol"/></para>
    /// </summary>
    public static ElementId AreaReinSpanSymbol { get; } = new ElementId(BuiltInCategory.OST_AreaReinSpanSymbol);

    /// <summary>
    /// 电缆桥架配件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CableTrayFitting"/></para>
    /// </summary>
    public static ElementId CableTrayFitting { get; } = new ElementId(BuiltInCategory.OST_CableTrayFitting);

    /// <summary>
    /// 家具系统标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FurnitureSystemTags"/></para>
    /// </summary>
    public static ElementId FurnitureSystemTags { get; } = new ElementId(BuiltInCategory.OST_FurnitureSystemTags);

    /// <summary>
    /// 照明设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LightingFixtures"/></para>
    /// </summary>
    public static ElementId LightingFixtures { get; } = new ElementId(BuiltInCategory.OST_LightingFixtures);

    /// <summary>
    /// 分析独立基础标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_IsolatedFoundationAnalyticalTags"/></para>
    /// </summary>
    public static ElementId IsolatedFoundationAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_IsolatedFoundationAnalyticalTags);

    /// <summary>
    /// 电气装置
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ElectricalFixtures"/></para>
    /// </summary>
    public static ElementId ElectricalFixtures { get; } = new ElementId(BuiltInCategory.OST_ElectricalFixtures);

    /// <summary>
    /// 详图项目标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DetailComponentTags"/></para>
    /// </summary>
    public static ElementId DetailComponentTags { get; } = new ElementId(BuiltInCategory.OST_DetailComponentTags);

    /// <summary>
    /// 分析基础底板
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FoundationSlabAnalytical"/></para>
    /// </summary>
    public static ElementId FoundationSlabAnalytical { get; } = new ElementId(BuiltInCategory.OST_FoundationSlabAnalytical);

    /// <summary>
    /// 管道
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeCurves"/></para>
    /// </summary>
    public static ElementId PipeCurves { get; } = new ElementId(BuiltInCategory.OST_PipeCurves);

    /// <summary>
    /// 坡道
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Ramps"/></para>
    /// </summary>
    public static ElementId Ramps { get; } = new ElementId(BuiltInCategory.OST_Ramps);

    /// <summary>
    /// 地形
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Topography"/></para>
    /// </summary>
    public static ElementId Topography { get; } = new ElementId(BuiltInCategory.OST_Topography);

    /// <summary>
    /// 场地
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Site"/></para>
    /// </summary>
    public static ElementId Site { get; } = new ElementId(BuiltInCategory.OST_Site);

    /// <summary>
    /// 喷头
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Sprinklers"/></para>
    /// </summary>
    public static ElementId Sprinklers { get; } = new ElementId(BuiltInCategory.OST_Sprinklers);

    /// <summary>
    /// 颜色填充图例
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ColorFillLegends"/></para>
    /// </summary>
    public static ElementId ColorFillLegends { get; } = new ElementId(BuiltInCategory.OST_ColorFillLegends);

    /// <summary>
    /// 屋顶
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Roofs"/></para>
    /// </summary>
    public static ElementId Roofs { get; } = new ElementId(BuiltInCategory.OST_Roofs);

    /// <summary>
    /// 竖井洞口
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ShaftOpening"/></para>
    /// </summary>
    public static ElementId ShaftOpening { get; } = new ElementId(BuiltInCategory.OST_ShaftOpening);

    /// <summary>
    /// 门标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DoorTags"/></para>
    /// </summary>
    public static ElementId DoorTags { get; } = new ElementId(BuiltInCategory.OST_DoorTags);

    /// <summary>
    /// 窗标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WindowTags"/></para>
    /// </summary>
    public static ElementId WindowTags { get; } = new ElementId(BuiltInCategory.OST_WindowTags);


#if !Rvt_16

    /// <summary>
    /// MEP 预制保护层标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationContainmentTags"/></para>
    /// </summary>
    public static ElementId FabricationContainmentTags { get; } = new ElementId(BuiltInCategory.OST_FabricationContainmentTags);

    /// <summary>
    /// MEP 预制支架标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationHangerTags"/></para>
    /// </summary>
    public static ElementId FabricationHangerTags { get; } = new ElementId(BuiltInCategory.OST_FabricationHangerTags);

    /// <summary>
    /// 结构钢筋接头标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CouplerTags"/></para>
    /// </summary>
    public static ElementId CouplerTags { get; } = new ElementId(BuiltInCategory.OST_CouplerTags);

    /// <summary>
    /// 结构钢筋接头
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Coupler"/></para>
    /// </summary>
    public static ElementId Coupler { get; } = new ElementId(BuiltInCategory.OST_Coupler);

    /// <summary>
    /// MEP 预制管网
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationDuctwork"/></para>
    /// </summary>
    public static ElementId FabricationDuctwork { get; } = new ElementId(BuiltInCategory.OST_FabricationDuctwork);

    /// <summary>
    /// MEP 预制管网标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationDuctworkTags"/></para>
    /// </summary>
    public static ElementId FabricationDuctworkTags { get; } = new ElementId(BuiltInCategory.OST_FabricationDuctworkTags);

    /// <summary>
    /// MEP 预制支架
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationHangers"/></para>
    /// </summary>
    public static ElementId FabricationHangers { get; } = new ElementId(BuiltInCategory.OST_FabricationHangers);

    /// <summary>
    /// MEP 预制保护层
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationContainment"/></para>
    /// </summary>
    public static ElementId FabricationContainment { get; } = new ElementId(BuiltInCategory.OST_FabricationContainment);

    /// <summary>
    /// MEP 预制管道
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationPipework"/></para>
    /// </summary>
    public static ElementId FabricationPipework { get; } = new ElementId(BuiltInCategory.OST_FabricationPipework);

    /// <summary>
    /// MEP 预制管道标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricationPipeworkTags"/></para>
    /// </summary>
    public static ElementId FabricationPipeworkTags { get; } = new ElementId(BuiltInCategory.OST_FabricationPipeworkTags);

#endif

#if !Rvt_16 && !Rvt_17

    /// <summary>
    /// 分析管道连接
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AnalyticalPipeConnections"/></para>
    /// </summary>
    public static ElementId AnalyticalPipeConnections { get; } = new ElementId(BuiltInCategory.OST_AnalyticalPipeConnections);

#endif

#if !Rvt_16 && !Rvt_17 && !Rvt_18

    /// <summary>
    /// 板标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionPlateTags"/></para>
    /// </summary>
    public static ElementId StructConnectionPlateTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionPlateTags);

    /// <summary>
    /// 孔标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionHoleTags"/></para>
    /// </summary>
    public static ElementId StructConnectionHoleTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionHoleTags);

    /// <summary>
    /// 锚固件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionAnchorTags"/></para>
    /// </summary>
    public static ElementId StructConnectionAnchorTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionAnchorTags);

    /// <summary>
    /// 机械设备集边界线
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MechanicalEquipmentSetBoundaryLines"/></para>
    /// </summary>
    public static ElementId MechanicalEquipmentSetBoundaryLines { get; } = new ElementId(BuiltInCategory.OST_MechanicalEquipmentSetBoundaryLines);

    /// <summary>
    /// 焊接标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionWeldTags"/></para>
    /// </summary>
    public static ElementId StructConnectionWeldTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionWeldTags);

    /// <summary>
    /// 轮廓标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionProfilesTags"/></para>
    /// </summary>
    public static ElementId StructConnectionProfilesTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionProfilesTags);

    /// <summary>
    /// 剪力钉标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionShearStudTags"/></para>
    /// </summary>
    public static ElementId StructConnectionShearStudTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionShearStudTags);

    /// <summary>
    /// 螺栓标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionBoltTags"/></para>
    /// </summary>
    public static ElementId StructConnectionBoltTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionBoltTags);

    /// <summary>
    /// 机械设备集标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MechanicalEquipmentSetTags"/></para>
    /// </summary>
    public static ElementId MechanicalEquipmentSetTags { get; } = new ElementId(BuiltInCategory.OST_MechanicalEquipmentSetTags);

#endif

#if !Rvt_16 && !Rvt_17 && !Rvt_18 && !Rvt_19

    /// <summary>
    /// 行进路径标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PathOfTravelTags"/></para>
    /// </summary>
    public static ElementId PathOfTravelTags { get; } = new ElementId(BuiltInCategory.OST_PathOfTravelTags);

    /// <summary>
    /// 系统分区标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MEPSystemZoneTags"/></para>
    /// </summary>
    public static ElementId MEPSystemZoneTags { get; } = new ElementId(BuiltInCategory.OST_MEPSystemZoneTags);

    /// <summary>
    /// 系统分区
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MEPSystemZone"/></para>
    /// </summary>
    public static ElementId MEPSystemZone { get; } = new ElementId(BuiltInCategory.OST_MEPSystemZone);

#endif

    /// <summary>
    /// 墙标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WallTags"/></para>
    /// </summary>
    public static ElementId WallTags { get; } = new ElementId(BuiltInCategory.OST_WallTags);

    /// <summary>
    /// 电缆桥架
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CableTray"/></para>
    /// </summary>
    public static ElementId CableTray { get; } = new ElementId(BuiltInCategory.OST_CableTray);

    /// <summary>
    /// 尺寸标注
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Dimensions"/></para>
    /// </summary>
    public static ElementId Dimensions { get; } = new ElementId(BuiltInCategory.OST_Dimensions);

    /// <summary>
    /// 结构连接标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionTags"/></para>
    /// </summary>
    public static ElementId StructConnectionTags { get; } = new ElementId(BuiltInCategory.OST_StructConnectionTags);

    /// <summary>
    /// 分析支撑标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BraceAnalyticalTags"/></para>
    /// </summary>
    public static ElementId BraceAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_BraceAnalyticalTags);

    /// <summary>
    /// 结构钢筋网标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricReinforcementTags"/></para>
    /// </summary>
    public static ElementId FabricReinforcementTags { get; } = new ElementId(BuiltInCategory.OST_FabricReinforcementTags);

    /// <summary>
    /// 参照点
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ReferencePoints"/></para>
    /// </summary>
    public static ElementId ReferencePoints { get; } = new ElementId(BuiltInCategory.OST_ReferencePoints);

    /// <summary>
    /// 参照线
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ReferenceLines"/></para>
    /// </summary>
    public static ElementId ReferenceLines { get; } = new ElementId(BuiltInCategory.OST_ReferenceLines);

    /// <summary>
    /// 常规模型标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_GenericModelTags"/></para>
    /// </summary>
    public static ElementId GenericModelTags { get; } = new ElementId(BuiltInCategory.OST_GenericModelTags);

    /// <summary>
    /// 分析节点标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_NodeAnalyticalTags"/></para>
    /// </summary>
    public static ElementId NodeAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_NodeAnalyticalTags);

    /// <summary>
    /// 面积
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Areas"/></para>
    /// </summary>
    public static ElementId Areas { get; } = new ElementId(BuiltInCategory.OST_Areas);

    /// <summary>
    /// 多类别标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MultiCategoryTags"/></para>
    /// </summary>
    public static ElementId MultiCategoryTags { get; } = new ElementId(BuiltInCategory.OST_MultiCategoryTags);

    /// <summary>
    /// 平面视图中的支撑符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralBracePlanReps"/></para>
    /// </summary>
    public static ElementId StructuralBracePlanReps { get; } = new ElementId(BuiltInCategory.OST_StructuralBracePlanReps);

    /// <summary>
    /// 软风管标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FlexDuctTags"/></para>
    /// </summary>
    public static ElementId FlexDuctTags { get; } = new ElementId(BuiltInCategory.OST_FlexDuctTags);

    /// <summary>
    /// 分析条形基础
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WallFoundationAnalytical"/></para>
    /// </summary>
    public static ElementId WallFoundationAnalytical { get; } = new ElementId(BuiltInCategory.OST_WallFoundationAnalytical);

    /// <summary>
    /// 电话设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_TelephoneDevices"/></para>
    /// </summary>
    public static ElementId TelephoneDevices { get; } = new ElementId(BuiltInCategory.OST_TelephoneDevices);

    /// <summary>
    /// 体量标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MassTags"/></para>
    /// </summary>
    public static ElementId MassTags { get; } = new ElementId(BuiltInCategory.OST_MassTags);

    /// <summary>
    /// 管道附件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeAccessoryTags"/></para>
    /// </summary>
    public static ElementId PipeAccessoryTags { get; } = new ElementId(BuiltInCategory.OST_PipeAccessoryTags);

    /// <summary>
    /// 软风管
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FlexDuctCurves"/></para>
    /// </summary>
    public static ElementId FlexDuctCurves { get; } = new ElementId(BuiltInCategory.OST_FlexDuctCurves);

    /// <summary>
    /// 屋顶标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RoofTags"/></para>
    /// </summary>
    public static ElementId RoofTags { get; } = new ElementId(BuiltInCategory.OST_RoofTags);

    /// <summary>
    /// 位移路径
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DisplacementPath"/></para>
    /// </summary>
    public static ElementId DisplacementPath { get; } = new ElementId(BuiltInCategory.OST_DisplacementPath);

    /// <summary>
    /// 数据设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DataDeviceTags"/></para>
    /// </summary>
    public static ElementId DataDeviceTags { get; } = new ElementId(BuiltInCategory.OST_DataDeviceTags);

    /// <summary>
    /// 幕墙系统标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CurtaSystemTags"/></para>
    /// </summary>
    public static ElementId CurtaSystemTags { get; } = new ElementId(BuiltInCategory.OST_CurtaSystemTags);

    /// <summary>
    /// 管道标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeTags"/></para>
    /// </summary>
    public static ElementId PipeTags { get; } = new ElementId(BuiltInCategory.OST_PipeTags);

    /// <summary>
    /// 楼板标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FloorTags"/></para>
    /// </summary>
    public static ElementId FloorTags { get; } = new ElementId(BuiltInCategory.OST_FloorTags);

    /// <summary>
    /// 体量楼层标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MassAreaFaceTags"/></para>
    /// </summary>
    public static ElementId MassAreaFaceTags { get; } = new ElementId(BuiltInCategory.OST_MassAreaFaceTags);

    /// <summary>
    /// 结构基础标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFoundationTags"/></para>
    /// </summary>
    public static ElementId StructuralFoundationTags { get; } = new ElementId(BuiltInCategory.OST_StructuralFoundationTags);

    /// <summary>
    /// 楼梯路径
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsPaths"/></para>
    /// </summary>
    public static ElementId StairsPaths { get; } = new ElementId(BuiltInCategory.OST_StairsPaths);

    /// <summary>
    /// 电话设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_TelephoneDeviceTags"/></para>
    /// </summary>
    public static ElementId TelephoneDeviceTags { get; } = new ElementId(BuiltInCategory.OST_TelephoneDeviceTags);

    /// <summary>
    /// 护理呼叫设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_NurseCallDeviceTags"/></para>
    /// </summary>
    public static ElementId NurseCallDeviceTags { get; } = new ElementId(BuiltInCategory.OST_NurseCallDeviceTags);

    /// <summary>
    /// 分析独立基础
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_IsolatedFoundationAnalytical"/></para>
    /// </summary>
    public static ElementId IsolatedFoundationAnalytical { get; } = new ElementId(BuiltInCategory.OST_IsolatedFoundationAnalytical);

    /// <summary>
    /// 结构框架标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFramingTags"/></para>
    /// </summary>
    public static ElementId StructuralFramingTags { get; } = new ElementId(BuiltInCategory.OST_StructuralFramingTags);

    /// <summary>
    /// 结构桁架标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_TrussTags"/></para>
    /// </summary>
    public static ElementId TrussTags { get; } = new ElementId(BuiltInCategory.OST_TrussTags);

    /// <summary>
    /// 停车场标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ParkingTags"/></para>
    /// </summary>
    public static ElementId ParkingTags { get; } = new ElementId(BuiltInCategory.OST_ParkingTags);

    /// <summary>
    /// 材质标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MaterialTags"/></para>
    /// </summary>
    public static ElementId MaterialTags { get; } = new ElementId(BuiltInCategory.OST_MaterialTags);

    /// <summary>
    /// 结构柱
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralColumns"/></para>
    /// </summary>
    public static ElementId StructuralColumns { get; } = new ElementId(BuiltInCategory.OST_StructuralColumns);

    /// <summary>
    /// 结构路径钢筋符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PathReinSpanSymbol"/></para>
    /// </summary>
    public static ElementId PathReinSpanSymbol { get; } = new ElementId(BuiltInCategory.OST_PathReinSpanSymbol);

    /// <summary>
    /// 风管内衬
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctLinings"/></para>
    /// </summary>
    public static ElementId DuctLinings { get; } = new ElementId(BuiltInCategory.OST_DuctLinings);

    /// <summary>
    /// 零件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PartTags"/></para>
    /// </summary>
    public static ElementId PartTags { get; } = new ElementId(BuiltInCategory.OST_PartTags);

    /// <summary>
    /// 管件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeFittingTags"/></para>
    /// </summary>
    public static ElementId PipeFittingTags { get; } = new ElementId(BuiltInCategory.OST_PipeFittingTags);

    /// <summary>
    /// 导线
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Wire"/></para>
    /// </summary>
    public static ElementId Wire { get; } = new ElementId(BuiltInCategory.OST_Wire);

    /// <summary>
    /// 结构加强板
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralStiffener"/></para>
    /// </summary>
    public static ElementId StructuralStiffener { get; } = new ElementId(BuiltInCategory.OST_StructuralStiffener);

    /// <summary>
    /// 风管标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctTags"/></para>
    /// </summary>
    public static ElementId DuctTags { get; } = new ElementId(BuiltInCategory.OST_DuctTags);

    /// <summary>
    /// 软管标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FlexPipeTags"/></para>
    /// </summary>
    public static ElementId FlexPipeTags { get; } = new ElementId(BuiltInCategory.OST_FlexPipeTags);

    /// <summary>
    /// 线管标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ConduitTags"/></para>
    /// </summary>
    public static ElementId ConduitTags { get; } = new ElementId(BuiltInCategory.OST_ConduitTags);

    /// <summary>
    /// 风管颜色填充
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctColorFills"/></para>
    /// </summary>
    public static ElementId DuctColorFills { get; } = new ElementId(BuiltInCategory.OST_DuctColorFills);

    /// <summary>
    /// 结构框架
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFraming"/></para>
    /// </summary>
    public static ElementId StructuralFraming { get; } = new ElementId(BuiltInCategory.OST_StructuralFraming);

    /// <summary>
    /// 结构桁架
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralTruss"/></para>
    /// </summary>
    public static ElementId StructuralTruss { get; } = new ElementId(BuiltInCategory.OST_StructuralTruss);

    /// <summary>
    /// 结构柱标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralColumnTags"/></para>
    /// </summary>
    public static ElementId StructuralColumnTags { get; } = new ElementId(BuiltInCategory.OST_StructuralColumnTags);

    /// <summary>
    /// 边界条件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BoundaryConditions"/></para>
    /// </summary>
    public static ElementId BoundaryConditions { get; } = new ElementId(BuiltInCategory.OST_BoundaryConditions);

    /// <summary>
    /// 风管
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctCurves"/></para>
    /// </summary>
    public static ElementId DuctCurves { get; } = new ElementId(BuiltInCategory.OST_DuctCurves);

    /// <summary>
    /// 软管
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FlexPipeCurves"/></para>
    /// </summary>
    public static ElementId FlexPipeCurves { get; } = new ElementId(BuiltInCategory.OST_FlexPipeCurves);

    /// <summary>
    /// 线管
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Conduit"/></para>
    /// </summary>
    public static ElementId Conduit { get; } = new ElementId(BuiltInCategory.OST_Conduit);

    /// <summary>
    /// 结构路径钢筋标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PathReinTags"/></para>
    /// </summary>
    public static ElementId PathReinTags { get; } = new ElementId(BuiltInCategory.OST_PathReinTags);

    /// <summary>
    /// 配电盘明细表图形
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PanelScheduleGraphics"/></para>
    /// </summary>
    public static ElementId PanelScheduleGraphics { get; } = new ElementId(BuiltInCategory.OST_PanelScheduleGraphics);

    /// <summary>
    /// 家具系统
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FurnitureSystems"/></para>
    /// </summary>
    public static ElementId FurnitureSystems { get; } = new ElementId(BuiltInCategory.OST_FurnitureSystems);

    /// <summary>
    /// 云线批注
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RevisionClouds"/></para>
    /// </summary>
    public static ElementId RevisionClouds { get; } = new ElementId(BuiltInCategory.OST_RevisionClouds);

    /// <summary>
    /// 分析表面
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AnalyticSurfaces"/></para>
    /// </summary>
    public static ElementId AnalyticSurfaces { get; } = new ElementId(BuiltInCategory.OST_AnalyticSurfaces);

    /// <summary>
    /// 管道占位符
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlaceHolderPipes"/></para>
    /// </summary>
    public static ElementId PlaceHolderPipes { get; } = new ElementId(BuiltInCategory.OST_PlaceHolderPipes);

    /// <summary>
    /// 风管附件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctAccessoryTags"/></para>
    /// </summary>
    public static ElementId DuctAccessoryTags { get; } = new ElementId(BuiltInCategory.OST_DuctAccessoryTags);

    /// <summary>
    /// 风管管件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctFittingTags"/></para>
    /// </summary>
    public static ElementId DuctFittingTags { get; } = new ElementId(BuiltInCategory.OST_DuctFittingTags);

    /// <summary>
    /// 线管配件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ConduitFittingTags"/></para>
    /// </summary>
    public static ElementId ConduitFittingTags { get; } = new ElementId(BuiltInCategory.OST_ConduitFittingTags);

    /// <summary>
    /// 连接符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnectionSymbols"/></para>
    /// </summary>
    public static ElementId StructConnectionSymbols { get; } = new ElementId(BuiltInCategory.OST_StructConnectionSymbols);

    /// <summary>
    /// 橱柜
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Casework"/></para>
    /// </summary>
    public static ElementId Casework { get; } = new ElementId(BuiltInCategory.OST_Casework);

    /// <summary>
    /// 在族中导入
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ImportObjectStyles"/></para>
    /// </summary>
    public static ElementId ImportObjectStyles { get; } = new ElementId(BuiltInCategory.OST_ImportObjectStyles);

    /// <summary>
    /// 组成部分
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Parts"/></para>
    /// </summary>
    public static ElementId Parts { get; } = new ElementId(BuiltInCategory.OST_Parts);

    /// <summary>
    /// 点云
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PointClouds"/></para>
    /// </summary>
    public static ElementId PointClouds { get; } = new ElementId(BuiltInCategory.OST_PointClouds);

    /// <summary>
    /// 安全设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SecurityDevices"/></para>
    /// </summary>
    public static ElementId SecurityDevices { get; } = new ElementId(BuiltInCategory.OST_SecurityDevices);

    /// <summary>
    /// 常规注释
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_GenericAnnotation"/></para>
    /// </summary>
    public static ElementId GenericAnnotation { get; } = new ElementId(BuiltInCategory.OST_GenericAnnotation);

    /// <summary>
    /// 分析楼层标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FloorAnalyticalTags"/></para>
    /// </summary>
    public static ElementId FloorAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_FloorAnalyticalTags);

    /// <summary>
    /// 分析条形基础标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WallFoundationAnalyticalTags"/></para>
    /// </summary>
    public static ElementId WallFoundationAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_WallFoundationAnalyticalTags);

    /// <summary>
    /// 等高线标签
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ContourLabels"/></para>
    /// </summary>
    public static ElementId ContourLabels { get; } = new ElementId(BuiltInCategory.OST_ContourLabels);

    /// <summary>
    /// 风管隔热层标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctInsulationsTags"/></para>
    /// </summary>
    public static ElementId DuctInsulationsTags { get; } = new ElementId(BuiltInCategory.OST_DuctInsulationsTags);

    /// <summary>
    /// 电气装置标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ElectricalFixtureTags"/></para>
    /// </summary>
    public static ElementId ElectricalFixtureTags { get; } = new ElementId(BuiltInCategory.OST_ElectricalFixtureTags);

    /// <summary>
    /// 环境
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Entourage"/></para>
    /// </summary>
    public static ElementId Entourage { get; } = new ElementId(BuiltInCategory.OST_Entourage);

    /// <summary>
    /// 标高
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Levels"/></para>
    /// </summary>
    public static ElementId Levels { get; } = new ElementId(BuiltInCategory.OST_Levels);

    /// <summary>
    /// 轴网
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Grids"/></para>
    /// </summary>
    public static ElementId Grids { get; } = new ElementId(BuiltInCategory.OST_Grids);

    /// <summary>
    /// 结构荷载工况
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LoadCases"/></para>
    /// </summary>
    public static ElementId LoadCases { get; } = new ElementId(BuiltInCategory.OST_LoadCases);

    /// <summary>
    /// 结构钢筋标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RebarTags"/></para>
    /// </summary>
    public static ElementId RebarTags { get; } = new ElementId(BuiltInCategory.OST_RebarTags);

    /// <summary>
    /// 明细表图形
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ScheduleGraphics"/></para>
    /// </summary>
    public static ElementId ScheduleGraphics { get; } = new ElementId(BuiltInCategory.OST_ScheduleGraphics);

    /// <summary>
    /// 楼梯支撑标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsSupportTags"/></para>
    /// </summary>
    public static ElementId StairsSupportTags { get; } = new ElementId(BuiltInCategory.OST_StairsSupportTags);

    /// <summary>
    /// 场地标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SiteTags"/></para>
    /// </summary>
    public static ElementId SiteTags { get; } = new ElementId(BuiltInCategory.OST_SiteTags);

    /// <summary>
    /// 结构路径钢筋
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PathRein"/></para>
    /// </summary>
    public static ElementId PathRein { get; } = new ElementId(BuiltInCategory.OST_PathRein);

    /// <summary>
    /// 电气设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ElectricalEquipment"/></para>
    /// </summary>
    public static ElementId ElectricalEquipment { get; } = new ElementId(BuiltInCategory.OST_ElectricalEquipment);

    /// <summary>
    /// 通讯设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CommunicationDeviceTags"/></para>
    /// </summary>
    public static ElementId CommunicationDeviceTags { get; } = new ElementId(BuiltInCategory.OST_CommunicationDeviceTags);

    /// <summary>
    /// 电缆桥架配件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CableTrayFittingTags"/></para>
    /// </summary>
    public static ElementId CableTrayFittingTags { get; } = new ElementId(BuiltInCategory.OST_CableTrayFittingTags);

    /// <summary>
    /// 结构钢筋
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Rebar"/></para>
    /// </summary>
    public static ElementId Rebar { get; } = new ElementId(BuiltInCategory.OST_Rebar);

    /// <summary>
    /// 分析节点
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AnalyticalNodes"/></para>
    /// </summary>
    public static ElementId AnalyticalNodes { get; } = new ElementId(BuiltInCategory.OST_AnalyticalNodes);

    /// <summary>
    /// 分析墙标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WallAnalyticalTags"/></para>
    /// </summary>
    public static ElementId WallAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_WallAnalyticalTags);

    /// <summary>
    /// 分析梁标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BeamAnalyticalTags"/></para>
    /// </summary>
    public static ElementId BeamAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_BeamAnalyticalTags);

    /// <summary>
    /// 分析柱标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ColumnAnalyticalTags"/></para>
    /// </summary>
    public static ElementId ColumnAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_ColumnAnalyticalTags);

    /// <summary>
    /// 结构区域钢筋
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AreaRein"/></para>
    /// </summary>
    public static ElementId AreaRein { get; } = new ElementId(BuiltInCategory.OST_AreaRein);

    /// <summary>
    /// RVT 链接
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RvtLinks"/></para>
    /// </summary>
    public static ElementId RvtLinks { get; } = new ElementId(BuiltInCategory.OST_RvtLinks);

    /// <summary>
    /// 结构注释
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralAnnotations"/></para>
    /// </summary>
    public static ElementId StructuralAnnotations { get; } = new ElementId(BuiltInCategory.OST_StructuralAnnotations);

    /// <summary>
    /// 分析链接
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LinksAnalytical"/></para>
    /// </summary>
    public static ElementId LinksAnalytical { get; } = new ElementId(BuiltInCategory.OST_LinksAnalytical);

    /// <summary>
    /// 面积标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AreaTags"/></para>
    /// </summary>
    public static ElementId AreaTags { get; } = new ElementId(BuiltInCategory.OST_AreaTags);

    /// <summary>
    /// 结构钢筋网
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricReinforcement"/></para>
    /// </summary>
    public static ElementId FabricReinforcement { get; } = new ElementId(BuiltInCategory.OST_FabricReinforcement);

    /// <summary>
    /// 植物标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlantingTags"/></para>
    /// </summary>
    public static ElementId PlantingTags { get; } = new ElementId(BuiltInCategory.OST_PlantingTags);

    /// <summary>
    /// 基础跨方向符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FootingSpanDirectionSymbol"/></para>
    /// </summary>
    public static ElementId FootingSpanDirectionSymbol { get; } = new ElementId(BuiltInCategory.OST_FootingSpanDirectionSymbol);

    /// <summary>
    /// 分析墙
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WallAnalytical"/></para>
    /// </summary>
    public static ElementId WallAnalytical { get; } = new ElementId(BuiltInCategory.OST_WallAnalytical);

    /// <summary>
    /// 分析梁
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BeamAnalytical"/></para>
    /// </summary>
    public static ElementId BeamAnalytical { get; } = new ElementId(BuiltInCategory.OST_BeamAnalytical);

    /// <summary>
    /// 分析柱
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ColumnAnalytical"/></para>
    /// </summary>
    public static ElementId ColumnAnalytical { get; } = new ElementId(BuiltInCategory.OST_ColumnAnalytical);

    /// <summary>
    /// 属性标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SitePropertyTags"/></para>
    /// </summary>
    public static ElementId SitePropertyTags { get; } = new ElementId(BuiltInCategory.OST_SitePropertyTags);

    /// <summary>
    /// 结构基础
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFoundation"/></para>
    /// </summary>
    public static ElementId StructuralFoundation { get; } = new ElementId(BuiltInCategory.OST_StructuralFoundation);

    /// <summary>
    /// 详图索引
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Callouts"/></para>
    /// </summary>
    public static ElementId Callouts { get; } = new ElementId(BuiltInCategory.OST_Callouts);

    /// <summary>
    /// 跨方向符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpanDirectionSymbol"/></para>
    /// </summary>
    public static ElementId SpanDirectionSymbol { get; } = new ElementId(BuiltInCategory.OST_SpanDirectionSymbol);

    /// <summary>
    /// 风管附件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctAccessory"/></para>
    /// </summary>
    public static ElementId DuctAccessory { get; } = new ElementId(BuiltInCategory.OST_DuctAccessory);

    /// <summary>
    /// 风管管件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctFitting"/></para>
    /// </summary>
    public static ElementId DuctFitting { get; } = new ElementId(BuiltInCategory.OST_DuctFitting);

    /// <summary>
    /// 线管配件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ConduitFitting"/></para>
    /// </summary>
    public static ElementId ConduitFitting { get; } = new ElementId(BuiltInCategory.OST_ConduitFitting);

    /// <summary>
    /// 栏杆扶手标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsRailingTags"/></para>
    /// </summary>
    public static ElementId StairsRailingTags { get; } = new ElementId(BuiltInCategory.OST_StairsRailingTags);

    /// <summary>
    /// 楼梯标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsTags"/></para>
    /// </summary>
    public static ElementId StairsTags { get; } = new ElementId(BuiltInCategory.OST_StairsTags);

    /// <summary>
    /// 门
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Doors"/></para>
    /// </summary>
    public static ElementId Doors { get; } = new ElementId(BuiltInCategory.OST_Doors);

    /// <summary>
    /// 线
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Lines"/></para>
    /// </summary>
    public static ElementId Lines { get; } = new ElementId(BuiltInCategory.OST_Lines);

    /// <summary>
    /// 窗
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Windows"/></para>
    /// </summary>
    public static ElementId Windows { get; } = new ElementId(BuiltInCategory.OST_Windows);

    /// <summary>
    /// 柱
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Columns"/></para>
    /// </summary>
    public static ElementId Columns { get; } = new ElementId(BuiltInCategory.OST_Columns);

    /// <summary>
    /// 墙
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Walls"/></para>
    /// </summary>
    public static ElementId Walls { get; } = new ElementId(BuiltInCategory.OST_Walls);

    /// <summary>
    /// 平面区域
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlanRegion"/></para>
    /// </summary>
    public static ElementId PlanRegion { get; } = new ElementId(BuiltInCategory.OST_PlanRegion);

    /// <summary>
    /// 详图项目
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DetailComponents"/></para>
    /// </summary>
    public static ElementId DetailComponents { get; } = new ElementId(BuiltInCategory.OST_DetailComponents);

    /// <summary>
    /// 高程点坡度
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpotSlopes"/></para>
    /// </summary>
    public static ElementId SpotSlopes { get; } = new ElementId(BuiltInCategory.OST_SpotSlopes);

    /// <summary>
    /// 拼接线
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Matchline"/></para>
    /// </summary>
    public static ElementId Matchline { get; } = new ElementId(BuiltInCategory.OST_Matchline);

    /// <summary>
    /// 结构钢筋网符号
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricReinSpanSymbol"/></para>
    /// </summary>
    public static ElementId FabricReinSpanSymbol { get; } = new ElementId(BuiltInCategory.OST_FabricReinSpanSymbol);

    /// <summary>
    /// 高程点
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpotElevations"/></para>
    /// </summary>
    public static ElementId SpotElevations { get; } = new ElementId(BuiltInCategory.OST_SpotElevations);

    /// <summary>
    /// 范围框
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_VolumeOfInterest"/></para>
    /// </summary>
    public static ElementId VolumeOfInterest { get; } = new ElementId(BuiltInCategory.OST_VolumeOfInterest);

    /// <summary>
    /// 分区标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ZoneTags"/></para>
    /// </summary>
    public static ElementId ZoneTags { get; } = new ElementId(BuiltInCategory.OST_ZoneTags);

    /// <summary>
    /// 建筑红线线段标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SitePropertyLineSegmentTags"/></para>
    /// </summary>
    public static ElementId SitePropertyLineSegmentTags { get; } = new ElementId(BuiltInCategory.OST_SitePropertyLineSegmentTags);

    /// <summary>
    /// 管件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeFitting"/></para>
    /// </summary>
    public static ElementId PipeFitting { get; } = new ElementId(BuiltInCategory.OST_PipeFitting);

    /// <summary>
    /// 结构梁系统
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFramingSystem"/></para>
    /// </summary>
    public static ElementId StructuralFramingSystem { get; } = new ElementId(BuiltInCategory.OST_StructuralFramingSystem);

    /// <summary>
    /// 楼梯
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Stairs"/></para>
    /// </summary>
    public static ElementId Stairs { get; } = new ElementId(BuiltInCategory.OST_Stairs);

    /// <summary>
    /// 云线批注标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RevisionCloudTags"/></para>
    /// </summary>
    public static ElementId RevisionCloudTags { get; } = new ElementId(BuiltInCategory.OST_RevisionCloudTags);

    /// <summary>
    /// 风管占位符
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlaceHolderDucts"/></para>
    /// </summary>
    public static ElementId PlaceHolderDucts { get; } = new ElementId(BuiltInCategory.OST_PlaceHolderDucts);

    /// <summary>
    /// 空间标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MEPSpaceTags"/></para>
    /// </summary>
    public static ElementId MEPSpaceTags { get; } = new ElementId(BuiltInCategory.OST_MEPSpaceTags);

    /// <summary>
    /// 房间标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RoomTags"/></para>
    /// </summary>
    public static ElementId RoomTags { get; } = new ElementId(BuiltInCategory.OST_RoomTags);

    /// <summary>
    /// 导向轴网
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_GuideGrid"/></para>
    /// </summary>
    public static ElementId GuideGrid { get; } = new ElementId(BuiltInCategory.OST_GuideGrid);

    /// <summary>
    /// 栏杆扶手
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsRailing"/></para>
    /// </summary>
    public static ElementId StairsRailing { get; } = new ElementId(BuiltInCategory.OST_StairsRailing);

    /// <summary>
    /// 体量
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Mass"/></para>
    /// </summary>
    public static ElementId Mass { get; } = new ElementId(BuiltInCategory.OST_Mass);

    /// <summary>
    /// 楼梯踏板/踢面数
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsTriserNumbers"/></para>
    /// </summary>
    public static ElementId StairsTriserNumbers { get; } = new ElementId(BuiltInCategory.OST_StairsTriserNumbers);

    /// <summary>
    /// 楼梯梯段标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsRunTags"/></para>
    /// </summary>
    public static ElementId StairsRunTags { get; } = new ElementId(BuiltInCategory.OST_StairsRunTags);

    /// <summary>
    /// 灯具标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LightingDeviceTags"/></para>
    /// </summary>
    public static ElementId LightingDeviceTags { get; } = new ElementId(BuiltInCategory.OST_LightingDeviceTags);

    /// <summary>
    /// 家具标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FurnitureTags"/></para>
    /// </summary>
    public static ElementId FurnitureTags { get; } = new ElementId(BuiltInCategory.OST_FurnitureTags);

    /// <summary>
    /// 风道末端标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctTerminalTags"/></para>
    /// </summary>
    public static ElementId DuctTerminalTags { get; } = new ElementId(BuiltInCategory.OST_DuctTerminalTags);

    /// <summary>
    /// 楼板
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Floors"/></para>
    /// </summary>
    public static ElementId Floors { get; } = new ElementId(BuiltInCategory.OST_Floors);

    /// <summary>
    /// 楼梯平台标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StairsLandingTags"/></para>
    /// </summary>
    public static ElementId StairsLandingTags { get; } = new ElementId(BuiltInCategory.OST_StairsLandingTags);

    /// <summary>
    /// 风道末端
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctTerminal"/></para>
    /// </summary>
    public static ElementId DuctTerminal { get; } = new ElementId(BuiltInCategory.OST_DuctTerminal);

    /// <summary>
    /// 分析楼层
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FloorAnalytical"/></para>
    /// </summary>
    public static ElementId FloorAnalytical { get; } = new ElementId(BuiltInCategory.OST_FloorAnalytical);

    /// <summary>
    /// 分析链接标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LinkAnalyticalTags"/></para>
    /// </summary>
    public static ElementId LinkAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_LinkAnalyticalTags);

    /// <summary>
    /// 风管内衬标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctLiningsTags"/></para>
    /// </summary>
    public static ElementId DuctLiningsTags { get; } = new ElementId(BuiltInCategory.OST_DuctLiningsTags);

    /// <summary>
    /// 电缆桥架标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CableTrayTags"/></para>
    /// </summary>
    public static ElementId CableTrayTags { get; } = new ElementId(BuiltInCategory.OST_CableTrayTags);

    /// <summary>
    /// 护理呼叫设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_NurseCallDevices"/></para>
    /// </summary>
    public static ElementId NurseCallDevices { get; } = new ElementId(BuiltInCategory.OST_NurseCallDevices);

    /// <summary>
    /// 机械设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_MechanicalEquipment"/></para>
    /// </summary>
    public static ElementId MechanicalEquipment { get; } = new ElementId(BuiltInCategory.OST_MechanicalEquipment);

    /// <summary>
    /// 高程点坐标
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpotCoordinates"/></para>
    /// </summary>
    public static ElementId SpotCoordinates { get; } = new ElementId(BuiltInCategory.OST_SpotCoordinates);

    /// <summary>
    /// 通讯设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CommunicationDevices"/></para>
    /// </summary>
    public static ElementId CommunicationDevices { get; } = new ElementId(BuiltInCategory.OST_CommunicationDevices);

    /// <summary>
    /// 结构连接
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructConnections"/></para>
    /// </summary>
    public static ElementId StructConnections { get; } = new ElementId(BuiltInCategory.OST_StructConnections);

    /// <summary>
    /// 管道附件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeAccessory"/></para>
    /// </summary>
    public static ElementId PipeAccessory { get; } = new ElementId(BuiltInCategory.OST_PipeAccessory);

    /// <summary>
    /// 停车场
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Parking"/></para>
    /// </summary>
    public static ElementId Parking { get; } = new ElementId(BuiltInCategory.OST_Parking);

    /// <summary>
    /// 结构钢筋网区域
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FabricAreas"/></para>
    /// </summary>
    public static ElementId FabricAreas { get; } = new ElementId(BuiltInCategory.OST_FabricAreas);

    /// <summary>
    /// 风管隔热层
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctInsulations"/></para>
    /// </summary>
    public static ElementId DuctInsulations { get; } = new ElementId(BuiltInCategory.OST_DuctInsulations);

    /// <summary>
    /// 数据设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DataDevices"/></para>
    /// </summary>
    public static ElementId DataDevices { get; } = new ElementId(BuiltInCategory.OST_DataDevices);

    /// <summary>
    /// 管道颜色填充图例
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeColorFillLegends"/></para>
    /// </summary>
    public static ElementId PipeColorFillLegends { get; } = new ElementId(BuiltInCategory.OST_PipeColorFillLegends);

    /// <summary>
    /// 安全设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SecurityDeviceTags"/></para>
    /// </summary>
    public static ElementId SecurityDeviceTags { get; } = new ElementId(BuiltInCategory.OST_SecurityDeviceTags);

    /// <summary>
    /// 结构加强板标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_StructuralStiffenerTags"/></para>
    /// </summary>
    public static ElementId StructuralStiffenerTags { get; } = new ElementId(BuiltInCategory.OST_StructuralStiffenerTags);

    /// <summary>
    /// 面荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AreaLoadTags"/></para>
    /// </summary>
    public static ElementId AreaLoadTags { get; } = new ElementId(BuiltInCategory.OST_AreaLoadTags);

    /// <summary>
    /// 电气设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_ElectricalEquipmentTags"/></para>
    /// </summary>
    public static ElementId ElectricalEquipmentTags { get; } = new ElementId(BuiltInCategory.OST_ElectricalEquipmentTags);

    /// <summary>
    /// 卫浴装置标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlumbingFixtureTags"/></para>
    /// </summary>
    public static ElementId PlumbingFixtureTags { get; } = new ElementId(BuiltInCategory.OST_PlumbingFixtureTags);

    /// <summary>
    /// 图框
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_TitleBlocks"/></para>
    /// </summary>
    public static ElementId TitleBlocks { get; } = new ElementId(BuiltInCategory.OST_TitleBlocks);

    /// <summary>
    /// 植物
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Planting"/></para>
    /// </summary>
    public static ElementId Planting { get; } = new ElementId(BuiltInCategory.OST_Planting);

    /// <summary>
    /// 点荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PointLoadTags"/></para>
    /// </summary>
    public static ElementId PointLoadTags { get; } = new ElementId(BuiltInCategory.OST_PointLoadTags);

    /// <summary>
    /// 风管颜色填充图例
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_DuctColorFillLegends"/></para>
    /// </summary>
    public static ElementId DuctColorFillLegends { get; } = new ElementId(BuiltInCategory.OST_DuctColorFillLegends);

    /// <summary>
    /// 线荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LineLoadTags"/></para>
    /// </summary>
    public static ElementId LineLoadTags { get; } = new ElementId(BuiltInCategory.OST_LineLoadTags);

    /// <summary>
    /// 分析楼板基础标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FoundationSlabAnalyticalTags"/></para>
    /// </summary>
    public static ElementId FoundationSlabAnalyticalTags { get; } = new ElementId(BuiltInCategory.OST_FoundationSlabAnalyticalTags);

    /// <summary>
    /// 幕墙系统
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CurtaSystem"/></para>
    /// </summary>
    public static ElementId CurtaSystem { get; } = new ElementId(BuiltInCategory.OST_CurtaSystem);

    /// <summary>
    /// 分析支撑
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BraceAnalytical"/></para>
    /// </summary>
    public static ElementId BraceAnalytical { get; } = new ElementId(BuiltInCategory.OST_BraceAnalytical);

    /// <summary>
    /// 管道颜色填充
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeColorFills"/></para>
    /// </summary>
    public static ElementId PipeColorFills { get; } = new ElementId(BuiltInCategory.OST_PipeColorFills);

    /// <summary>
    /// 结构内部荷载
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_InternalLoads"/></para>
    /// </summary>
    public static ElementId InternalLoads { get; } = new ElementId(BuiltInCategory.OST_InternalLoads);

    /// <summary>
    /// 喷头标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SprinklerTags"/></para>
    /// </summary>
    public static ElementId SprinklerTags { get; } = new ElementId(BuiltInCategory.OST_SprinklerTags);

    /// <summary>
    /// 照明设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_LightingFixtureTags"/></para>
    /// </summary>
    public static ElementId LightingFixtureTags { get; } = new ElementId(BuiltInCategory.OST_LightingFixtureTags);

    /// <summary>
    /// 卫浴装置
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PlumbingFixtures"/></para>
    /// </summary>
    public static ElementId PlumbingFixtures { get; } = new ElementId(BuiltInCategory.OST_PlumbingFixtures);

    /// <summary>
    /// 橱柜标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CaseworkTags"/></para>
    /// </summary>
    public static ElementId CaseworkTags { get; } = new ElementId(BuiltInCategory.OST_CaseworkTags);

    /// <summary>
    /// 常规模型
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_GenericModel"/></para>
    /// </summary>
    public static ElementId GenericModel { get; } = new ElementId(BuiltInCategory.OST_GenericModel);

    /// <summary>
    /// 火警设备标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FireAlarmDeviceTags"/></para>
    /// </summary>
    public static ElementId FireAlarmDeviceTags { get; } = new ElementId(BuiltInCategory.OST_FireAlarmDeviceTags);

    /// <summary>
    /// 内部线荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_InternalLineLoadTags"/></para>
    /// </summary>
    public static ElementId InternalLineLoadTags { get; } = new ElementId(BuiltInCategory.OST_InternalLineLoadTags);

    /// <summary>
    /// 内部点荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_InternalPointLoadTags"/></para>
    /// </summary>
    public static ElementId InternalPointLoadTags { get; } = new ElementId(BuiltInCategory.OST_InternalPointLoadTags);

    /// <summary>
    /// 专用设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SpecialityEquipment"/></para>
    /// </summary>
    public static ElementId SpecialityEquipment { get; } = new ElementId(BuiltInCategory.OST_SpecialityEquipment);

    /// <summary>
    /// 火警设备
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_FireAlarmDevices"/></para>
    /// </summary>
    public static ElementId FireAlarmDevices { get; } = new ElementId(BuiltInCategory.OST_FireAlarmDevices);

    /// <summary>
    /// 管道隔热层标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_PipeInsulationsTags"/></para>
    /// </summary>
    public static ElementId PipeInsulationsTags { get; } = new ElementId(BuiltInCategory.OST_PipeInsulationsTags);

    /// <summary>
    /// 天花板
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Ceilings"/></para>
    /// </summary>
    public static ElementId Ceilings { get; } = new ElementId(BuiltInCategory.OST_Ceilings);

    /// <summary>
    /// 幕墙竖梃
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CurtainWallMullions"/></para>
    /// </summary>
    public static ElementId CurtainWallMullions { get; } = new ElementId(BuiltInCategory.OST_CurtainWallMullions);

    /// <summary>
    /// 立面
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Elev"/></para>
    /// </summary>
    public static ElementId Elev { get; } = new ElementId(BuiltInCategory.OST_Elev);

    /// <summary>
    /// 剖面
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Sections"/></para>
    /// </summary>
    public static ElementId Sections { get; } = new ElementId(BuiltInCategory.OST_Sections);

    /// <summary>
    /// 剖面框
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_SectionBox"/></para>
    /// </summary>
    public static ElementId SectionBox { get; } = new ElementId(BuiltInCategory.OST_SectionBox);

    /// <summary>
    /// 内部面荷载标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_InternalAreaLoadTags"/></para>
    /// </summary>
    public static ElementId InternalAreaLoadTags { get; } = new ElementId(BuiltInCategory.OST_InternalAreaLoadTags);

    /// <summary>
    /// 光栅图像
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_RasterImages"/></para>
    /// </summary>
    public static ElementId RasterImages { get; } = new ElementId(BuiltInCategory.OST_RasterImages);

    /// <summary>
    /// 注释记号标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_KeynoteTags"/></para>
    /// </summary>
    public static ElementId KeynoteTags { get; } = new ElementId(BuiltInCategory.OST_KeynoteTags);

    /// <summary>
    /// 结构梁系统标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_BeamSystemTags"/></para>
    /// </summary>
    public static ElementId BeamSystemTags { get; } = new ElementId(BuiltInCategory.OST_BeamSystemTags);

    /// <summary>
    /// 参照平面
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CLines"/></para>
    /// </summary>
    public static ElementId CLines { get; } = new ElementId(BuiltInCategory.OST_CLines);

    /// <summary>
    /// 幕墙嵌板
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CurtainWallPanels"/></para>
    /// </summary>
    public static ElementId CurtainWallPanels { get; } = new ElementId(BuiltInCategory.OST_CurtainWallPanels);

    /// <summary>
    /// 幕墙嵌板标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CurtainWallPanelTags"/></para>
    /// </summary>
    public static ElementId CurtainWallPanelTags { get; } = new ElementId(BuiltInCategory.OST_CurtainWallPanelTags);

    /// <summary>
    /// 结构荷载
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Loads"/></para>
    /// </summary>
    public static ElementId Loads { get; } = new ElementId(BuiltInCategory.OST_Loads);

    /// <summary>
    /// 道路
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Roads"/></para>
    /// </summary>
    public static ElementId Roads { get; } = new ElementId(BuiltInCategory.OST_Roads);

    /// <summary>
    /// 分析空间
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AnalyticSpaces"/></para>
    /// </summary>
    public static ElementId AnalyticSpaces { get; } = new ElementId(BuiltInCategory.OST_AnalyticSpaces);

    /// <summary>
    /// 结构区域钢筋标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AreaReinTags"/></para>
    /// </summary>
    public static ElementId AreaReinTags { get; } = new ElementId(BuiltInCategory.OST_AreaReinTags);

    /// <summary>
    /// 天花板标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_CeilingTags"/></para>
    /// </summary>
    public static ElementId CeilingTags { get; } = new ElementId(BuiltInCategory.OST_CeilingTags);

    /// <summary>
    /// 导线标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_WireTags"/></para>
    /// </summary>
    public static ElementId WireTags { get; } = new ElementId(BuiltInCategory.OST_WireTags);

    /// <summary>
    /// 部件
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_Assemblies"/></para>
    /// </summary>
    public static ElementId Assemblies { get; } = new ElementId(BuiltInCategory.OST_Assemblies);

    /// <summary>
    /// 部件原点
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AssemblyOrigin"/></para>
    /// </summary>
    public static ElementId AssemblyOrigin { get; } = new ElementId(BuiltInCategory.OST_AssemblyOrigin);

    /// <summary>
    /// 
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AssemblyOrigin_Lines"/></para>
    /// </summary>
    public static ElementId AssemblyOrigin_Lines { get; } = new ElementId(BuiltInCategory.OST_AssemblyOrigin_Lines);

    /// <summary>
    /// 
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AssemblyOrigin_Planes"/></para>
    /// </summary>
    public static ElementId AssemblyOrigin_Planes { get; } = new ElementId(BuiltInCategory.OST_AssemblyOrigin_Planes);

    /// <summary>
    /// 
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AssemblyOrigin_Points"/></para>
    /// </summary>
    public static ElementId AssemblyOrigin_Points { get; } = new ElementId(BuiltInCategory.OST_AssemblyOrigin_Points);

    /// <summary>
    /// 部件标记
    /// <para><see cref="Autodesk.Revit.DB.BuiltInCategory.OST_AssemblyTags"/></para>
    /// </summary>
    public static ElementId AssemblyTags { get; } = new ElementId(BuiltInCategory.OST_AssemblyTags);

    /// <summary>
    /// 根据视图的规程过滤出可见性相关的类别<see cref="Autodesk.Revit.DB.ElementId"/>
    /// <para>Get category <see cref="Autodesk.Revit.DB.ElementId"/> by <see cref="Autodesk.Revit.DB.ViewDiscipline"/></para>
    /// </summary>
    /// <remarks>
    /// 集合中的类别不包括子类别
    /// <para>categories in the collection do not include subcategory</para>
    /// </remarks>
    /// <param name="viewDiscipline">要过滤的视图规程</param>
    /// <returns>与视图规程相关的类别集合</returns>
    public static List<ElementId> GetCategoryIdsByViewDiscipline(ViewDiscipline viewDiscipline) => viewDiscipline switch
    {
        ViewDiscipline.Architectural => ArchitecturalCategories,
        ViewDiscipline.Structural => StructuralCategories,
        ViewDiscipline.Mechanical => MechanicalCategories,
        ViewDiscipline.Electrical => ElectricalCategories,
        ViewDiscipline.Plumbing => PlumbingCategories,
        _ => Enumerable.Empty<ElementId>().ToList(),
    };

    /// <summary>
    /// 建筑
    /// </summary>
    public static readonly List<ElementId> ArchitecturalCategories = new List<ElementId>()
    {
        Furniture,
        LightingFixtures,
        ElectricalFixtures,
        Ramps,
        Topography,
        Site,
        Roofs,
        ShaftOpening,
        Areas,
        StructuralColumns,
        StructuralStiffener,
        StructuralFraming,
#if !Rvt_16
         Coupler,
#endif
        FurnitureSystems,
        Casework,
        Parts,
        Entourage,
        ElectricalEquipment,
        Rebar,
        StructuralFoundation,
        Doors,
        Lines,
        Windows,
        Columns,
        Walls,
        DetailComponents,
        StructuralFramingSystem,
        Stairs,
        StairsRailing,
        Mass,
        Floors,
        MechanicalEquipment,
        StructConnections,
        Parking,
        Planting,
        CurtaSystem,
        PlumbingFixtures,
        GenericModel,
        SpecialityEquipment,
        Ceilings,
        CurtainWallMullions,
        RasterImages,
        CurtainWallPanels,
        Roads,
    };

    /// <summary>
    /// 结构
    /// </summary>
    public static readonly List<ElementId> StructuralCategories = new List<ElementId>()
    {
        Ramps,
        Roofs,
        ShaftOpening,
        StructuralColumns,
        StructuralStiffener,
        StructuralFraming,
        StructuralTruss,
#if !Rvt_16
        Coupler,
#endif
        Parts,
        PathRein,
        Rebar,
        AreaRein,
        FabricReinforcement,
        StructuralFoundation,
        Lines,
        Columns,
        Walls,
        DetailComponents,
        StructuralFramingSystem,
        Stairs,
        Mass,
        Floors,
        StructConnections,
        FabricAreas,
        GenericModel,
        RasterImages,
    };

    /// <summary>
    /// 机械
    /// </summary>
    public static readonly List<ElementId> MechanicalCategories = new List<ElementId>()
    {
        Areas,
        FlexDuctCurves,
        DuctLinings,
        DuctCurves,
        Parts,
#if !Rvt_16
        FabricationDuctwork,
        FabricationHangers,
#endif
        DuctAccessory,
        DuctFitting,
        Lines,
        DetailComponents,
        PlaceHolderDucts,
        Mass,
        DuctTerminal,
        MechanicalEquipment,
        DuctInsulations,
        GenericModel,
        RasterImages,
    };

    /// <summary>
    /// 电气
    /// </summary>
    public static readonly List<ElementId> ElectricalCategories = new List<ElementId>()
    {
#if !Rvt_16
        FabricationHangers,
        FabricationContainment,
#endif
        LightingDevices,
        CableTrayFitting,
        LightingFixtures,
        ElectricalFixtures,
        CableTray,
        Areas,
        TelephoneDevices,
        Wire,
        Conduit,
        Parts,
        SecurityDevices,
        ElectricalEquipment,
        ConduitFitting,
        Lines,
        DetailComponents,
        Mass,
        NurseCallDevices,
        CommunicationDevices,
        DataDevices,
        GenericModel,
        FireAlarmDevices,
        RasterImages,
    };

    /// <summary>
    /// 管道
    /// </summary>
    public static readonly List<ElementId> PlumbingCategories = new List<ElementId>()
    {
#if !Rvt_16
        FabricationDuctwork,
        FabricationHangers,
        FabricationPipework,
#endif
        PipeInsulations,
        PipeCurves,
        Sprinklers,
        Areas,
        FlexPipeCurves,
        PlaceHolderPipes,
        Parts,
        Lines,
        DetailComponents,
        PipeFitting,
        Mass,
        MechanicalEquipment,
        PipeAccessory,
        PlumbingFixtures,
        GenericModel,
        RasterImages,
    };
}
