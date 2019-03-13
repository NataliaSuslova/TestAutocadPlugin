using System;
using System.Windows.Input;

namespace TestPlugin
{
    /// <summary>
    /// Содержит общие свойства моделей слоев и примитивов
    /// </summary>
    public abstract class AutocadObject : BaseViewModel, ICloneable
    {
        // Идентификатор объекта, по которому его можно найти в БД Автокада
        public Autodesk.AutoCAD.DatabaseServices.ObjectId ID { get; set; }

        // Название слоя или обозначение примитива
        public abstract string Name { get; set; }

        // Содержит краткую информацию о текущих значениях свойств объекта
        public abstract string Display { get; }

        // Создает частичную копию объекта, содержащую свойства для редактировния
        public abstract object Clone();

        // Изменяет/обновляет свойства объекта после закрытия редактора
        public abstract void Update(AutocadObject obj);

        // Открывает редактор объекта
        public abstract void Edit(Object obj);

        // Команда, чтобы открыть редактор объекта
        private RelayCommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                    editCommand = new RelayCommand(Edit);
                return editCommand;
            }
        }
    }
}
