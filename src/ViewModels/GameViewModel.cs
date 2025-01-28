using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

public class GameViewModel : INotifyPropertyChanged
{
    private GameBoard gameBoard;
    private ObservableCollection<string> boardCells;
    private string gameStatus;
    private bool isGameOver;

    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<string> BoardCells
    {
        get => boardCells;
        set
        {
            boardCells = value;
            OnPropertyChanged();
        }
    }

    public string GameStatus
    {
        get => gameStatus;
        set
        {
            gameStatus = value;
            OnPropertyChanged();
        }
    }

    public bool IsGameOver
    {
        get => isGameOver;
        set
        {
            isGameOver = value;
            OnPropertyChanged();
        }
    }

    public ICommand CellTappedCommand { get; }
    public ICommand ResetGameCommand { get; }

    public GameViewModel()
    {
        gameBoard = new GameBoard();
        BoardCells = new ObservableCollection<string>(new string[9]);
        CellTappedCommand = new Command<int>(OnCellTapped);
        ResetGameCommand = new Command(ResetGame);
        UpdateGameStatus();
    }

    private void OnCellTapped(int position)
    {
        if (IsGameOver || !gameBoard.MakeMove(position))
            return;

        UpdateBoard();
        CheckGameState();
    }

    private void UpdateBoard()
    {
        var board = gameBoard.GetBoard();
        for (int i = 0; i < board.Length; i++)
            BoardCells[i] = board[i];
    }

    private void CheckGameState()
    {
        if (gameBoard.CheckWinner(out string winner))
        {
            GameStatus = $"Player {winner} Wins!";
            IsGameOver = true;
        }
        else if (gameBoard.IsBoardFull())
        {
            GameStatus = "Game Draw!";
            IsGameOver = true;
        }
        else
        {
            UpdateGameStatus();
        }
    }

    private void UpdateGameStatus()
    {
        GameStatus = $"Player {gameBoard.CurrentPlayer}'s Turn";
    }

    private void ResetGame()
    {
        gameBoard.ResetGame();
        for (int i = 0; i < BoardCells.Count; i++)
            BoardCells[i] = string.Empty;
        IsGameOver = false;
        UpdateGameStatus();
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
} 