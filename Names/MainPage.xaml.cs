using System.Collections.ObjectModel;

namespace MauiApp6
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> _names;

        public MainPage()
        {
            InitializeComponent();
            _names = new();
            CollectionView_1.ItemsSource = _names;
            Names_counter.Text = $"There's {_names.Count}";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var new_name = Entry_1.Text?.Trim();
            Entry_1.Text = string.Empty;

            if (string.IsNullOrEmpty(new_name))
            {
                Entry_1.Placeholder = "Cannot be empty. Enter your name.";
                return;
            }

            if (_names.Contains(new_name))
            {
                Entry_1.Placeholder = "Already contains the name. Enter your name.";
                return;
            }

            if (new_name.Any(char.IsDigit))
            {
                Entry_1.Placeholder = "Name cannot contain numbers. Enter your name.";
                return;
            }
            if (new_name.Length > 14)
            {
                Entry_1.Placeholder = "Name is too long. Enter a new one";
                return;
            }

            _names.Add(new_name);
            Names_counter.Text = $"There's {_names.Count}";
        }
    }
}
