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

namespace Competition_Winner_Picker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Shuffle function
        private void Shuffle(ref List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Button click event handler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the text from the text box
            string text = Entries.Text;

            // Create a list of strings
            List<string> names;

            // Split the text into a list of names using newline as the delimiter
            names = text.Split('\n').ToList();

            // Create a list of strings
            List<string> winners = new();

            // Create a random object
            Random random = new Random();

            // Loop until we have our winner(s)
            while (winners.Count < int.Parse(Amount.Text) && names.Count > 0)
            {
                // Shuffle the names list each time to ensure fair results
                Shuffle(ref names);

                // Get the number of names
                int numberOfNames = names.Count;

                // Get a random number
                int randomNumber = random.Next(0, numberOfNames);

                // Get the name at the random number
                string name = names[randomNumber];

                // Add the name to the winners list
                winners.Add(name);

                // Remove the name from the names list
                names.Remove(name);
            }

            // Output Winners to Winner textbox
            Winners.Text = string.Join("\n", winners);
        }
    }
}
