using System.Windows;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Логика взаимодействия для LayerEditWindow.xaml
    /// </summary>
    public partial class LayerEditWindow : Window, IClosable
    {
        public LayerEditWindow(LayerEditViewModel layerEditViewModel)
        {
            InitializeComponent();           
            DataContext = layerEditViewModel;
        }

        public void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
