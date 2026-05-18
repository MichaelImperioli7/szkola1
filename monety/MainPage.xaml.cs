namespace monety
{
    public partial class MainPage : ContentPage
    {
        private readonly string[] obrazy = ["moneta.png", "orzel.png", "reszka.png"];
        private readonly ImageButton[] monety_buttons;
        private bool[] locked = new bool[5];
        private int[] wyniki = new int[5];
        private Random rg = new();

        public MainPage()
        {
            InitializeComponent();
            monety_buttons = [moneta1, moneta2, moneta3, moneta4, moneta5];
        }

        private void Button_Rzut_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!locked[i])
                {
                    wyniki[i] = rg.Next(0, 2);
                    monety_buttons[i].Source = wyniki[i] == 1 ? obrazy[1] : obrazy[2];
                }
            }
            wynik_label.Text = $"{wyniki.Sum()}";
        }

        private void Button_Resetuj_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                locked[i] = false;
                wyniki[i] = 0;
                monety_buttons[i].Source = obrazy[0];
                monety_buttons[i].Opacity = 1.0;
            }
            wynik_label.Text = "0";
        }

        private void moneta_Clicked(object sender, EventArgs e)
        {
            var selected = (ImageButton)sender;
            int i = Array.IndexOf(monety_buttons, selected);
            locked[i] = !locked[i];
            selected.Opacity = locked[i] ? 0.5 : 1.0;
        }
    }
}