/* elliott mcarthur
 * 313502
 * hangman game
 */
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

namespace _313502Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] easyanswer = new string[8];
        string[] mediumanswer = new string[8];
        string[] hardanswer = new string[8];
        string rightanswer;
        int counter = 0;
        Random random = new Random(1);
        string DiscoveredAnswer;
        bool FoundLetter = false;
        int Error;
        int lives = 9;
        int Variable;
        List<string> ImageList = new List<string>();
        bool GameOver;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            counter = 0;
            int randomnumber = random.Next(1, 8);
            lblOutput.Content = "";
            if ((bool)EasyMode.IsChecked)
            {
                System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                while (!easyread.EndOfStream)
                {
                    if (counter == randomnumber)
                    {
                        easyanswer[randomnumber] = easyread.ReadLine();
                        counter++;
                    }
                    else
                    {
                        easyread.ReadLine();
                        counter++;
                    }
                    rightanswer = easyanswer[randomnumber];
                    
                    
                }
                easyread.Close();
                for (int i = 0; i < rightanswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            if ((bool)MediumMode.IsChecked)
            {
                counter = 0;
                System.IO.StreamReader mediumread = new System.IO.StreamReader("Medium.txt");
                while (!mediumread.EndOfStream)
                {
                    if (counter == randomnumber)
                    {
                        mediumanswer[randomnumber] = mediumread.ReadLine();
                        counter++;
                    }
                    else
                    {
                        mediumread.ReadLine();
                        counter++;
                    }
                    rightanswer = mediumanswer[randomnumber];
                   

                }
                mediumread.Close();
                for (int i = 0; i < rightanswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            if ((bool)HardMode.IsChecked)
            {
                counter = 0;
                System.IO.StreamReader hardread = new System.IO.StreamReader("Hard.txt");
                while (!hardread.EndOfStream)
                {
                    if (counter == randomnumber)
                    {
                        hardanswer[randomnumber] = hardread.ReadLine();
                    }
                    else
                    {
                        hardread.ReadLine();
                    }
                    rightanswer = hardanswer[randomnumber];
                    counter++;
                }
                hardread.Close();
                for (int i = 0; i < rightanswer.Length; i++)
                {
                    lblOutput.Content += "_" + " ";
                }
            }
            lblOutput2.Content += Environment.NewLine + "Lives Left: " + lives;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            DiscoveredAnswer = lblOutput.Content.ToString();
            for (int i = 0; i < rightanswer.Length; i++)
            {
                char lettersingle = rightanswer[i];
                if (lettersingle.ToString() == txtInput.Text)
                {
                    DiscoveredAnswer = DiscoveredAnswer.Remove(i * 2, 1);
                    DiscoveredAnswer = DiscoveredAnswer.Insert(i * 2, lettersingle.ToString());
                    lblOutput.Content = "";
                    lblOutput.Content += DiscoveredAnswer;
                    FoundLetter = true;
                }
            }
            if (FoundLetter == false)
            {
                Error += 1;
                if (Error == 1)
                {
                    ImageList.Add("Original-3541348-2.jpg");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 2)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 3)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 4)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 5)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 6)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 7)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left: " + Variable;
                }
                else if (Error == 8)
                {
                    ImageList.Add("");
                    Variable = lives - Error;
                    lblOutput2.Content = "Lives left:" + Variable;
                }
                bool Game1 = false;
                CheckGame(Game1);
            }
                
        }
        public bool CheckGame(bool Win)
        {
            if (lblOutput.Content.ToString() == rightanswer)
            {
                MessageBox.Show("YOU WIN!");
                return Win = true;
            }
            else
            {
                return Win = false;
            }
        }
        private bool Startgame(bool test)
        {
            if(lblOutput.Content.ToString() == rightanswer || GameOver == true)
            {
                counter = 0;
                int randomnumber = random.Next(0, 8);
                lblOutput.Content = "";

                if ((bool)EasyMode.IsChecked)
                {
                    System.IO.StreamReader easyread = new System.IO.StreamReader("Easy.txt");
                    while (!easyread.EndOfStream)
                    {
                        if(counter == randomnumber)
                        {
                            easyanswer[randomnumber] = easyread.ReadLine();
                        }
                        else
                        {
                            easyread.ReadLine();
                        }
                        rightanswer = easyanswer[randomnumber];
                        counter++;
                    }
                    easyread.Close();
                    for (int i = 0; i < rightanswer.Length; i++)
                    {
                        lblOutput.Content = "_" + " ";
                    }
                    if ((bool)MediumMode.IsChecked)
                    {
                        System.IO.StreamReader mediumread = new System.IO.StreamReader("Medium.txt");
                        while (!mediumread.EndOfStream)
                        {
                            easyanswer[counter] = mediumread.ReadLine();
                            lblOutput.Content += easyanswer[counter] + Environment.NewLine;
                            counter++;
                        }
                        mediumread.Close();
                    }
                    if((bool)HardMode.IsChecked)
                    {
                        counter = 0;
                        System.IO.StreamReader hardread = new System.IO.StreamReader("Hard.txt");
                        while (!hardread.EndOfStream)
                        {
                            hardanswer[counter] = hardread.ReadLine();
                            lblOutput.Content += easyanswer[counter] + Environment.NewLine;
                            counter++;
                        }
                        hardread.Close();
                       
                    }
                }
                lblOutput.Content = rightanswer;
                lblOutput.Content += Environment.NewLine + "Lives Left :" + lives;
                GameOver = false;
                return test = true;
            }
            else
            {
                return test = false;
            }
        }
    }    
}
