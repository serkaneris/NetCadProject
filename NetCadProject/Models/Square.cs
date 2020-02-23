using NetCadProject.Models.Abstracts;
using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Models
{
    public class Square : Shape
    {
        public Square()
        {
            this.GeoType = GeoType.Polygon;
            this.countOfPoint = 0;
        }

        public override void GenerateCoordinates()
        {
            #region Bu hesaplama enlem ve boylamlarda doğru sonuç vermez. Boylamlar arasındaki mesafe kutuplara doğru azalır. Tam bir kare cize bilmek için boylamların enlem bazında sapması hesaplanmalı.
            //var list = new Coordinate().CreateRandomCoordinates(countOfPoint);
            //double br = 10.0;

            //list.Add(new Coordinate
            //{
            //    Latitude = list[0].Latitude,
            //    Longitude = list[0].Longitude + br
            //});

            //list.Add(new Coordinate
            //{
            //    Latitude = list[0].Latitude + br,
            //    Longitude = list[0].Longitude + br
            //});

            //list.Add(new Coordinate
            //{
            //    Latitude = list[0].Latitude + br,
            //    Longitude = list[0].Longitude
            //});
            //list.Add(list[0]);

            //this.Coordinates = list;
            #endregion

            this.Coordinates = new List<Coordinate>
            {
                new Coordinate{ Latitude = 0, Longitude = 20},
                new Coordinate{ Latitude = 20, Longitude = 20},
                new Coordinate{ Latitude = 20 ,Longitude = 0},
                new Coordinate{ Latitude = 0, Longitude = 0},
                new Coordinate{ Latitude = 0, Longitude = 20},
            };

        }
    }
}