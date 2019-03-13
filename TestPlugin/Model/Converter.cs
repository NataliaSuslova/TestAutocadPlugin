using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.Windows.Media;

namespace TestPlugin
{
    public class Converter
    {
        public Layer Layer(LayerTableRecord layer)
        {
            return new Layer
            {
                ID = layer.ObjectId,
                Name = layer.Name,
                Visibility = !layer.IsOff,
                LayerColor = LayerColor(layer.Color)
            };
        }

        public PrimitivePoint PrimitivePoint(DBPoint point)
        {
            return new PrimitivePoint()
            {
                Name = "Точка",
                PrimitiveType = "Точки",
                ID = point.ObjectId,
                Height = point.Thickness,
                Position = Point3D(point.Position)
            };
        }

        public PrimitiveCircle PrimitiveCircle(Circle circle)
        {
            return new PrimitiveCircle()
            {
                Name = "Окружность",
                PrimitiveType = "Окружности",
                ID = circle.ObjectId,
                Radius = circle.Radius,
                Height = circle.Thickness,
                Center = Point3D(circle.Center)
            };
        }

        public PrimitiveLine PrimitiveLine(Line line)
        {
            return new PrimitiveLine()
            {
                Name = "Отрезок",
                PrimitiveType = "Отрезки",
                ID = line.ObjectId,
                Height = line.Thickness,
                StartPoint = Point3D(line.StartPoint),
                EndPoint = Point3D(line.EndPoint)
            };
        }

        public Point3D Point3D(Point3d point)
        {
            return new Point3D(point.X, point.Y, point.Z);
        }

        public Point3d Point3d(Point3D point)
        {
            return new Point3d(point.X, point.Y, point.Z);
        }

        public System.Windows.Media.Color LayerColor(Autodesk.AutoCAD.Colors.Color AcadColor)
        {
            if (!AcadColor.IsByAci)
            {
                if (AcadColor.IsByLayer)
                {
                    return Colors.White;
                }
                else if (AcadColor.IsByBlock)
                {
                    return Colors.White;
                }
                else
                {
                    return System.Windows.Media.Color.FromRgb(AcadColor.Red, AcadColor.Green, AcadColor.Blue);
                }
            }
            else
            {
                short colIndex = AcadColor.ColorIndex;
                byte byt = Convert.ToByte(colIndex);
                int rgb = Autodesk.AutoCAD.Colors.EntityColor.LookUpRgb(byt);
                long b = (rgb & 0xffL);
                long g = (rgb & 0xff00L) >> 8;
                long r = rgb >> 16;

                if (colIndex == 7)
                {
                    if (r <= 128 && g <= 128 && b <= 128)
                    {
                        return Colors.White;
                    }
                    else
                    {
                        return Colors.Black;
                    }
                }
                else
                {
                    return System.Windows.Media.Color.FromRgb((byte)r, (byte)g, (byte)b);
                }
            }
        }

        public Autodesk.AutoCAD.Colors.Color AcadColor(System.Windows.Media.Color LayerColor)
        {
            return Autodesk.AutoCAD.Colors.Color.FromRgb(LayerColor.R, LayerColor.G, LayerColor.B);
        }
    }
}
