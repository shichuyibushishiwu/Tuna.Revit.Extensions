///************************************************************************************
///   Author:十五
///   CretaeTime:2022/4/28 12:29:31
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************


using Autodesk.Revit.DB;

#if Rvt_16|| Rvt_17
using Autodesk.Revit.Utility;
#else
using Autodesk.Revit.DB.Visual;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class MaterialExtension
    {
        public static Color GetAppearanceColor(this Material material)
        {
            if (material == null || !material.IsValidObject)
            {
                throw new ArgumentNullException("material is null or invalid material");
            }

            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId != ElementId.InvalidElementId)
            {
                AppearanceAssetElement appearanceAssetElement = material.Document.GetElement(appearanceAssetId) as AppearanceAssetElement;
                Asset asset = appearanceAssetElement.GetRenderingAsset();

#if Rvt_16 || Rvt_17
                var assetProperty = asset["generic_diffuse"];
#else
                var assetProperty = asset?.FindByName("generic_diffuse");
#endif
                AssetPropertyDoubleArray4d genericDiffuseColor = (AssetPropertyDoubleArray4d)assetProperty;

#if Rvt_16 || Rvt_17
                DoubleArray array = genericDiffuseColor.Value;
                byte r = (byte)(array.get_Item(0) * 255);
                byte g = (byte)(array.get_Item(1) * 255);
                byte b = (byte)(array.get_Item(2) * 255);
                return new Color(r, g, b);
#else
                return genericDiffuseColor?.GetValueAsColor();
#endif
            }
            return null;
        }

#if Rvt_18||Rvt_19||Rvt_20||Rvt_21||Rvt_22||Rvt_23
        public static void SetAppearanceColor(this Material material, Color color)
        {
            if (material == null || !material.IsValidObject)
            {
                throw new ArgumentNullException("material is null or invalid material");
            }

            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId != ElementId.InvalidElementId)
            {
                using (AppearanceAssetEditScope scope = new AppearanceAssetEditScope(material.Document))
                {
                    Asset asset = scope.Start(appearanceAssetId);
                    AssetPropertyDoubleArray4d genericDiffuseColor = (AssetPropertyDoubleArray4d)asset?.FindByName("generic_diffuse");
                    genericDiffuseColor?.SetValueAsColor(color);
                    scope.Commit(true);
                }
            }
        }
#endif

    }
}
