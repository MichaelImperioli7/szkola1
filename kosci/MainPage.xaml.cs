namespace kosci
{
    public partial class MainPage : ContentPage
    {
        private string[] dices = { "kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png", "kosc4.png", "kosc5.png", "kosc6.png" };
        private ImageButton[] ImageButtons;
        private bool[] unavaliable = new bool[5];
        private int[] rolls = new int[5];
        private Random rg = new();
        public MainPage() 
        {
            InitializeComponent();
            ImageButtons = [imagebutton1, imagebutton2, imagebutton3, imagebutton4, imagebutton5];
        }

        private void Button_Losuj_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!unavaliable[i])
                {
                    rolls[i] = rg.Next(1, 7);
                    ImageButtons[i].Source = dices[rolls[i]];
                }
                else
                {
                    rolls[i] = 0;
                }
            }
            wyniklabel.Text = $"Suma: {rolls.Sum()}";
        }   

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var clicked = (ImageButton)sender;
            int i = Array.IndexOf(ImageButtons, clicked);
            unavaliable[i] = !unavaliable[i];
            clicked.Opacity = unavaliable[i] ? 0.5 : 1;
        }
    }
}