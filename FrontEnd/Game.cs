using System.Windows.Forms;

namespace FrontEnd
{

    public partial class Game : Form
    {
        private bool isPlayerX = true; // X goes first
        private Image xImage;
        private Image oImage;
        private int[,] board;
        private const int EMPTY = 0;
        private const int PLAYER_X_ID = 1;
        private const int PLAYER_O_ID = 2;
        public Game()
        {
            InitializeComponent();
            DrawChessBoard();
            LoadImages();
            board = new int[Constants.chessboard_height, Constants.chessboard_width];
        }
        private void LoadImages()
        {
            xImage = Image.FromFile("Resources/x.png");
            oImage = Image.FromFile("Resources/o.png");
        }
        void DrawChessBoard() {
            Button oldButton = new Button() { Height = 0, Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i <Constants.chessboard_height;i++) {
                for (int j = 0; j < Constants.chessboard_width;j ++)
                {
                    Button btn = new Button()
                    {
                        Width = Constants.chess_width,
                        Height = Constants.chess_height,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        Tag = new Point(j, i)
                    };
                    btn.Click += btn_Click; 
                    panelChessBoard.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constants.chess_height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
            MessageBox.Show("Chessboard initialized!");
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.BackgroundImage == null)
            {
                Point pos = (Point)clickedButton.Tag;
                int currentPlayer = isPlayerX ? PLAYER_X_ID : PLAYER_O_ID;

                //update button image
                clickedButton.BackgroundImage = isPlayerX ? xImage : oImage;
                clickedButton.BackgroundImageLayout = ImageLayout.Stretch; // Scale the image
                clickedButton.Enabled = false;

                // Update board
                board[pos.Y, pos.X] = currentPlayer;

                // Win check
                if (CheckWin(pos.X, pos.Y, currentPlayer))
                {
                    MessageBox.Show($"Player {(isPlayerX ? "X" : "O")} wins!");
                    DisableAllButtons();
                    return;
                }

                isPlayerX = !isPlayerX;
                //stop focusing on the next button
                this.ActiveControl = null;
            }
        }
        private bool CheckWin(int x, int y, int player)
        {
            return (CountDirection(x, y, 1, 0, player) + CountDirection(x, y, -1, 0, player) + 1 >= 5) || // Horizontal
                   (CountDirection(x, y, 0, 1, player) + CountDirection(x, y, 0, -1, player) + 1 >= 5) || // Vertical
                   (CountDirection(x, y, 1, 1, player) + CountDirection(x, y, -1, -1, player) + 1 >= 5) || // Diagonal \
                   (CountDirection(x, y, 1, -1, player) + CountDirection(x, y, -1, 1, player) + 1 >= 5);   // Diagonal /
        }

        private int CountDirection(int x, int y, int dx, int dy, int player)
        {
            int count = 0;
            int i = 1;

            while (true)
            {
                int newX = x + dx * i;
                int newY = y + dy * i;

                if (newX < 0 || newY < 0 || newX >= Constants.chessboard_width || newY >= Constants.chessboard_height)
                    break;

                if (board[newY, newX] == player)
                    count++;
                else
                    break;

                i++;
            }

            return count;
        }
        private void DisableAllButtons()
        {
            foreach (Control ctrl in panelChessBoard.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }
    }
}
