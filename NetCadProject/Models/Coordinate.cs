using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Models
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<Coordinate> CreateRandomCoordinates(int count)
        {
            List<Coordinate> lst = new List<Coordinate>();
            if (count == 0)
            {
                lst.Add(new Coordinate
                {
                    Latitude = -90 + (new Random().NextDouble() * 180),
                    Longitude = -180 + (new Random().NextDouble() * 360)
                });
            }
            else
            {
                var random = new Random();
                for (int i = 0; i < count; i++)
                {
                    lst.Add(new Coordinate
                    {
                        Latitude = -90 + (random.NextDouble() * 180),
                        Longitude = -180 + (random.NextDouble() * 360)
                    });

                }
                lst.Add(lst[0]);
            }
            return lst;
        }
    }
}