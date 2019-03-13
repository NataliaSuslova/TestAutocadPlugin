using System;
using System.Windows.Input;
using System.Windows.Media;

namespace TestPlugin
{
    /// <summary>
    /// Модель представления редактирования слоя
    /// </summary>
    public class LayerEditViewModel : BaseWindowViewModel
    {
        // Вспомогательная модель слоя,
        // изменяется во время редактирования
        private Layer currentLayer;

        // Модель слоя для редактирования, 
        // изменяется только после подтверждения
        private Layer baseLayer;

        public LayerEditViewModel(Layer layer)
        {
            baseLayer = layer;
            currentLayer = (Layer)layer.Clone();
        }

        // Название слоя
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

        // Видимость
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

        // Цвет слоя
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

        // Команда для запуска окна редактирования цвета слоя
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

        // Запускает окно редактирования цвета и 
        // сохраняет выбранный цвет при подтверждении
        private void EditLayerColor(Object obj)
        {
            var colorPickerViewModel = new ColorPickerViewModel(LayerColor);
            var ColorPicker = new ColorPickerWindow(colorPickerViewModel);
            ColorPicker.ShowDialog();
            LayerColor = colorPickerViewModel.StartColor;
        }

        // Вносит изменения в модель слоя
        public override void Update()
        {
            baseLayer.Update(currentLayer);
        }
    }
}
