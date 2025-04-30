namespace FrontEnd
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
