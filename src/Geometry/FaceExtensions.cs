/************************************************************************************
   Author:十五
   CretaeTime:
   Mail:1012201478@qq.com
   Github:https://github.com/shichuyibushishiwu

   Description:

************************************************************************************/

using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extensions;

/// <summary>
/// <see cref="Autodesk.Revit.DB.Face"/> extensions
/// </summary>
public static class FaceExtensions
{
    /// <summary>
    /// 从  <see cref="Autodesk.Revit.DB.FaceArray"/> 获取  <see cref="Autodesk.Revit.DB.Face"/> 列表
    /// <para>Get faces array from <see cref="Autodesk.Revit.DB.FaceArray"/></para>
    /// </summary>
    /// <param name="faceArray"></param>
    /// <returns></returns>
    public static Face[] ToArray(this FaceArray faceArray)
    {
        int length = faceArray.Size;
        Face[] faces = new Face[length];

        for (int i = 0; i < length; i++)
        {
            faces[i] = faceArray.get_Item(i);
        }

        return faces;
    }
}
