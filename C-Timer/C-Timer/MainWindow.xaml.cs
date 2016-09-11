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
using System.Collections;

namespace C_Timer
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

        private void GenerateScramble(object sender, RoutedEventArgs e)
        {
            string[] cubesuff = { "", "2", "'" };
            var len = 25;
            var num = 1;
            string[][] turns = new string[][] 
            {
                new string[] {"U","D" },
                new string[] {"R","L" },
                new string[] {"F","B" }
            };

            //  MessageBox.Show(turns[0][1]);
             lblScramble.Content = MegaScramble(turns,cubesuff);
           // MessageBox.Show(MegaScramble(turns,cubesuff));
          

        }

        public string rndEL(string[] newTurn)
        {
            Random newRandom = new Random();
            double arrayLength = newTurn.Length;
            double randomNumber = newRandom.NextDouble() * arrayLength;
            
            return newTurn[(int)Math.Floor(newRandom.NextDouble() * newTurn.Length)];
        }

        public string MegaScramble(string[][] turns,string[] suffixes)
        {
           // List<int> doneMoves = new List<int>();
            int[] doneMoves = new int[5];
            int lastAxis;
            int i, j, k;
            Random newRandom = new Random();
            double arrayLength = turns.Length;
            double randomNumber = newRandom.NextDouble() * arrayLength;
            string scramble = "";

            for (i = 0; i < 1; i++)
            {
                

                lastAxis = -1;

                for (j = 0; j < 25; j++)
                {
                    int done = 0;

                    do
                    {
                        int first = (int)Math.Floor(newRandom.NextDouble() *  turns.Length );
                        int second = (int)Math.Floor(newRandom.NextDouble() * turns[first].Length);

                        if (first != lastAxis || doneMoves[second] == 0)
                        {
                            if(first == lastAxis)
                            {
                                
                                //doneMoves.Insert(second, 1);
                                doneMoves[second] = 1;



                                // scramble += turns[first][second] + rndEL(suffixes)+ " ";
                                scramble += turns[first][second] + suffixes[(int)Math.Floor(newRandom.NextDouble() * suffixes.Length)] + " ";
                            }

                            else
                            {
                                for (k = 0; k < turns[first].Length ; k++)
                                {
                                    
                                       // doneMoves.Insert(k,0);
                                        doneMoves[k] = 0 ;
                                }

                                lastAxis = first;
                                doneMoves[second] = 1;

                               // scramble += turns[first][second] + rndEL(suffixes) + " ";
                                scramble += turns[first][second] + suffixes[(int)Math.Floor(newRandom.NextDouble() * suffixes.Length)] + " ";
                            }
                            done = 1;
                        }
                      
                    }
                    while (done==0);
                }
            }

            return scramble;
        }


        //public bool IsArray(object obj)
        //{
        //    if (typeof obj == 'object')
        //    {
        //        var test = obj.constructor.toString().match(/ array / i);
        //        return (test != null);
        //    }
        //    return false;
        //}
    }
}





