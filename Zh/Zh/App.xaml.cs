using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zh.Model;
using Zh.ViewModel;
using Zh.View;

namespace Zh
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private GameModel _model;
        private GameViewModel _viewModel;
        private MainWindow _view;

        #endregion

        #region Constructor

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        #endregion

        #region Application event handlers

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _model = new GameModel();

            _viewModel = new GameViewModel(_model);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }

        #endregion


    }
}
