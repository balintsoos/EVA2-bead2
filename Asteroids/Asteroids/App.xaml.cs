using System.Windows;
using Asteroids.ViewModel;

namespace Asteroids
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();

            AsteroidsViewModel viewModel = new AsteroidsViewModel();

            window.DataContext = viewModel;

            window.Show();
        }
    }
}
