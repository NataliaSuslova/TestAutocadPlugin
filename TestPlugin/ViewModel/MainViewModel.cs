using System.Collections.ObjectModel;
using System.Linq;

namespace TestPlugin
{
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel()
        {
            Layers = new LayersCollection();
        }

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

        public override void Update()
        {
            var updateAutocadDrawing = new UpdateAutocadDrawing(Layers);
            updateAutocadDrawing.Update();
        }
    }
}
