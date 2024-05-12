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

namespace TicTacToe
{
    
    public partial class MainWindow : Window
    {
        private char[,] board = new char[3, 3];
        private bool playerXTurn = true;
        private int movesMade = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            int row = Grid.GetRow(button);
            int col = Grid.GetColumn(button);

            if (board[row, col] == '\0')
            {
                if (playerXTurn)
                {
                    button.Content = "X";
                    board[row, col] = 'X';
                }
                else
                {
                    button.Content = "O";
                    board[row, col] = 'O';
                }

                playerXTurn = !playerXTurn;
                movesMade++;

                CheckForWinner();

                if (movesMade == 9)
                {
                    MessageBox.Show("Draw!");
                    ResetGame();
                }
            }
        }

        private void CheckForWinner()
        {
            if (movesMade < 5) return;

            bool winner = false;

            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '\0' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    winner = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != '\0' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    winner = true;
                }
            }

            if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                winner = true;
            }
            else if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                winner = true;
            }

            if (winner)
            {
                string winnerMessage = playerXTurn ? "O" : "X";
                MessageBox.Show(winnerMessage + " wins!");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            board = new char[3, 3];
            playerXTurn = true;
            movesMade = 0;

            foreach (UIElement element in gameGrid.Children)
            {
                Button button = element as Button;
                if (button != null)
                {
                    button.Content = "";
                }
            }
        }
    }
}
