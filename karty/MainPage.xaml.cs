namespace cards
{
    public partial class MainPage : ContentPage
    {
        private int wynikgry;
        private readonly string[] obrazy = ["karta.png", "karta1.png", "karta2.png", "karta3.png", "karta4.png",
            "karta5.png", "karta6.png", "karta7.png", "karta8.png", "karta9.png", "karta10.png", "karta11.png",
            "karta12.png", "karta13.png"];
        private bool[] locked = new bool[5];
        private Random rg = new();
        private readonly ImageButton[] karty_buttons;
        private int[] wyniki = new int[5];
        public MainPage()
        {
            InitializeComponent();
            karty_buttons = [karta1_image, karta2_image, karta3_image, karta4_image, karta5_image];
            wynikgry = 0;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int wynik_losowania = 0;
            for(int i = 0; i < 5; i++)
            {
                if (!locked[i])
                {
                    wyniki[i] = rg.Next(1,14);
                    karty_buttons[i].Source = obrazy[wyniki[i]];
                }
                wynik_losowania += wyniki[i];
            }
            wynikgry += wynik_losowania;
            wynik_losowania_label.Text = $"Wynik losowania: {wynik_losowania}";
            wynik_gry.Text = $"Wynik gry: {wynikgry}";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            wynikgry = 0;
            for (int i = 0; i < 5; i++)
            {
                locked[i] = false;
                wyniki[i] = 0;
                karty_buttons[i].Source = obrazy[0];
                karty_buttons[i].Opacity = 1.0;
            }
            wynik_losowania_label.Text = "Wynik losowania: 0";
            wynik_gry.Text = "Wynik gry: 0";
        }

        private void karta_image_Clicked(object sender, EventArgs e)
        {
            var selected = (ImageButton)sender;
            int i = Array.IndexOf(karty_buttons, selected);
            locked[i] = !locked[i];
            selected.Opacity = locked[i] ? 0.5 : 1.0;
        }
    }
}
