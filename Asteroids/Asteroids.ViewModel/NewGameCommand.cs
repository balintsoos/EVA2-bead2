using System;
using System.Windows.Input;

namespace Asteroids.ViewModel
{
    public class NewGameCommand : ICommand
    {
        private AsteroidsViewModel _viewModel;

        public NewGameCommand(AsteroidsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public Boolean CanExecute(Object parameter)
        {
            return true; // always
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(Object parameter)
        {
            _viewModel.StartNewGame();
        }
    }
}
