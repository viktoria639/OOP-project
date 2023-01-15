using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;

namespace Tic_Tack_Toe
{
    public partial class GameForm : Form
    {
        private readonly Game Game;

        private bool FirstPlayerTurn = true;

        private int[,] Board = new int[3, 3];

        private bool GameOver = false;

        private Player? Winner = null;

        private Database Database;
        public GameForm(Game game, Database database)
        {
            this.Game = game;
            this.Database = database;
            InitializeComponent();
            FillBoard();
            AskForRaiting();
            StartGame();
        }

        private void FillBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = 0;
                }
            }
        }

        private void StartGame()
        {
            HintLabel.Text = Game.FirstPlayer.Name + "'s turn!";
            FirstPlayerNameLabel.Text = Game.FirstPlayer.Name;
            SecondPlayerNameLabel.Text = Game.SecondPlayer.Name;
            FirstPlayerRaitingLabel.Text = Game.FirstPlayer.Raiting.ToString();
            SecondPlayerRaitingLabel.Text = Game.SecondPlayer.Raiting.ToString();
        }


        private void AskForRaiting()
        {
            HintLabel.Text = "Please enter game raiting";
            string input = "";
            while (string.IsNullOrEmpty(input))
            {
                try
                {
                    input = Interaction.InputBox("Please enter raiting for this game", "Raiting input", "");
                    int result = Int32.Parse(input);
                    if (result < 0)
                    {
                        MessageBox.Show("Raiting can not be less than 0");
                    }
                    else
                    {
                        this.Game.Raiting = result;
                        MessageBox.Show("Raiting for this game set to " + result);
                        return;
                    }
                }
                catch (FormatException) { MessageBox.Show("Invalid input"); }

                input = Interaction.InputBox("Please enter game raiting", "Raiting input", "");
            }
        }


        private void CheckIfGameIsOver()
        {
            if (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0] && Board[0, 0] != 0)
            {
                GameOver = true;
                if (Board[0, 0] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1] && Board[0, 1] != 0)
            {
                GameOver = true;
                if (Board[0, 1] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2] && Board[0, 2] != 0)
            {
                GameOver = true;
                if (Board[0, 2] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2] && Board[0, 0] != 0)
            {
                GameOver = true;
                if (Board[0, 0] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[1, 0] == Board[1, 1] && Board[1, 1] == Board[1, 2] && Board[1, 0] != 0)
            {
                GameOver = true;
                if (Board[1, 0] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[2, 0] == Board[2, 1] && Board[2, 1] == Board[2, 2] && Board[2, 0] != 0)
            {
                GameOver = true;
                if (Board[2, 0] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != 0)
            {
                GameOver = true;
                if (Board[0, 0] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }
            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != 0)
            {
                GameOver = true;
                if (Board[0, 2] == 1)
                    Winner = Game.FirstPlayer;
                else
                    Winner = Game.SecondPlayer;
                return;

            }

        }

        private void ButtonClickEvent(Button button, int i, int j)
        {
            if (GameOver)
                return;

            if (Board[i, j] == 0)
            {
                if (FirstPlayerTurn)
                {
                    DrawCross(button);
                }
                else
                {
                    DrawCircle(button);
                }
                Board[i, j] = FirstPlayerTurn ? 1 : 2;
                FirstPlayerTurn = !FirstPlayerTurn;
                Update();
                CheckIfGameIsOver();
                if (GameOver)
                {
                    MessageBox.Show("Game is Over");
                    HintLabel.Text = "Winner - " + Winner.Name;
                    Winner.Raiting += Game.Raiting;
                    if (Winner == Game.FirstPlayer)
                    {
                        Game.SecondPlayer.Raiting -= Game.Raiting;
                    }
                    else
                    {
                        Game.FirstPlayer.Raiting -= Game.Raiting;
                    }
                    Database.Serialize(this.Database);
                    Update();
                }
            }
        }

        private void DrawCircle(Button button)
        {
            button.Text = "O";
        }

        private void DrawCross(Button button)
        {
            button.Text = "X";
        }

        private void GameForm_Closing(object sender, EventArgs e)
        {
            Debug.WriteLine("------------------------------------");
            Database.Serialize(this.Database);
        }

        private new void Update()
        {
            if (FirstPlayerTurn)
            {
                HintLabel.Text = Game.FirstPlayer.Name + "'s turn";
            }
            else
            {
                HintLabel.Text = Game.SecondPlayer.Name + "'s turn";
            }
            FirstPlayerRaitingLabel.Text = Game.FirstPlayer.Raiting.ToString();
            SecondPlayerRaitingLabel.Text = Game.SecondPlayer.Raiting.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button1, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button2, 0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button3, 0, 2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button4, 1, 0);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button5, 1, 1);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button6, 1, 2);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button7, 2, 0);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button8, 2, 1);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonClickEvent(button9, 2, 2);

        }
    }
}
