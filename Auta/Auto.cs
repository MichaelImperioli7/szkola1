namespace Auta
{
    using System.ComponentModel;

    public class Auto : INotifyPropertyChanged
    {
        private string _marka;
        private string _model;
        private int _cena;

        public string Marka
        {
            get => _marka;
            set
            {
                if (_marka == value) return;
                _marka = value;
                OnPropertyChanged(nameof(Marka));
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (_model == value) return;
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        public int Cena
        {
            get => _cena;
            set
            {
                if (_cena == value) return;
                _cena = value;
                OnPropertyChanged(nameof(Cena));
            }
        }

        public Auto(string marka, string model, int cena)
        {
            _marka = marka;
            _model = model;
            _cena = cena;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}