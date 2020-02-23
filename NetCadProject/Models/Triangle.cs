using NetCadProject.Models.Abstracts;
using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Models
{
    public class Triangle : Shape
    {
        public Triangle()
        {
            this.GeoType = GeoType.Polygon;
            this.countOfPoint = 3;
        }
    }
}