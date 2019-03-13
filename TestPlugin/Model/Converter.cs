using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.Windows.Media;

namespace TestPlugin
{
    /// <summary>
    /// Преобразует объекты БД Автокада в модели объектов,
    /// а также согласует их свойства между собой
    /// </summary>
    public class Converter
    {
        // Модель слоя из объекта LayerTableRecord
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

        // Модель точки из объекта DBPoint
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

        // Модель окружности из объекта Circle
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

        // Модель отрезка из объекта Line
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

        // Координаты модели из координат объекта БД Автокада
        public Point3D Point3D(Point3d point)
        {
            return new Point3D(point.X, point.Y, point.Z);
        }

        // Координаты объекта БД Автокада из координат модели
        public Point3d Point3d(Point3D point)
        {
            return new Point3d(point.X, point.Y, point.Z);
        }

        // Получение цвета для модели слоя
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

        // Преобразование цвета из модели слоя в объект Автокада
        public Autodesk.AutoCAD.Colors.Color AcadColor(System.Windows.Media.Color LayerColor)
        {
            return Autodesk.AutoCAD.Colors.Color.FromRgb(LayerColor.R, LayerColor.G, LayerColor.B);
        }
    }
}
