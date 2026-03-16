using System.Collections.ObjectModel;
using System.ComponentModel;
using MauiApp7.Data;

namespace MauiApp7
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PolowRecord> Polowy { get; set; }
        private readonly JsonStore _jsonStore = new();

        public MainPage()
        {
            Polowy = new ObservableCollection<PolowRecord>();
            BindingContext = this;
            InitializeComponent();
        }

        public class PolowRecord : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;
            void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            public string? Imie { get; set { field = value; OnPropertyChanged(nameof(Imie)); } }
            public string? Nazwisko { get; set { field = value; OnPropertyChanged(nameof(Nazwisko)); } }
            public string? Lowisko { get; set { field = value; OnPropertyChanged(nameof(Lowisko)); } }
            public string? GatunekRyby { get; set { field = value; OnPropertyChanged(nameof(GatunekRyby)); } }
            public double Waga { get; set { field = value; OnPropertyChanged(nameof(Waga)); } }
            public DateTime DataPolowu { get; set { field = value; OnPropertyChanged(nameof(DataPolowu)); } }
            public PolowRecord() { }    

            public PolowRecord(string imie, string nazwisko, string lowisko, string gatunekRyby, double waga, DateTime datapolowu)
            {
                Imie = imie;
                Nazwisko = nazwisko;
                Lowisko = lowisko;
                GatunekRyby = gatunekRyby;
                Waga = waga;
                DataPolowu = datapolowu;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var noweImie = EntryImie.Text;
            var noweNazwisko = EntryNazwisko.Text;
            var noweLowisko = EntryLowisko.Text;
            var nowyGatunekRyby = EntryGatunekRyby.Text;

            if (string.IsNullOrWhiteSpace(noweImie) ||
                string.IsNullOrWhiteSpace(noweNazwisko) ||
                string.IsNullOrWhiteSpace(noweLowisko) ||
                string.IsNullOrWhiteSpace(nowyGatunekRyby) ||
                !double.TryParse(EntryWaga.Text, out double nowaWaga)) return;

            Polowy.Add(new(noweImie, noweNazwisko, noweLowisko, nowyGatunekRyby, nowaWaga, DateTime.Now));
            await _jsonStore.SaveAllAsync(Polowy.ToList());

            EntryImie.Text = EntryNazwisko.Text = EntryLowisko.Text = EntryGatunekRyby.Text = EntryWaga.Text = "";
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlertAsync("Usuń wszystkie", "Czy na pewno chcesz usunąć wszystkie rekordy?", "Tak", "Nie");
            if (confirm)
                Polowy.Clear();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var records = await _jsonStore.GetRecordsAsync();
            Polowy.Clear();
            foreach (var record in records)
                Polowy.Add(record);
        }
    }
}