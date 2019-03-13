namespace TestPlugin
{
    public class CircleEditViewModel : BaseWindowViewModel
    {
        private PrimitiveCircle currentCircle;
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

        public override void Update()
        {
            baseCircle.Update(currentCircle);
        }
    }
}
