using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}" + Environment.NewLine +
                   $"Lateral Surface Area - {this.LateralSurfaceArea():f2}" + Environment.NewLine +
                   $"Volume - {this.Volume():f2}";
        }
    }
}
