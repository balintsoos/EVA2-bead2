using Asteroids.ViewModel;
using Asteroids.Utils;
using System;
using System.Windows;

namespace Asteroids
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AsteroidsViewModel _viewModel;
        private MainWindow _mainWindow;
        private int _fieldSize;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _viewModel = new AsteroidsViewModel();

            _viewModel.OnNewGame += new EventHandler(ViewModel_OnNewGame);
            _viewModel.OnGameOver += new EventHandler<String>(ViewModel_OnGameOver);
            _viewModel.OnFieldsChanged += new EventHandler<FieldsChangedEventArgs>(ViewModel_OnFieldsChanged);

            _mainWindow = new MainWindow();
            _mainWindow.DataContext = _viewModel;

            _mainWindow.Closed += new EventHandler(MainWindow_Closed);
            _mainWindow.Show();

            _fieldSize = 100;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Shutdown();
        }

        private void ViewModel_OnNewGame(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                _mainWindow._PauseResumeButton.Visibility = Visibility.Visible;
                _mainWindow._GameTime.Visibility = Visibility.Visible;
                _mainWindow._Board.Visibility = Visibility.Visible;
            }));
        }

        private void ViewModel_OnGameOver(object sender, String message)
        {
            String header = "Game Over";
            MessageBox.Show(message, header, MessageBoxButton.OK, MessageBoxImage.Error);
            _viewModel.StartNewGame();
        }

        private void ViewModel_OnFieldsChanged(object sender, FieldsChangedEventArgs args)
        {
            foreach (Coordinate asteroid in args.Asteroids)
            {
                // graphics.DrawImage(Properties.Resources.asteroid, asteroid.X * _fieldSize, asteroid.Y * _fieldSize, _fieldSize, _fieldSize);
            }
        }
    }
}
