using System.Reflection.Metadata;
using Do_An.Models;

namespace Do_An
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            DrawChessBoard();
        }
        void DrawChessBoard() {
            Button oldButton = new Button() { Width = 0, Location = new Point(0,0) };
            for (int i = 0; i < Constants.chessboard_height; i++)
            {
                for (int j = 0; j < Constants.chessboard_width; j++)
                {
                    Button btn = new Button() { Width = Constants.chess_width, Height = Constants.chess_height, Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y) };
                    panelChessBoard.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0,oldButton.Location.Y+Constants.chess_height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
            MessageBox.Show("Chessboard initiated!","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
        }
    }
}
