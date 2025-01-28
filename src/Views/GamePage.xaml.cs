using Xamarin.Forms;
using TicTacToe.ViewModels;

namespace TicTacToe.Views
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            BindingContext = new GameViewModel();
        }
    }
} 