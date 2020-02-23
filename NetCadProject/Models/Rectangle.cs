using NetCadProject.Models.Abstracts;
using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Models
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            this.GeoType = GeoType.Polygon;
            this.countOfPoint = 4;
        }
    }
}