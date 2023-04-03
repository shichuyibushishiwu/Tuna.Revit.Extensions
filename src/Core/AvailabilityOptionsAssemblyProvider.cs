///************************************************************************************
///   Author:十五
///   CretaeTime:2023/3/19 16:53:02
///   Mail:1012201478@qq.com
///   Github:https://github.com/shichuyibushishiwu
///
///   Description:
///
///************************************************************************************

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Core
{
    internal class AvailabilityOptionsAssemblyProvider
    {
        private readonly string _name = "Tuna.Revit.AvailabilityOptions";

        private AvailabilityOptionsAssemblyProvider()
        {
            AssemblyName name = new AssemblyName(_name);

            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.RunAndCollect);

            ModuleBuilder = assemblyBuilder.DefineDynamicModule(_name, $"{_name}.dll");
        }

        private static AvailabilityOptionsAssemblyProvider _instance;

        public static AvailabilityOptionsAssemblyProvider Current = _instance ??= new AvailabilityOptionsAssemblyProvider();

        public ModuleBuilder ModuleBuilder;

        public TypeBuilder DefineType(string typeFullname)
        {
            return ModuleBuilder.DefineType($"{_name}.{typeFullname}", TypeAttributes.Public | TypeAttributes.Class);
        }
    }
}
