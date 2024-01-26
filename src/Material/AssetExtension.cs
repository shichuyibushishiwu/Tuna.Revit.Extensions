/************************************************************************************
   Author:十五
   CretaeTime:2023/4/3 23:57:38
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

#if Rvt_16|| Rvt_17
using Autodesk.Revit.Utility;
#else
using Autodesk.Revit.DB.Visual;
#endif

using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using System.IO;

namespace Tuna.Revit.Extension
{
    /// <summary>
    /// revit material asset extension
    /// </summary>
    public static class AssetExtension
    {
#if !Rvt_16 && !Rvt_17
        /// <summary>
        /// set generic asset property color value 
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="color"></param>
        public static void SetColor(this Asset asset, Color color)
        {
            AssetPropertyDoubleArray4d genericDiffuseColor = (AssetPropertyDoubleArray4d)asset.FindByName("generic_diffuse");
            genericDiffuseColor.SetValueAsColor(color);
        }

        /// <summary>
        /// set generic asset property transparency value 
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="transparency"></param>
        public static void SetTransparency(this Asset asset, int transparency)
        {
            AssetPropertyDouble genericTransparency = (AssetPropertyDouble)asset.FindByName("generic_transparency");
            genericTransparency.Value = Convert.ToDouble(transparency);
        }

        /// <summary>
        /// set generic asset property reflectivity value 
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="reflectivity"></param>
        public static void SetReflectivity(this Asset asset, int reflectivity)
        {
            AssetPropertyDouble genericReflectivityZero = (AssetPropertyDouble)asset.FindByName("generic_reflectivity_at_0deg");
            genericReflectivityZero.Value = Convert.ToDouble(reflectivity) / 100;

            AssetPropertyDouble genericReflectivityAngle = (AssetPropertyDouble)asset.FindByName("generic_reflectivity_at_90deg");
            genericReflectivityAngle.Value = Convert.ToDouble(reflectivity) / 100;
        }

        /// <summary>
        /// set generic asset property glossiness value
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="gloss"></param>
        public static void SetGlossiness(this Asset asset, int gloss)
        {
            AssetPropertyDouble glossProperty = (AssetPropertyDouble)asset.FindByName("generic_glossiness");
            glossProperty.Value = Convert.ToDouble(gloss) / 100;
        }

        /// <summary>
        /// add generic asset property texture path
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="texturePath"></param>
        public static void AddTexturePath(AssetProperty asset, string texturePath)
        {
            Asset connectedAsset = null;
            if (asset.NumberOfConnectedProperties == 0) asset.AddConnectedAsset("UnifiedBitmapSchema");

            connectedAsset = (Asset)asset.GetConnectedProperty(0);
            AssetProperty prop = connectedAsset.FindByName(UnifiedBitmap.UnifiedbitmapBitmap);
            AssetPropertyString path = (AssetPropertyString)connectedAsset.FindByName(UnifiedBitmap.UnifiedbitmapBitmap);

            string fileName = Path.GetFileName(texturePath);
            File.Create(fileName);
            texturePath = Path.GetFullPath(fileName);

            path.Value = texturePath;
        }
#endif

        /// <summary>
        /// get generic asset property color value 
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static Color GetColor(this Asset asset)
        {
            Color color = Color.InvalidColorValue;

#if Rvt_16 || Rvt_17
            var assetProperty = asset["generic_diffuse"];
#else
            var assetProperty = asset?.FindByName("generic_diffuse");
#endif
            if (assetProperty != null)
            {
                AssetPropertyDoubleArray4d genericDiffuseColor = (AssetPropertyDoubleArray4d)assetProperty;

#if Rvt_16 || Rvt_17
                DoubleArray array = genericDiffuseColor.Value;
                byte r = (byte)(array.get_Item(0) * 255);
                byte g = (byte)(array.get_Item(1) * 255);
                byte b = (byte)(array.get_Item(2) * 255);
                color = new Color(r, g, b);
#else
                color = genericDiffuseColor?.GetValueAsColor();
#endif
            }

            return color;
        }
    }
}
