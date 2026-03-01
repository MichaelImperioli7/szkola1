using System.Collections.ObjectModel;

namespace Auta
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Auto> Auta { get; }

        public MainPage()
        {
            InitializeComponent();
            Auta = new ObservableCollection<Auto>
            {
                new("Toyota", "Corolla", 65000),
                new("BMW", "3", 120000),
                new("Audi", "A4", 110000),
            };
            BindingContext = this;
        }
        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var wybrany = e.CurrentSelection.FirstOrDefault() as Auto;
            Informacja.Text = wybrany == null ? "nic nie wybrano" : $"wybrałeś: {wybrany.Marka} {wybrany.Model}";
        }
    }
}
