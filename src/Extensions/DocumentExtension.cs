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
    /// <summary>
    /// revit document extension
    /// </summary>
    public static class DocumentExtension
    {
        /// <summary>
        /// create a revit generic material appearance element
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static AppearanceAssetElement CreateAppearanceElement(this Document document, string name)
        {
            if (document == null || !document.IsValidObject)
            {
                throw new ArgumentNullException(nameof(document), "document can not be null");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "name can not be null");
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool ElementExist<T>(this Document document, Func<T, bool> predicate) where T : Element
        {
            return document.GetElements<T>().Any(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <param name="basicName"></param>
        /// <returns></returns>
        public static string GetUniqueName<T>(this Document document, string basicName) where T : Element
        {
            int number = 0;
            string name = basicName;
            while (document.ElementExist<T>(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                number++;
                name = $"{basicName}({number})";
            }
            return name;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="name"></param>
        /// <param name="ids"></param>
        /// <param name="filterRule"></param>
        /// <returns></returns>
        public static ParameterFilterElement CreateParameterFilterElement(this Document document, string name, ICollection<ElementId> ids, FilterRule filterRule)
        {
#if !Rvt_18
            ElementParameterFilter elementParameterFilter = new ElementParameterFilter(filterRule);
            return ParameterFilterElement.Create(document, name, ids, elementParameterFilter);

#else
            return ParameterFilterElement.Create(document, name, ids, new List<FilterRule>() { filterRule });
#endif
        }
    }
}
