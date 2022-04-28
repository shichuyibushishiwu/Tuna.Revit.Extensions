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
using Autodesk.Revit.DB.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Revit
{
    public static class MaterialExtension
    {
        public static Color GetAppearanceColor(this Material material)
        {
            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId?.IntegerValue != -1)
            {
                AppearanceAssetElement appearanceAssetElement = material.Document.GetElement(appearanceAssetId) as AppearanceAssetElement;
                Asset asset = appearanceAssetElement.GetRenderingAsset();
                AssetPropertyDoubleArray4d genericDiffuseColor = (AssetPropertyDoubleArray4d)asset?.FindByName("generic_diffuse");

                return genericDiffuseColor?.GetValueAsColor();
            }
            return null;
        }

        public static void SetAppearanceColor(this Material material, Color color)
        {
            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId?.IntegerValue != -1)
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
    }
}
