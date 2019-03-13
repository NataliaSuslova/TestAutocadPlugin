namespace TestPlugin
{
    /// <summary>
    /// Базовый класс для всех моделей представления, реализует 
    /// комманды закрытия окна редактирования c подтвеждением
    /// изменений и без подтвеждения
    /// </summary>
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        
        public BaseWindowViewModel()
        {
            this.CancelClose = new RelayCommand<IClosable>((IClosable window) => window.Close());
            this.OKClose = new RelayCommand<IClosable>(UpdateClose);
        }

        // Закрывает окно редактирования без изменений
        public RelayCommand<IClosable> CancelClose { get; private set; }

        // Закрывает окно редактирования и подтвеждает изменения
        public RelayCommand<IClosable> OKClose { get; private set; }

        private void UpdateClose(IClosable window)
        {
            window.Close();
            Update();
        }

        // Реализует изменения после подтвеждения
        public abstract void Update();
    }
}