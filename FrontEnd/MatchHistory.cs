using BackEnd.Models;
using BackEnd.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An
{
    public partial class MatchHistory : Form
    {
        private ObjectId userId;
        private string sessionId;

        public MatchHistory(ObjectId userId, string sessionId)
        {
            InitializeComponent();
            this.userId = userId;
            this.sessionId = sessionId;

            this.Load += MatchHistory_Load;
            this.Resize += (_, __) => AdjustLabelWidths();
            panelHeader.MouseDown += PanelHeader_MouseDown;
        }
        private async void MatchHistory_Load(object sender, EventArgs e)
        {
            var db = new DatabaseConnection();
            var gameSessions = db.GetGameSessionsCollection();
            var users = db.GetUsersCollection();

            var session = await gameSessions.Find(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (session == null)
            {
                MessageBox.Show("Unable to get match history.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var allUserIds = session.Moves.Select(m => m.PlayerId).Distinct().ToList();
            var userIdFilter = Builders<BsonDocument>.Filter.In("_id", allUserIds.Select(ObjectId.Parse));
            var userDocs = await users.Find(userIdFilter).ToListAsync();

            var playerNames = userDocs.ToDictionary(
                doc => doc["_id"].ToString(),
                doc => doc.GetValue("username", "Unknown").AsString
            );

            string playerXName = playerNames.GetValueOrDefault(session.PlayerXId, "Unknown");
            string playerOName = playerNames.GetValueOrDefault(session.PlayerOId ?? "", "Unknown");

            string winnerName = playerNames.GetValueOrDefault(session.WinnerPlayerId ?? "", "Unknown");

            flowLayoutPanelMoveList.Controls.Clear();

            if (session.WinnerPlayerId == null || playerXName == "Unknown" || playerOName == "Unknown" || winnerName == "Unknown")
            {
                labelSummary.Text = "⚠ Data error — winner undetermined";
            }
            else if (session.Moves.LastOrDefault()?.X == 101 && session.Moves.LastOrDefault()?.Y == 101)
            {
                string loserId = session.WinnerPlayerId == session.PlayerXId ? session.PlayerOId : session.PlayerXId;
                string loserName = playerNames.GetValueOrDefault(loserId ?? "", "Unknown");
                labelSummary.Text = $"{winnerName} won because {loserName} left the game.";
            }
            else
            {
                var lastMove = session.Moves.LastOrDefault();
                if (lastMove != null)
                {
                    int[,] board = session.Board;
                    int x = lastMove.X;
                    int y = lastMove.Y;
                    int symbol = (lastMove.PlayerId == session.PlayerXId) ? 1 : 2;

                    string reason = "with 5 in a row";
                    if (IsWinning(board, x, y, symbol, out string direction))
                        reason = $"with 5 {(symbol == 1 ? "X" : "O")} in a {direction} row";

                    labelSummary.Text = $"{winnerName} won {reason}";
                }
                else
                {
                    labelSummary.Text = $"{winnerName} won the game";
                }
            }




            // Render each move
            foreach (var move in session.Moves.OrderBy(m => m.Time))
            {
                string movePlayerName = playerNames.GetValueOrDefault(move.PlayerId, "Unknown");
                Color moveColor;
                string moveText;

                if (move.X == 69 && move.Y == 69)
                {
                    moveColor = Color.Gainsboro;
                    moveText = $"[{move.Time.ToLocalTime():HH:mm:ss}] {movePlayerName} skipped their turn";
                }
                else if (move.X == 101 && move.Y == 101)
                {
                    moveColor = Color.MediumPurple;
                    moveText = $"[{move.Time.ToLocalTime():HH:mm:ss}] {movePlayerName} disconnected — game ended";
                }
                else
                {
                    moveColor = (move.PlayerId == session.PlayerXId) ? Color.LightCoral : Color.LightBlue;
                    moveText = $"[{move.Time.ToLocalTime():HH:mm:ss}] {movePlayerName} moved to ({move.X}, {move.Y})";
                }

                var moveLabel = new Label
                {
                    AutoSize = false,
                    Height = 40,
                    Width = flowLayoutPanelMoveList.ClientSize.Width,
                    Font = new Font("Segoe UI", 10),
                    BackColor = moveColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    BorderStyle = BorderStyle.None,
                    ForeColor = Color.Black,
                    Margin = new Padding(1),
                    Padding = new Padding(4),
                    Text = moveText
                };

                flowLayoutPanelMoveList.Controls.Add(moveLabel);
            }

            AdjustLabelWidths();
        }
        private bool IsWinning(int[,] board, int x, int y, int player, out string direction)
        {
            if (Count(board, x, y, 1, 0, player) + Count(board, x, y, -1, 0, player) + 1 >= 5)
            {
                direction = "horizontal";
                return true;
            }
            if (Count(board, x, y, 0, 1, player) + Count(board, x, y, 0, -1, player) + 1 >= 5)
            {
                direction = "vertical";
                return true;
            }
            if (Count(board, x, y, 1, 1, player) + Count(board, x, y, -1, -1, player) + 1 >= 5)
            {
                direction = "diagonal ↘";
                return true;
            }
            if (Count(board, x, y, 1, -1, player) + Count(board, x, y, -1, 1, player) + 1 >= 5)
            {
                direction = "diagonal ↙";
                return true;
            }

            direction = "";
            return false;
        }

        private int Count(int[,] board, int x, int y, int dx, int dy, int player)
        {
            int count = 0;
            int w = board.GetLength(1);
            int h = board.GetLength(0);

            for (int i = 1; i < 5; i++)
            {
                int nx = x + dx * i, ny = y + dy * i;
                if (nx < 0 || ny < 0 || nx >= w || ny >= h || board[ny, nx] != player)
                    break;
                count++;
            }

            return count;
        }



        private void AdjustLabelWidths()
        {
            foreach (Control ctrl in flowLayoutPanelMoveList.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Width = flowLayoutPanelMoveList.ClientSize.Width;
                }
            }
        }

        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
