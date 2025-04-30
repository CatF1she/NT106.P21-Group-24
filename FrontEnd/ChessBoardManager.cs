using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FrontEnd
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set {  chessBoard = value; }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard)
        {
            ChessBoard = chessBoard;
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {


            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Constants.chessboard_height; i++)
            {
                for (int j = 0; j < Constants.chessboard_width; j++)
                {
                    Button btn = new Button() { Width = Constants.chess_width, Height = Constants.chess_height, Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y) };
                    ChessBoard.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constants.chess_height);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
            MessageBox.Show("Chessboard initiated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
