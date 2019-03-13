using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для CircleEditWindow.xaml
    /// </summary>
    public partial class CircleEditWindow : Window, IClosable
    {
        public CircleEditWindow(CircleEditViewModel circleEditViewModel)
        {
            InitializeComponent();
            DataContext = circleEditViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
