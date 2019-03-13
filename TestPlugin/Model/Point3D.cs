using System;

namespace TestPlugin
{
    public class Point3D : ICloneable
    {
        protected double x;
        protected double y;
        protected double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D()
            : this(0d, 0d, 0d)
        {
        }

        public Point3D(Point3D point)
            : this(point.X, point.Y, point.Z)
        {
        }

        public double X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }

        public double Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }

        public double Z
        {
            set
            {
                z = value;
            }
            get
            {
                return z;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]", X, Y, Z);
        }

        public object Clone()
        {
            return new Point3D(this.x, this.y, this.z);
        }
    }
}
