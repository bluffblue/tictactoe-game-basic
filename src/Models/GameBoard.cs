using System;
using System.Collections.Generic;
using System.Linq;

public class GameBoard
{
    private string[] board = new string[9];
    private readonly Random random = new Random();
    public string CurrentPlayer { get; private set; }
    public GameMode GameMode { get; set; }
    public DifficultyLevel Difficulty { get; set; }

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
        
        if (GameMode == GameMode.SinglePlayer && !IsGameOver())
        {
            MakeAIMove();
        }
        
        return true;
    }

    private void MakeAIMove()
    {
        int position = Difficulty switch
        {
            DifficultyLevel.Easy => GetEasyMove(),
            DifficultyLevel.Medium => GetMediumMove(),
            DifficultyLevel.Hard => GetHardMove(),
            DifficultyLevel.Ultimate => GetUltimateMove(),
            _ => GetEasyMove()
        };

        board[position] = CurrentPlayer;
        CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
    }

    private int GetEasyMove()
    {
        var emptyPositions = GetEmptyPositions();
        return emptyPositions[random.Next(emptyPositions.Count)];
    }

    private int GetMediumMove()
    {
        if (random.Next(100) < 50)
            return GetHardMove();
        return GetEasyMove();
    }

    private int GetHardMove()
    {
        var winningMove = FindWinningMove();
        if (winningMove != -1) return winningMove;

        var blockingMove = FindBlockingMove();
        if (blockingMove != -1) return blockingMove;

        return GetEasyMove();
    }

    private int GetUltimateMove()
    {
        var bestScore = int.MinValue;
        var bestMove = -1;

        for (int i = 0; i < 9; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
            {
                board[i] = CurrentPlayer;
                var score = Minimax(board, 0, false);
                board[i] = string.Empty;

                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        return bestMove != -1 ? bestMove : GetEasyMove();
    }

    private int Minimax(string[] board, int depth, bool isMaximizing)
    {
        if (CheckWinner(out string winner))
        {
            return winner == CurrentPlayer ? 10 - depth : depth - 10;
        }

        if (!board.Any(string.IsNullOrEmpty))
            return 0;

        if (isMaximizing)
        {
            var bestScore = int.MinValue;
            for (int i = 0; i < 9; i++)
            {
                if (string.IsNullOrEmpty(board[i]))
                {
                    board[i] = CurrentPlayer;
                    var score = Minimax(board, depth + 1, false);
                    board[i] = string.Empty;
                    bestScore = Math.Max(score, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            var bestScore = int.MaxValue;
            for (int i = 0; i < 9; i++)
            {
                if (string.IsNullOrEmpty(board[i]))
                {
                    board[i] = CurrentPlayer == "X" ? "O" : "X";
                    var score = Minimax(board, depth + 1, true);
                    board[i] = string.Empty;
                    bestScore = Math.Min(score, bestScore);
                }
            }
            return bestScore;
        }
    }

    private int FindWinningMove()
    {
        return FindMoveForPlayer(CurrentPlayer);
    }

    private int FindBlockingMove()
    {
        return FindMoveForPlayer(CurrentPlayer == "X" ? "O" : "X");
    }

    private int FindMoveForPlayer(string player)
    {
        for (int i = 0; i < 9; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
            {
                board[i] = player;
                if (CheckWinner(out _))
                {
                    board[i] = string.Empty;
                    return i;
                }
                board[i] = string.Empty;
            }
        }
        return -1;
    }

    private List<int> GetEmptyPositions()
    {
        var emptyPositions = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            if (string.IsNullOrEmpty(board[i]))
                emptyPositions.Add(i);
        }
        return emptyPositions;
    }

    public bool IsGameOver()
    {
        return CheckWinner(out _) || IsBoardFull();
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