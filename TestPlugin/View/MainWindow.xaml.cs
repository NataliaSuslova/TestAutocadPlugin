using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
