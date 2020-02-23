using NetCadProject.Models;
using NetCadProject.Models.Abstracts;
using NetCadProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCadProject.Helpers
{
    public class ShapeBuilder
    {
        private Shape _shape;
        public ShapeBuilder(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    this._shape = new Circle();
                    break;
                case ShapeType.Rectangle:
                    this._shape = new Rectangle();
                    break;
                case ShapeType.Square:
                    this._shape = new Square();
                    break;
                case ShapeType.Triagle:
                    this._shape = new Triangle();
                    break;
                default:
                    throw new Exception();
            }
        }

        public Shape Draw()
        {
            this._shape.GenerateCoordinates();
            this._shape.SetColor();
            return this._shape;
        }
    }
}