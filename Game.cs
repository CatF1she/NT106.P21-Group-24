using Do_An.Models;
using Do_An.Services;
namespace Do_An
{
    public partial class Game : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public Game()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(panelChessBoard);
            ChessBoard.DrawChessBoard();
        }
    }
}
