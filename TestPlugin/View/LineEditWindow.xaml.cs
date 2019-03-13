using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для LineEditWindow.xaml
    /// </summary>
    public partial class LineEditWindow : Window, IClosable
    {
        public LineEditWindow(LineEditViewModel lineEditViewModel)
        {
            InitializeComponent();           
            DataContext = lineEditViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
