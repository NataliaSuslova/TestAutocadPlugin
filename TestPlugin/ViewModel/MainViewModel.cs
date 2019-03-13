using System.Collections.ObjectModel;
using System.Linq;

namespace TestPlugin
{
    /// <summary>
    /// Модель представления главного окна
    /// </summary>
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel()
        {
            Layers = new LayersCollection();
        }

        // Коллекция моделей слоев и входящих в них примитивов,
        // предназначенная для редатирования
        private ObservableCollection<Layer> layers;
        public ObservableCollection<Layer> Layers
        {
            get
            {
                return layers;
            }
            set
            {
                layers = value;
                layers = new ObservableCollection<Layer>(layers.OrderBy(i => i.Name));
                OnPropertyChanged("Layers");
            }
        }

        // При подтверждении вносит изменения свойств
        // слоев и примитивов в чертёж Автокада
        public override void Update()
        {
            var updateAutocadDrawing = new UpdateAutocadDrawing(Layers);
            updateAutocadDrawing.Update();
        }
    }
}
