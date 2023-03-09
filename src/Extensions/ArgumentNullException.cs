using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuna.Revit.Extension.Extensions
{
    internal static class ArgumentNullException
    {
        public static void ThrowIfNull(object argument)
        {
            if (argument == null)
            {
                throw new System.ArgumentNullException(nameof(argument), "bitmap can not be null");
            }
        }
    }
}
