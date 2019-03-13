using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window, IClosable
    {
        public ColorPickerWindow(ColorPickerViewModel colorPickerViewModel)
        {
            InitializeComponent();
            DataContext = colorPickerViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
