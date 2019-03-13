namespace TestPlugin
{
    /// <summary>
    /// Модель представления редактирования окружности
    /// </summary>
    public class CircleEditViewModel : BaseWindowViewModel
    {
        // Вспомогательная модель окружности, 
        // изменяется во время редактирования
        private PrimitiveCircle currentCircle;

        // Модель окружности для редактирования, изменяется
        // по окончанию работы редактора только после подтверждения
        private PrimitiveCircle baseCircle;

        public CircleEditViewModel(PrimitiveCircle circle)
        {
            this.baseCircle = circle;
            this.currentCircle = (PrimitiveCircle)circle.Clone();
        }

        public double Radius
        {
            get
            {
                return currentCircle.Radius;
            }
            set
            {
                currentCircle.Radius = value;
                OnPropertyChanged("Radius");
            }
        }

        public double Height
        {
            get
            {
                return currentCircle.Height;
            }
            set
            {
                currentCircle.Height = value;
                OnPropertyChanged("Height");
            }
        }

        // Координаты центра окружности

        public double X
        {
            get
            {
                return currentCircle.Center.X;
            }
            set
            {
                currentCircle.Center.X = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return currentCircle.Center.Y;
            }
            set
            {
                currentCircle.Center.Y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Z
        {
            get
            {
                return currentCircle.Center.Z;
            }
            set
            {
                currentCircle.Center.Z = value;
                OnPropertyChanged("Z");
            }
        }

        // Вносит изменения в модель окружности
        public override void Update()
        {
            baseCircle.Update(currentCircle);
        }
    }
}
