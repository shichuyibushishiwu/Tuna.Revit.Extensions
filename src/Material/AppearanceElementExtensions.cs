/************************************************************************************
   Author:十五
   CretaeTime:2025年5月5日 00点16分
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/


using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// Revit Appearance Element
/// </summary>
public static class AppearanceElementExtensions
{
    /// <summary>
    /// create a revit generic material appearance element
    /// </summary>
    /// <param name="document"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="System.ArgumentNullException"></exception>
    public static AppearanceAssetElement? CreateAppearanceElement(this Document document, string name)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(document);

        if (string.IsNullOrEmpty(name))
        {
            throw new System.ArgumentNullException(nameof(name), "name can not be null");
        }

        AppearanceAssetElement? newAppearance = null;

#if Rvt_16 || Rvt_17
        Asset genericAsset = document.Application.get_Assets(AssetType.Appearance).Cast<Asset>().Where(x => x.Name == "Generic").FirstOrDefault();
#else
        Asset? genericAsset = document.Application.GetAssets(AssetType.Appearance).Where(x => x.Name == "Generic").FirstOrDefault();
#endif

        if (genericAsset != null)
        {
            newAppearance = AppearanceAssetElement.Create(document, name, genericAsset);
        }
        else
        {
            AppearanceAssetElement? appearance = document.GetElements<AppearanceAssetElement>().FirstOrDefault();
            if (appearance != null)
            {
#if Rvt_16 || Rvt_17
                newAppearance = AppearanceAssetElement.Create(document, document.GetUniqueName<AppearanceAssetElement>(name), appearance.GetRenderingAsset());
#else
                newAppearance = appearance.Duplicate(name);
#endif
            }
        }


        return newAppearance;
    }




    /// <summary>
    ///    /// <exception cref="System.ArgumentNullException"></exception>
    /// </summary>
    /// <param name="material"></param>
    /// <returns></returns>
    public static AppearanceAssetElement? GetAppearanceAssetElement(this Material material)
    {
        ArgumentNullExceptionUtils.ThrowIfNullOrInvalid(material);

        ElementId appearanceAssetId = material.AppearanceAssetId;
        if (appearanceAssetId == ElementId.InvalidElementId)
        {
            return default;
        }


        return material.Document.GetElement<AppearanceAssetElement>(appearanceAssetId);
    }
}
