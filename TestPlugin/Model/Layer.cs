using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media;

namespace TestPlugin
{
    public class Layer : AutocadObject
    {
        public Layer()
        {
            primitives = new ObservableCollection<Primitive> { };
        }

        private string name;
        public override string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool Visibility { get; set; }

        public Color LayerColor { get; set; }

        private ObservableCollection<Primitive> primitives;
        public ObservableCollection<Primitive> Primitives
        {
            get
            {
                return primitives;
            }
            set
            {
                primitives = value;
                OnPropertyChanged("Primitives");
            }
        }

        public ICollectionView PrimitivesGroup
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(this.Primitives);
                source.GroupDescriptions.Add(new PropertyGroupDescription("PrimitiveType"));
                return source;
            }
        }

        public override string Display
        {
            get
            {
                return string.Format("V: {0}, RGB: ({1}, {2}, {3})", 
                    Visibility, LayerColor.R, LayerColor.G, LayerColor.B);
            }
        }

        public override void Edit(object obj)
        {
            var layerEditViewModel = new LayerEditViewModel((Layer)obj);
            var layerEditWindow = new LayerEditWindow(layerEditViewModel);
            layerEditWindow.ShowDialog();
        }

        public override object Clone()
        {
            return new Layer
            {
                Name = this.Name,
                Visibility = this.Visibility,
                LayerColor = this.LayerColor
            };
        }

        public override void Update(AutocadObject obj)
        {
            Layer layer = (Layer)obj;
            this.Name = DataValidation.ValidLayerName(layer.Name, this.Name);
            this.LayerColor = layer.LayerColor;
            this.Visibility = layer.Visibility;
            OnPropertyChanged("Display");
        }
    }
}
