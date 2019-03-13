using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для PointEditWindow.xaml
    /// </summary>
    public partial class PointEditWindow : Window, IClosable
    {
        public PointEditWindow(PointEditViewModel pointEditViewModel)
        {
            InitializeComponent();           
            DataContext = pointEditViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
