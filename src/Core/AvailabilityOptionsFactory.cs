///************************************************************************************
///   Author:十五
///   CretaeTime:2023/3/19 13:20:58
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
using Tuna.Revit.Extension.Attributes;

namespace Tuna.Revit.Extension.Core
{
    internal static class AvailabilityOptionsFactory
    {
        private static void CreateIL(AvailabilityAttribute attribute, ILGenerator generator)
        {
            if (attribute.Availability.HasFlag(Data.AvailabilityMode.Always))
            {
                generator.Emit(OpCodes.Nop);
                generator.Emit(OpCodes.Ldc_I4_1);
                return;
            }

            //switch (availabilityAttribute.Availability)
            //{
            //    case Data.AvailabilityMode.Always:
            //        //availabilityType = typeof(Data.ButtonOptions.AlwaysAvailabilityCommand);
            //        break;
            //    case Data.AvailabilityMode.OnlyDocument:
            //        break;
            //    case Data.AvailabilityMode.OnlyFamily:
            //        break;
            //    case Data.AvailabilityMode.OnlyProject:
            //        break;
            //    case Data.AvailabilityMode.OnlyThreeDView:
            //        break;
            //    case Data.AvailabilityMode.OnlyPlanView:
            //        break;
            //    default:
            //        break;
            //}
        }

        public static Type CreateAvailabilityOptions(Type type)
        {
            TypeBuilder typeBuilder = AvailabilityOptionsAssemblyProvider.Current.ModuleBuilder.DefineType(
                $"{type.Name}Availability",
                TypeAttributes.Public | TypeAttributes.Class);

            typeBuilder.AddInterfaceImplementation(typeof(IExternalCommandAvailability));

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "IsCommandAvailable",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(bool),
                new Type[2] { typeof(UIApplication), typeof(CategorySet) });

            ILGenerator generator = methodBuilder.GetILGenerator();
            CreateIL(type.GetCustomAttribute<AvailabilityAttribute>(), generator);
            generator.Emit(OpCodes.Ret);

            return typeBuilder.CreateType();
        }
    }
}
