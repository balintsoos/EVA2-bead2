﻿using Asteroids.Model;
using Asteroids.ViewModel;
using Asteroids.Utils;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Collections.Generic;

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
        private Board _board;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _board = new Board(5, 5);
            _fieldSize = 100;
            _viewModel = new AsteroidsViewModel(new AsteroidsModel(_board.Width, _board.Width));

            _viewModel.OnNewGame += new EventHandler(ViewModel_OnNewGame);
            _viewModel.OnGameOver += new EventHandler<String>(ViewModel_OnGameOver);
            _viewModel.OnFieldsChanged += new EventHandler<FieldsChangedEventArgs>(ViewModel_OnFieldsChanged);

            _mainWindow = new MainWindow();
            _mainWindow.DataContext = _viewModel;

            _mainWindow.Closed += new EventHandler(MainWindow_Closed);
            _mainWindow.Show();
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
                _mainWindow._Board.Width = _board.Width * _fieldSize;
                _mainWindow._Board.Height = _board.Height * _fieldSize;
                _mainWindow._Board.Visibility = Visibility.Visible;
                _mainWindow.Width = _mainWindow._Board.Width;
                _mainWindow.Height = _mainWindow._Board.Height + 95;
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
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                _mainWindow._Board.Children.Clear();

                PaintPlayer(args.Player);
                PaintAsteroids(args.Asteroids);
            }));
        }

        private void PaintPlayer(Coordinate player)
        {
            BitmapImage playerImage = new BitmapImage(new Uri(@"pack://application:,,,/Resources/ship.png"));
            Image img = new Image();

            img.Source = playerImage;
            img.Width = _fieldSize;
            img.Height = _fieldSize;

            Canvas.SetLeft(img, player.X * _fieldSize);
            Canvas.SetTop(img, player.Y * _fieldSize);
            _mainWindow._Board.Children.Add(img);
        }

        private void PaintAsteroids(List<Coordinate> asteroids)
        {
            BitmapImage asteroidImage = new BitmapImage(new Uri(@"pack://application:,,,/Resources/asteroid.png"));

            foreach (Coordinate asteroid in asteroids)
            {
                Image img = new Image();

                img.Source = asteroidImage;
                img.Width = _fieldSize;
                img.Height = _fieldSize;

                Canvas.SetLeft(img, asteroid.X * _fieldSize);
                Canvas.SetTop(img, asteroid.Y * _fieldSize);
                _mainWindow._Board.Children.Add(img);
            }
        }
    }
}
