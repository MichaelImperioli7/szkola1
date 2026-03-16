using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Ksiazki
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Ksiazka> Ksiazki { get; set; }
        public MainPage()
        {

            Ksiazki = [
                new("Hobbit", "Tolkien", 310),
                new("Lalka", "Boleslaw Prus", 680),
                new("Mały Książę", "Saint-Exupéry", 96)
            ];
            BindingContext = this;
            InitializeComponent();
        }

    }
    public class Ksiazka : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged(string nowy) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nowy));

        public string Autor { get; set { field = value; OnPropertyChanged(nameof(Autor)); } }
        public string Tytul { get; set { field = value; OnPropertyChanged(nameof(Tytul)); } }
        public int LiczbaStron { get; set { field = value; OnPropertyChanged(nameof(LiczbaStron)); } }

        public Ksiazka(string tytul, string autor, int liczbastron)
        {
            Autor = autor;
            Tytul = tytul;
            LiczbaStron = liczbastron;
        }

    }
}
