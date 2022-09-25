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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
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
                int index = random.Next(animalEmoji.Count); //Pick random number between 0 and the number of emoji left in the list and call it index
                string nextEmoji = animalEmoji[index];// use the random number index to get a random emoji from list
                textBlock.Text = nextEmoji;//Update the TextBlock with the random emoji from the list
                animalEmoji.RemoveAt(index);// Remove the random emoji from list
            }
           
        }
    }
}
