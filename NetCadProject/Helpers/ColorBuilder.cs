using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Helpers
{
    public class ColorBuilder
    {
        public static string GenerateHexCode() => $"#f{new Random().Next(0x10000)}";
    }
}