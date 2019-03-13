using System.Windows.Media;

namespace TestPlugin
{
    /// <summary>
    /// Модель представления выбора цвета
    /// </summary>
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

        // Изначальный цвет, до редактирования
        public SolidColorBrush StartColor { get; set; }

        // Значения красного, синего и зеленого в
        // цветовой модели RGB для текущего цвета

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

        // Текущий цвет в редакторе
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

        // Начальное и конечное значения градиента красного при
        // текущих значениях синего и зеленого

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

        // Начальное и конечное значения градиента зеленого при
        // текущих значениях синего и красного

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

        // Начальное и конечное значения градиента синего при
        // текущих значениях красного и зеленого

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

        // Изменяет текущий цвет и градиенты цветов при
        // изменении значений красного, синего или зеленого
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

        // Вносит изменения в цвет слоя при подтверждении
        public override void Update()
        {
            StartColor = FinishColor;
        }
    }
}
