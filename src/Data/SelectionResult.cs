///************************************************************************************
///   Author:十五
///   CretaeTime:2023/4/6 0:41:45
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Data
{
    public class SelectionResult<T>
    {
        public SelectionResult()
        {
            Succeeded = true;
        }

        public string Message { get; set; }

        public T Value { get; set; }

        public bool Succeeded { get; set; }
    }
}
