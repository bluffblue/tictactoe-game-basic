using Xamarin.Forms;

namespace TicTacToe.Views
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new GamePage();
        }
    }
} 