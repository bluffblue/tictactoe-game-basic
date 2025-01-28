public class GameBoard
{
    private string[] board = new string[9];
    public string CurrentPlayer { get; private set; }

    public GameBoard()
    {
        ResetGame();
    }

    public string[] GetBoard() => board;

    public bool MakeMove(int position)
    {
        if (position < 0 || position > 8 || !string.IsNullOrEmpty(board[position]))
            return false;

        board[position] = CurrentPlayer;
        CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        return true;
    }

    public bool CheckWinner(out string winner)
    {
        int[][] winningCombinations = {
            new[] {0, 1, 2}, new[] {3, 4, 5}, new[] {6, 7, 8},
            new[] {0, 3, 6}, new[] {1, 4, 7}, new[] {2, 5, 8},
            new[] {0, 4, 8}, new[] {2, 4, 6}
        };

        foreach (var combination in winningCombinations)
        {
            if (!string.IsNullOrEmpty(board[combination[0]]) &&
                board[combination[0]] == board[combination[1]] &&
                board[combination[1]] == board[combination[2]])
            {
                winner = board[combination[0]];
                return true;
            }
        }

        winner = null;
        return false;
    }

    public bool IsBoardFull() => !board.Any(string.IsNullOrEmpty);

    public void ResetGame()
    {
        for (int i = 0; i < 9; i++)
            board[i] = string.Empty;
        CurrentPlayer = "X";
    }
} 