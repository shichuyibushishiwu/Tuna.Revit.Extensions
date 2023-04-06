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


namespace Tuna.Revit.Extension
{
    public static class MaterialExtension
    {
        /// <summary>
        /// Get generic material appearance color
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Color GetAppearanceColor(this Material material)
        {
            if (material == null || !material.IsValidObject)
            {
                throw new ArgumentNullException(nameof(material), "material is null or invalid material");
            }

            Color color = Color.InvalidColorValue;
            ElementId appearanceAssetId = material.AppearanceAssetId;
            if (appearanceAssetId != ElementId.InvalidElementId)
            {
                AppearanceAssetElement appearanceAssetElement = material.Document.GetElement(appearanceAssetId) as AppearanceAssetElement;
                Asset asset = appearanceAssetElement.GetRenderingAsset();
                color = asset.GetColor();
            }
            return color;
        }


#if !Rvt_16 && !Rvt_17
        /// <summary>
        /// Set material appearance color
        /// </summary>
        /// <param name="material"></param>
        /// <param name="color"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetAppearanceColor(this Material material, Color color)
        {
            if (material == null || !material.IsValidObject)
            {
                throw new ArgumentNullException(nameof(material), "material is null or invalid material");
            }

            if (color == null || !color.IsValid)
            {
                throw new ArgumentNullException(nameof(color), "color can not be null or color is invalid");
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
