using System.Diagnostics;

namespace Tic_Tack_Toe
{
    public partial class LogInForm : Form
    {
        private readonly Game Game;

        private readonly Database Database;
        public LogInForm(Game game, Database? database = null)
        {
            this.Game = game;
            if (database == null)
            {
                this.Database = Database.Deserialize();
            }
            else
            {
                this.Database = database;
            }
            InitializeComponent();
            if (Game.FirstPlayer == null)
            {
                SelectPlayerLabel.Text = "Select First Player";
            } else
            {
                SelectPlayerLabel.Text = "Select Second Player";
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (UserNameTextBox.Text == "")
            {
                MessageBox.Show("Please enter user name");
                return;
            }
            if (Game.FirstPlayer == null)
            {
                Player first = Database.GetPlayerByNameOrCreate(UserNameTextBox.Text);
                Game.FirstPlayer = first;
                LogInForm logInForm = new(Game, this.Database);
                logInForm.Show();
                this.Hide();
            } else
            {
                Player second = Database.GetPlayerByNameOrCreate(UserNameTextBox.Text);
                Game.SecondPlayer = second;
                GameForm game = new(Game, this.Database);
                game.Show();
                this.Hide();
            }
        }

        private void LogInForm_Closing(object sender, EventArgs e)
        {
            Debug.WriteLine("------------------------------------");
            Database.Serialize(this.Database);
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }
    }
}