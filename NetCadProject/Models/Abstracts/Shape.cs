using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCadProject.Models.Abstracts
{
    public abstract class Shape
    {
        public string UId { get { return Guid.NewGuid().ToString(); } }
        protected int countOfPoint { get; set; }
        public GeoType GeoType { get; set; }
        public virtual List<Coordinate> Coordinates { get; set; }
        public string FillColor { get; set; }
        public string BorderColor { get; set; }

        public virtual void GenerateCoordinates()
        {
            this.Coordinates = new Coordinate().CreateRandomCoordinates(countOfPoint);
        }

        public void SetColor()
        {
            this.FillColor = Helpers.ColorBuilder.GenerateHexCode();
            this.BorderColor = "#000000"; //Fix to Black 
        }
    }
}
