namespace TestPlugin
{
    public class PointEditViewModel : BaseWindowViewModel
    {
        private PrimitivePoint currentPoint;
        private PrimitivePoint basePoint;

        public PointEditViewModel(PrimitivePoint point)
        {
            this.basePoint = point;
            this.currentPoint = (PrimitivePoint)point.Clone();
        }

        public double Height
        {
            get
            {
                return currentPoint.Height;
            }
            set
            {
                currentPoint.Height = value;
                OnPropertyChanged("Height");
            }
        }

        public double X
        {
            get
            {
                return currentPoint.Position.X;
            }
            set
            {
                currentPoint.Position.X = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return currentPoint.Position.Y;
            }
            set
            {
                currentPoint.Position.Y = value;
                OnPropertyChanged("Y");
            }
        }

        public double Z
        {
            get
            {
                return currentPoint.Position.Z;
            }
            set
            {
                currentPoint.Position.Z = value;
                OnPropertyChanged("Z");
            }
        }

        public override void Update()
        {
            basePoint.Update(currentPoint);
        }
    }
}
