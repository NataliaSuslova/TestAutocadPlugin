namespace TestPlugin
{
    /// <summary>
    /// Модель отрезка
    /// </summary>
    public class PrimitiveLine : Primitive
    {
        public PrimitiveLine()
        {           
        }

        // Начальная координа отрезка
        public Point3D StartPoint { get; set; }

        // Конечная координа отрезка
        public Point3D EndPoint { get; set; }

        // Отображает основные свойства отрезка:
        // координаты крайних точек, высота
        public override string Display
        {
            get
            {
                return string.Format("P1: {0}, P2: {1}, H: {2}", 
                    StartPoint.ToString(), EndPoint.ToString(), Height);
            }
        }

        // Запускает окно редактирования отрезка
        public override void Edit(object obj)
        {
            var lineEditViewModel = new LineEditViewModel((PrimitiveLine)obj);
            var lineEditWindow = new LineEditWindow(lineEditViewModel);
            lineEditWindow.ShowDialog();
        }

        // Копия отрезка, содержащая свойства для редактирования
        public override object Clone()
        {
            return new PrimitiveLine
            {
                StartPoint = (Point3D)this.StartPoint.Clone(),
                EndPoint = (Point3D)this.EndPoint.Clone(),
                Height = this.Height
            };
        }

        // Обновляет свойства отрезка
        public override void Update(AutocadObject obj)
        {
            var line = (PrimitiveLine)obj;
            this.StartPoint = line.StartPoint;
            this.EndPoint = line.EndPoint;
            this.Height = line.Height;
            OnPropertyChanged("Display");
        }
    }
}
