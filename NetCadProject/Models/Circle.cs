using NetCadProject.Models.Abstracts;
using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Models
{
    public class Circle : Shape, ICircle
    {
        public double Radius { get; set; }

        public Circle()
        {
            this.Radius = 60; //fixed
            this.GeoType = GeoType.Circle;
            this.countOfPoint = 0;
        }
    }
}