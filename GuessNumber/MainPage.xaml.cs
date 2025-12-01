using System.Diagnostics;

namespace GuessNumber
{
    public partial class MainPage : ContentPage
    {
        private int computerNumber;
        private int maxNumber;
        private int attempts;
        private Random random = new Random();

        public MainPage()
        {
            InitializeComponent();

            GuessButton.IsEnabled = false;
            PlayAgainButton.IsEnabled = false;
            RedIndicator.IsVisible = false;
            GreenIndicator.IsVisible = false;
        }

        private void DifficultyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DifficultyPicker.SelectedItem != null)
            {
                string selected = DifficultyPicker.SelectedItem.ToString();
                Debug.WriteLine($"Vald svårighetsgrad: {selected}");

                switch (selected)
                {
                    case "1-10":
                        maxNumber = 10;
                        break;
                    case "1-25":
                        maxNumber = 25;
                        break;
                    case "1-50":
                        maxNumber = 50;
                        break;
                    case "1-100":
                        maxNumber = 100;
                        break;
                }


                 // kommentera 
                computerNumber = random.Next(1, maxNumber);

                attempts = 0;

                FeedbackLabel.Text = "";
                AttemptsLabel.Text = $"Antal försök: {attempts}";
                RedIndicator.IsVisible = false;
                GreenIndicator.IsVisible = false;

                GuessButton.IsEnabled = true;
                PlayAgainButton.IsEnabled = false;
            }
        }

        private void GuessButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(GuessEntry.Text, out int userGuess))
            {
                attempts++;
                AttemptsLabel.Text = $"Antal försök: {attempts}";

                if (userGuess < computerNumber)
                {
                    FeedbackLabel.Text = "För lågt!";
                    RedIndicator.IsVisible = true;
                    GreenIndicator.IsVisible = false;
                }
                else if (userGuess > computerNumber)
                {
                    FeedbackLabel.Text = "För högt!";
                    RedIndicator.IsVisible = true;
                    GreenIndicator.IsVisible = false;
                }
                else
                {
                    FeedbackLabel.Text = $"Rätt! Talet var {computerNumber}";
                    GreenIndicator.IsVisible = true;
                    RedIndicator.IsVisible = false;

                    GuessButton.IsEnabled = false;
                    PlayAgainButton.IsEnabled = true;
                }
            }
            else
            {
                FeedbackLabel.Text = "Vänligen skriv ett heltal!";
            }

            GuessEntry.Text = "";
        }

        private void PlayAgainButton_Clicked(object sender, EventArgs e)
        {
            computerNumber = random.Next(0, maxNumber + 1);
            attempts = 0;

            FeedbackLabel.Text = "";
            AttemptsLabel.Text = "Antal försök: 0";
            RedIndicator.IsVisible = false;
            GreenIndicator.IsVisible = false;

            GuessButton.IsEnabled = true;
            PlayAgainButton.IsEnabled = false;
        }
    }
}