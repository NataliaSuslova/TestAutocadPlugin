using System;
using System.Windows.Input;
using System.Windows.Media;

namespace TestPlugin
{
    public class LayerEditViewModel : BaseWindowViewModel
    {
        private Layer currentLayer;
        private Layer baseLayer;

        public LayerEditViewModel(Layer layer)
        {
            baseLayer = layer;
            currentLayer = (Layer)layer.Clone();
        }

        public string Name
        {
            get
            {
                return currentLayer.Name;
            }
            set
            {
                currentLayer.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool Visibility
        {
            get
            {
                return currentLayer.Visibility;
            }
            set
            {
                currentLayer.Visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        public SolidColorBrush LayerColor
        {
            get
            {
                return new SolidColorBrush(currentLayer.LayerColor);
            }
            set
            {
                currentLayer.LayerColor = value.Color;
                OnPropertyChanged("LayerColor");
            }
        }

        private RelayCommand editColor;
        public ICommand EditColor
        {
            get
            {
                if (editColor == null)
                    editColor = new RelayCommand(EditLayerColor);
                return editColor;
            }
        }

        private void EditLayerColor(Object obj)
        {
            var colorPickerViewModel = new ColorPickerViewModel(LayerColor);
            var ColorPicker = new ColorPickerWindow(colorPickerViewModel);
            ColorPicker.ShowDialog();
            LayerColor = colorPickerViewModel.StartColor;
        }

        public override void Update()
        {
            baseLayer.Update(currentLayer);
        }
    }
}
