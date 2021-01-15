using System;
using System.Windows.Forms;

namespace quizGame
{
    public partial class Form1 : Form
    {
        // quiz game variables

        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;

        int timeLeft;



        public Form1()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 8;

        }

        private void endGame()
        {
            percentage = (int)Math.Round((Double)(score * 100) / totalQuestions);

            timer1.Stop();
            MessageBox.Show(
                "Quiz Ended" + Environment.NewLine +
                "You have anserwered " + score + " questions correctly." + Environment.NewLine +
                "Your total percentage is " + percentage + "%" + Environment.NewLine +
                "Click OK to play again"
                );

            timeLeft = 30;
            countDownLabel.Text = "30 sec";

            score = 0;
            questionNumber = 0;
            askQuestion(questionNumber);

            startButton.Visible = true;
            startButton.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if(buttonTag == correctAnswer)
            {
                score++;
            }

            if(questionNumber == totalQuestions)
            {
                // work out percentage first

                percentage = (int)Math.Round((Double)(score * 100)/totalQuestions);

                endGame();
            }

            questionNumber++;
            askQuestion(questionNumber);
            if (questionNumber != 1)
            {
                startTimer();
            }    
        }


        private void startTimer()
        {
            timeLeft = 30;
            countDownLabel.Text = "30 sec";
            timer1.Start();
        }



        private void askQuestion(int qnum)
        {
            switch (qnum)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.questions;
                    lblQuestion.Text = "What is the color of the sky?";
                    button1.Text = "Blue";
                    button2.Text = "Yellow";
                    button3.Text = "Orange";
                    button4.Text = "Red";
                    correctAnswer = 1;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.questions;
                    lblQuestion.Text = "What is the name of the main character from Iron Man?";
                    button1.Text = "Tony Stank";
                    button2.Text = "Tony Stark";
                    button3.Text = "Rody";
                    button4.Text = "Peter Quill";
                    correctAnswer = 2;
                    break;

                case 3:
                    pictureBox1.Image = Properties.Resources.csgo;
                    lblQuestion.Text = "What is the name of this game?";
                    button1.Text = "Call of Duty";
                    button2.Text = "Battlefield";
                    button3.Text = "Fortnite";
                    button4.Text = "CS - GO";
                    correctAnswer = 4;
                    break;

                case 4:
                    pictureBox1.Image = Properties.Resources.fortnite;
                    lblQuestion.Text = "Which Publisher made this game?";
                    button1.Text = "EA";
                    button2.Text = "Activision";
                    button3.Text = "Epic Games";
                    button4.Text = "Equare Enix";
                    correctAnswer = 3;
                    break;

                case 5:
                    pictureBox1.Image = Properties.Resources.gears_of_war;
                    lblQuestion.Text = "What's the name of this game?";
                    button1.Text = "Gears of War";
                    button2.Text = "Assassins Creed";
                    button3.Text = "Uncharted";
                    button4.Text = "Call of Duty";
                    correctAnswer = 1;
                    break;

                case 6:
                    pictureBox1.Image = Properties.Resources.halo;
                    lblQuestion.Text = "What is main characters name in the game above?";
                    button1.Text = "Drake";
                    button2.Text = "Lara Croft";
                    button3.Text = "Master Chief";
                    button4.Text = "Markus";
                    correctAnswer = 3;
                    break;

                case 7:
                    pictureBox1.Image = Properties.Resources.witcher3;
                    lblQuestion.Text = "Who was Geralt looking for in for in Witcher 3?";
                    button1.Text = "Victoria";
                    button2.Text = "Mr Donut";
                    button3.Text = "Ciri";
                    button4.Text = "Yennifer";
                    correctAnswer = 3;
                    break;

                case 8:
                    pictureBox1.Image = Properties.Resources.questions;
                    lblQuestion.Text = "Which city is the capitol of England?";
                    button1.Text = "Birmingham";
                    button2.Text = "Brighton";
                    button3.Text = "Liverpool";
                    button4.Text = "London";
                    correctAnswer = 4;
                    break;
            }





        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                countDownLabel.Text = timeLeft + " sec";
            }
            else
            {
                timer1.Stop();
                questionNumber++;
                askQuestion(questionNumber);
                startTimer();
            }

            if (questionNumber == totalQuestions &&  timeLeft == 0)
            {
                endGame();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            startButton.Enabled = false;
            startTimer();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
    }
}
