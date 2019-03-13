namespace TestPlugin
{
    /// <summary>
    /// Модель точки
    /// </summary>
    public class PrimitivePoint : Primitive
    {
        public PrimitivePoint()
        {        
        }

        // Координаты точки
        public Point3D Position { get; set; }

        // Отображает значения редактируемых свойств точки:
        // координаты и высота
        public override string Display
        {
            get
            {
                return string.Format("P: {0}, H: {1}",
                    Position.ToString(), Height);
            }
        }

        // Запускает окно редактирования точки
        public override void Edit(object obj)
        {
            var pointEditViewModel = new PointEditViewModel((PrimitivePoint)obj);
            var pointEditWindow = new PointEditWindow(pointEditViewModel);
            pointEditWindow.ShowDialog();
        }

        // Копия точки, содержащая свойства для редактирования
        public override object Clone()
        {
            return new PrimitivePoint
            {
                Position = (Point3D)this.Position.Clone(),
                Height = this.Height
            };
        }

        // Обновляет свойства точки
        public override void Update(AutocadObject obj)
        {
            var point = (PrimitivePoint)obj;
            this.Position = point.Position;
            this.Height = point.Height;
            OnPropertyChanged("Display");
        }
    }
}
