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
using System.Windows.Threading;
using System.Diagnostics;

namespace CubeTimer
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

        public DispatcherTimer timer;
        public Stopwatch stopWatch = new Stopwatch();




        public string MegaScramble(string[][] turns, string[] suffixes)
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
                        int first = (int)Math.Floor(newRandom.NextDouble() * turns.Length);
                        int second = (int)Math.Floor(newRandom.NextDouble() * turns[first].Length);

                        if (first != lastAxis || doneMoves[second] == 0)
                        {
                            if (first == lastAxis)
                            {

                                //doneMoves.Insert(second, 1);
                                doneMoves[second] = 1;



                                // scramble += turns[first][second] + rndEL(suffixes)+ " ";
                                scramble += turns[first][second] + suffixes[(int)Math.Floor(newRandom.NextDouble() * suffixes.Length)] + " ";
                            }

                            else
                            {
                                for (k = 0; k < turns[first].Length; k++)
                                {

                                    // doneMoves.Insert(k,0);
                                    doneMoves[k] = 0;
                                }

                                lastAxis = first;
                                doneMoves[second] = 1;

                                // scramble += turns[first][second] + rndEL(suffixes) + " ";
                                scramble += turns[first][second] + suffixes[(int)Math.Floor(newRandom.NextDouble() * suffixes.Length)] + " ";
                            }
                            done = 1;
                        }

                    }
                    while (done == 0);
                }
            }
            return scramble;
        }

        private void dispatcherTimerTick_(object sender, EventArgs e)
        {
            lblTimer.Content = stopWatch.Elapsed;
        }



        private void StartTimer(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (stopWatch.IsRunning)
                {
                    stopWatch.Stop();
                    string timeTaken = stopWatch.Elapsed.ToString();
                    lstAllTimes.Items.Add(timeTaken);
                   
                }
                else
                {
                    timer = new DispatcherTimer();
                    timer.Tick += dispatcherTimerTick_;
                    timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                    stopWatch.Start();
                    timer.Start();

                }

            }
        }

        private void TimerControl(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
                string timeTaken = stopWatch.Elapsed.ToString();
                lstAllTimes.Items.Add(timeTaken + "\t" + lblScramble.Content);
                string[] cubesuff = { "", "2", "'" };
                string[][] turns = new string[][]
                {
                        new string[] {"U","D" },
                        new string[] {"R","L" },
                        new string[] {"F","B" }
                };

                lblScramble.Content = MegaScramble(turns, cubesuff);
            }
            else
            {
                timer = new DispatcherTimer();
                timer.Tick += dispatcherTimerTick_;
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                stopWatch.Reset();
                stopWatch.Start();
                timer.Start();

            }
        }

        private void ShowDefaultScramble(object sender, RoutedEventArgs e)
        {
            string[] cubesuff = { "", "2", "'" };
            string[][] turns = new string[][]
            {
                new string[] {"U","D" },
                new string[] {"R","L" },
                new string[] {"F","B" }
            };

            lblScramble.Content = MegaScramble(turns, cubesuff);
        }
    }
}
