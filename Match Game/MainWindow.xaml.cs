using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Match_Game
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        int lastTimeElapsedText;
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = "Time " + ( tenthsOfSecondsElapsed / 10f).ToString("0.0s");            
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
                
            }
            
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>() //Create a list of 8 pairs of emoji
            {
                "😊" , "😊",
                "😂" , "😂",
                "🤣" , "🤣",
                "❤" , "❤",
                "😍" , "😍",
                "😁" , "😁",
                "😎" , "😎",
                "😘" , "😘",
            };
            
            Random random = new Random(); // Create a new random number generator

            //Find every TextBlock in the main grid and repeat the following statement for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //The statement
                if ((textBlock.Name != "timeTextBlock") && (textBlock.Name != "lastTimeElapsed"))
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); //Pick random number between 0 and the number of emoji left in the list and call it index
                    string nextEmoji = animalEmoji[index];// use the random number index to get a random emoji from list
                    textBlock.Text = nextEmoji;//Update the TextBlock with the random emoji from the list
                    animalEmoji.RemoveAt(index);// Remove the random emoji from list
                }
            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            lastTimeElapsed.Text = timeTextBlock.Text;
            matchesFound = 0;            
           
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if(findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if(textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else 
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
