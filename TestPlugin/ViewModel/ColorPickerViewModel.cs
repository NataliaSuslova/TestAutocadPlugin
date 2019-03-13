using System.Windows.Media;

namespace TestPlugin
{
    public class ColorPickerViewModel : BaseWindowViewModel
    {
        public ColorPickerViewModel(SolidColorBrush startColor)
        {
            StartColor = startColor;
            Red = StartColor.Color.R;
            Blue = StartColor.Color.B; ;
            Green = StartColor.Color.G; ;
            UpdateColor();
        }

        public SolidColorBrush StartColor { get; set; }

        private byte red;
        public byte Red
        {
            get
            {
                return red;
            }
            set
            {
                red = value;
                OnPropertyChanged("Red");
                UpdateColor();
            }
        }

        private byte blue;
        public byte Blue
        {
            get
            {
                return blue;
            }
            set
            {
                blue = value;
                OnPropertyChanged("Blue");
                UpdateColor();
            }
        }

        private byte green;
        public byte Green
        {
            get
            {
                return green;
            }
            set
            {
                green = value;
                OnPropertyChanged("Green");
                UpdateColor();
            }
        }

        private SolidColorBrush finishColor;
        public SolidColorBrush FinishColor
        {
            get
            {
                return finishColor;
            }
            set
            {
                finishColor = value;
                OnPropertyChanged("FinishColor");
            }
        }

        private Color gradientRedColorA;
        public Color GradientRedColorA
        {
            get
            {
                return gradientRedColorA;
            }
            set
            {
                gradientRedColorA = value;
                OnPropertyChanged("GradientRedColorA");
            }
        }

        private Color gradientRedColorB;
        public Color GradientRedColorB
        {
            get
            {
                return gradientRedColorB;
            }
            set
            {
                gradientRedColorB = value;
                OnPropertyChanged("GradientRedColorB");
            }
        }

        private Color gradientGreenColorA;
        public Color GradientGreenColorA
        {
            get
            {
                return gradientGreenColorA;
            }
            set
            {
                gradientGreenColorA = value;
                OnPropertyChanged("GradientGreenColorA");
            }
        }

        private Color gradientGreenColorB;
        public Color GradientGreenColorB
        {
            get
            {
                return gradientGreenColorB;
            }
            set
            {
                gradientGreenColorB = value;
                OnPropertyChanged("GradientGreenColorB");
            }
        }

        private Color gradientBlueColorA;
        public Color GradientBlueColorA
        {
            get
            {
                return gradientBlueColorA;
            }
            set
            {
                gradientBlueColorA = value;
                OnPropertyChanged("GradientBlueColorA");
            }
        }

        private Color gradientBlueColorB;
        public Color GradientBlueColorB
        {
            get
            {
                return gradientBlueColorB;
            }
            set
            {
                gradientBlueColorB = value;
                OnPropertyChanged("GradientBlueColorB");
            }
        }

        void UpdateColor()
        {
            FinishColor = new SolidColorBrush(Color.FromRgb(Red, Green, Blue));
            GradientRedColorA = Color.FromRgb(1, Green, Blue);
            GradientRedColorB = Color.FromRgb(255, Green, Blue);
            GradientGreenColorA = Color.FromRgb(Red, 1, Blue);
            GradientGreenColorB = Color.FromRgb(Red, 255, Blue);
            GradientBlueColorA = Color.FromRgb(Red, Green, 1);
            GradientBlueColorB = Color.FromRgb(Red, Green, 255);
        }

        public override void Update()
        {
            StartColor = FinishColor;
        }
    }
}
