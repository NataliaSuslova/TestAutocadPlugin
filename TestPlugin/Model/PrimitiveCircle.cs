namespace TestPlugin
{
    /// <summary>
    /// Модель окружности
    /// </summary>
    public class PrimitiveCircle : Primitive
    {
        public PrimitiveCircle()
        {           
        }

        // Координаты центра окружности
        public Point3D Center { get; set; }

        public double Radius { get; set; }

        // Отображает текущие значения редактируемых свойств
        // окружности: координаты центра, радиус, высота
        public override string Display
        {
            get
            {
                return string.Format("X,Y,Z: {0} R: {1}, H: {2}", 
                    Center.ToString(), Radius, Height);
            }
        }

        // Запускает окно редактирования окружности
        public override void Edit(object obj)
        {
            var circleEditViewModel = new CircleEditViewModel((PrimitiveCircle)obj);
            var circleEditWindow = new CircleEditWindow(circleEditViewModel);
            circleEditWindow.ShowDialog();
        }

        // Копия окружности, содержащая свойства для редактирования
        public override object Clone()
        {
            return new PrimitiveCircle
            {
                Radius = this.Radius,
                Center = (Point3D)this.Center.Clone(),
                Height = this.Height
            };
        }

        // Обновляет свойства окружности
        public override void Update(AutocadObject obj)
        {
            var circle = (PrimitiveCircle)obj;
            this.Radius = DataValidation.ValidRadius(circle.Radius, this.Radius);
            this.Center = circle.Center;
            this.Height = circle.Height;
            OnPropertyChanged("Display");
        }
    }
}
