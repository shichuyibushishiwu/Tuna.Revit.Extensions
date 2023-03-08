///************************************************************************************
///   Author:十五
///   CretaeTime:2021/11/19 21:41:53
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
#if Rvt_18|| Rvt_19|| Rvt_20 ||Rvt_21 ||Rvt_22 ||Rvt_23
using Autodesk.Revit.DB.Visual;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension
{
    public static class DocumentExtension
    {
        public static AppearanceAssetElement CreateAppearanceElement(this Document document, string name)
        {
            AppearanceAssetElement newAppearance = null;

            Asset genericAsset = document.Application.GetAssets(AssetType.Appearance)
                .Where(x => x.Name == "Generic")
                .FirstOrDefault();

            if (genericAsset != null)
            {
                newAppearance = AppearanceAssetElement.Create(document, name, genericAsset);
            }
            else
            {
                AppearanceAssetElement appearance = document.GetElements<AppearanceAssetElement>().FirstOrDefault();
                if (appearance != null)
                {
                    newAppearance = appearance.Duplicate(name);
                }
            }
            return newAppearance;
        }
    }
}
