using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp8
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<VideoGame> Games { get; set; }
        private VideoGame? _selected;

        public MainPage()
        {
            Games =
            [
                new("The Last of Us", 2013, "Action-Adventure", "Naughty Dog", "Neil Druckmann", 3),
                new("God of War", 2018, "Action-RPG", "Santa Monica Studio", "Cory Barlog", 2),
                new("Hades", 2020, "Roguelike", "Supergiant Games", "Greg Kasavin", 4),
                new("Hollow Knight", 2017, "Metroidvania", "Team Cherry", "William Pellen", 2),
                new("Red Dead Redemption 2", 2018, "Open World", "Rockstar Games", "Rob Nelson", 3),
            ];
            BindingContext = this;
            InitializeComponent();
        }

        public class VideoGame : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;
            void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

            public string Name { get; set { field = value; OnPropertyChanged(nameof(Name)); } }
            public int Year { get; set { field = value; OnPropertyChanged(nameof(Year)); } }
            public string Genre { get; set { field = value; OnPropertyChanged(nameof(Genre)); } }
            public string Developer { get; set { field = value; OnPropertyChanged(nameof(Developer)); } }
            public string Director { get; set { field = value; OnPropertyChanged(nameof(Director)); } }
            public int TotalCopies { get; set { field = value; OnPropertyChanged(nameof(TotalCopies)); } }
            public int AvailableCopies { get; set { field = value; OnPropertyChanged(nameof(AvailableCopies)); } }
            public int RentedCount { get; set { field = value; OnPropertyChanged(nameof(RentedCount)); } }

            public VideoGame(string name, int year, string genre, string developer, string director, int copies)
            {
                Name = name; Year = year; Genre = genre;
                Developer = developer; Director = director;
                TotalCopies = copies; AvailableCopies = copies;
            }
        }

        private void OnGameSelected(object sender, SelectionChangedEventArgs e)
        {
            _selected = e.CurrentSelection.FirstOrDefault() as VideoGame;
            DetailsPanel.IsVisible = _selected != null;
            if (_selected != null) RefreshDetails();
        }

        private void RefreshDetails()
        {
            if (_selected == null) return;

            NameLabel.Text = _selected.Name;
            YearLabel.Text = $"Year: {_selected.Year}";
            GenreLabel.Text = $"Genre: {_selected.Genre}";
            DeveloperLabel.Text = $"Developer: {_selected.Developer}";
            DirectorLabel.Text = $"Director: {_selected.Director}";
            CopiesLabel.Text = $"Available: {_selected.AvailableCopies} / {_selected.TotalCopies}";
            RentedLabel.Text = $"You have: {_selected.RentedCount}";
            GameImage.Source = _selected.Name.ToLower().Replace(" ", "_") + ".png";

            RentButton.IsEnabled = _selected.AvailableCopies > 0;
            ReturnButton.IsEnabled = _selected.RentedCount > 0;
        }

        private void OnRentClicked(object sender, EventArgs e)
        {
            if (_selected == null || _selected.AvailableCopies <= 0) return;
            _selected.AvailableCopies--;
            _selected.RentedCount++;
            RefreshDetails();
        }

        private void OnReturnClicked(object sender, EventArgs e)
        {
            if (_selected == null || _selected.RentedCount <= 0) return;
            _selected.AvailableCopies++;
            _selected.RentedCount--;
            RefreshDetails();
        }
    }
}