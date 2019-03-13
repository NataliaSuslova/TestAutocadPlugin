namespace TestPlugin
{
    public abstract class BaseWindowViewModel : BaseViewModel
    {
        
        public BaseWindowViewModel()
        {
            this.CancelClose = new RelayCommand<IClosable>((IClosable window) => window.Close());
            this.OKClose = new RelayCommand<IClosable>(UpdateClose);
        }

        public RelayCommand<IClosable> CancelClose { get; private set; }

        public RelayCommand<IClosable> OKClose { get; private set; }

        private void UpdateClose(IClosable window)
        {
            window.Close();
            Update();
        }

        public abstract void Update();
    }
}