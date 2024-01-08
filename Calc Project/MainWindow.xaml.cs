using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Calc_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int gameKind;
        private int correctcount = 0;
        private int questioncount = 0;
        private string UsersInput = string.Empty;
        private Class1 currentGame;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void ActivateGameForGrade(int grade)
        {
            TargetButton1.Visibility = Visibility.Hidden;
            TargetButton2.Visibility = Visibility.Hidden;
            TargetButton3.Visibility = Visibility.Hidden;
            TargetButton4.Visibility = Visibility.Hidden;
            TextBlock1.Visibility = Visibility.Hidden;
            TextBlock2.Visibility = Visibility.Hidden;
            TextBlock3.Visibility = Visibility.Visible;
            ButtonCheck.Visibility = Visibility.Visible;
            questionCounter1.Visibility = Visibility.Visible;
            MathPic.Visibility = Visibility.Hidden;
            answerBox.Visibility = Visibility.Visible;
            number1.Visibility = Visibility.Visible;
            number2.Visibility = Visibility.Visible;
            plus.Visibility = Visibility.Visible;
            minus.Visibility = Visibility.Hidden;
            times.Visibility = Visibility.Hidden;
            divide.Visibility = Visibility.Hidden;
            nextQuestionButton.Visibility = Visibility.Visible;

            gameKind = grade;

            // Call the checking_Click method directly to activate the game
            Check_Click(this, new RoutedEventArgs());
        }
        private void Grade1_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(1);


        }

        private void Grade2_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(2);
        }

        private void Grade3_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(3);
        }

        private void Grade4_Click(object sender, RoutedEventArgs e)
        {
            ActivateGameForGrade(4);

        }

        private void ActivateGameGrade1(object sender, RoutedEventArgs e)
        {
         Random random = new Random();

        // Generate random numbers
        int num1 = random.Next(1, 11);
        int num2 = random.Next(1, 11);

        Num1TextBox.Text = num1.ToString();
        Num2TextBox.Text = num2.ToString();


        }

        private void RandomNumbersButton_Click(object sender, RoutedEventArgs e)
        {
            // Generate two random numbers
            Random random = new Random();
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);

            // Set the text of Num1TextBox and Num2TextBox
            Num1TextBox.Text = num1.ToString();
            Num2TextBox.Text = num2.ToString();
        }


        private void CheckAnswer()
        {
            if (currentGame != null)
            {
                int rightAnswer = currentGame.GetRightAnswer();

                if (int.TryParse(answerBox.Text, out int usersAnswer))
                {
                    if (rightAnswer == usersAnswer)
                    {
                        correctLabel.Visibility = Visibility.Visible;
                        correctcount++;
                    }
                    else
                    {
                        wrongLabel.Visibility = Visibility.Visible;
                        correctLabel.Visibility = Visibility.Hidden;
                    }
                }

                // Hide the "Next Question" button until the user checks the answer
            }

            if (questioncount >= 10)
            {
                // Handle the case when all questions are answered
                if (correctcount != 0)
                {
                    double final_grade = (correctcount / 10.0) * 100;
                    MessageBox.Show($"All questions answered! Your final grade is {final_grade}");
                }
                else
                {
                    MessageBox.Show("All questions answered! Your final grade is 0, try again!");
                }
            }
        }

        private void MoveToNextQuestion()
        {
            // Clear the answer user input
            questioncount++;

            if (questioncount <= 10)
            {
                if (gameKind == 1)
                {
                    gameKind = 1;
                    currentGame = new Class1(gameKind, '+');
                    number1.Text = currentGame.GetNumber1().ToString();
                    number2.Text = currentGame.GetNumber2().ToString();
                    plus.Visibility = Visibility.Visible;
                    TextBlock3.Visibility = Visibility.Visible;
                    
                }
                else if (gameKind == 2)
                {
                    gameKind = 2;
                    currentGame = new Class1(gameKind, '-');
                    number1.Text = currentGame.GetNumber1().ToString();
                    number2.Text = currentGame.GetNumber2().ToString();
                    minus.Visibility = Visibility.Visible;
                    TextBlock4.Visibility = Visibility.Visible;
                    TextBlock3.Visibility = Visibility.Hidden;
                    plus.Visibility = Visibility.Hidden;

                }
                else if (gameKind == 3)
                {
                    gameKind = 3;
                    currentGame = new Class1(gameKind, '*');
                    number1.Text = currentGame.GetNumber1().ToString();
                    number2.Text = currentGame.GetNumber2().ToString();
                    times.Visibility = Visibility.Visible;
                    TextBlock5.Visibility = Visibility.Visible;
                    TextBlock3.Visibility = Visibility.Hidden;
                    plus.Visibility = Visibility.Hidden;


                }
                else if (gameKind == 4)
                {
                    gameKind = 4;
                    currentGame = new Class1(gameKind, '/');
                    number1.Text = currentGame.GetNumber1().ToString();
                    number2.Text = currentGame.GetNumber2().ToString();
                    divide.Visibility = Visibility.Visible;
                    TextBlock6.Visibility = Visibility.Visible;
                    TextBlock3.Visibility = Visibility.Hidden;
                    plus.Visibility = Visibility.Hidden;


                }

                answerBox.Text = string.Empty;

                // Show the "Next Question" button after displaying the new question
            }
            else
            {
                // Handle the case when all questions are answered
                if (correctcount != 0)
                {
                    double final_grade = (correctcount / 10.0) * 100;
                    MessageBox.Show($"All questions answered! Your final grade is {final_grade}");
                }
                else
                {
                    MessageBox.Show("All questions answered! Your final grade is 0, try again!");
                }
            }
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
        }


        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            MoveToNextQuestion();

            wrongLabel.Visibility = Visibility.Hidden;
            correctLabel.Visibility = Visibility.Hidden;

        }







        private void answerBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersInput = answerBox.Text;
        }
    }
}