using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zh.Model;

namespace Zh.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private GameModel _model;

        #region Properties

        public DelegateCommand NewGameCommand { get; private set; }
        public ObservableCollection<GameField> Fields { get; set; }

        #endregion

        #region Constructor

        public GameViewModel(GameModel model)
        {
            _model = model;

            NewGameCommand = new DelegateCommand(param => StartNewGame());

            Fields = new ObservableCollection<GameField>();
        }

        #endregion

        private void StartNewGame()
        {

        }
    }
}
