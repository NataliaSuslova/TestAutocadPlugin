namespace TestPlugin
{
    public class LineEditViewModel : BaseWindowViewModel
    {
        private PrimitiveLine currentLine;
        private PrimitiveLine baseLine;

        public LineEditViewModel(PrimitiveLine line)
        {
            this.baseLine = line;
            this.currentLine = (PrimitiveLine)line.Clone();
        }

        public double Height
        {
            get
            {
                return currentLine.Height;
            }
            set
            {
                currentLine.Height = value;
                OnPropertyChanged("Height");
            }
        }

        public double X1
        {
            get
            {
                return currentLine.StartPoint.X;
            }
            set
            {
                currentLine.StartPoint.X = value;
                OnPropertyChanged("X1");
            }
        }

        public double Y1
        {
            get
            {
                return currentLine.StartPoint.Y;
            }
            set
            {
                currentLine.StartPoint.Y = value;
                OnPropertyChanged("Y1");
            }
        }

        public double Z1
        {
            get
            {
                return currentLine.StartPoint.Z;
            }
            set
            {
                currentLine.StartPoint.Z = value;
                OnPropertyChanged("Z1");
            }
        }

        public double X2
        {
            get
            {
                return currentLine.EndPoint.X;
            }
            set
            {
                currentLine.EndPoint.X = value;
                OnPropertyChanged("X2");
            }
        }

        public double Y2
        {
            get
            {
                return currentLine.EndPoint.Y;
            }
            set
            {
                currentLine.EndPoint.Y = value;
                OnPropertyChanged("Y2");
            }
        }

        public double Z2
        {
            get
            {
                return currentLine.EndPoint.Z;
            }
            set
            {
                currentLine.EndPoint.Z = value;
                OnPropertyChanged("Z2");
            }
        }

        public override void Update()
        {
            baseLine.Update(currentLine);
        }
    }
}
