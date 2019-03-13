using System;
using System.Windows.Input;

namespace TestPlugin
{
    public abstract class AutocadObject : BaseViewModel, ICloneable
    {
        public Autodesk.AutoCAD.DatabaseServices.ObjectId ID { get; set; }

        public abstract string Name { get; set; }

        public abstract string Display { get; }

        public abstract object Clone();

        public abstract void Update(AutocadObject obj);

        public abstract void Edit(Object obj);

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
