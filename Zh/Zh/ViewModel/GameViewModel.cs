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
        public int GameSize { get; set; }

        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand StepCommand { get; private set; }

        public ObservableCollection<GameField> Fields { get; set; }

        public GameViewModel(int gameSize, GameModel model)
        {
            _model = model;

            GameSize = gameSize;

            _model.newGame(GameSize, generateTable(GameSize));

            NewGameCommand = new DelegateCommand(param => StartNewGame());
            StepCommand = new DelegateCommand(param => { StepGame(param.ToString()); });

            Fields = new ObservableCollection<GameField>();

            foreach (Field field in _model.getFields())
            {
                Fields.Add(new GameField()
                {
                    Model = _model,
                    Color = field.Color,
                    X = field.X,
                    Y = field.Y,
                });
            }
        }

        private void RefreshTable()
        {
            foreach (GameField field in Fields)
            {
                field.Color = _model.GameBoard[new Coordinate(field.X, field.Y)].Color;
            }
        }

        private void StartNewGame()
        {
            _model.newGame(GameSize, generateTable(GameSize));

            OnPropertyChanged("GameSize");

            Fields.Clear();
            foreach (Field field in _model.getFields())
            {
                Fields.Add(new GameField()
                {
                    Model = _model,
                    Color = field.Color,
                    X = field.X,
                    Y = field.Y,
                });
            }
        }

        private void StepGame(String direction)
        {
            switch (direction) // megkapjuk a billentyűt
            {
                case "Up":
                    _model.move(Move.UP);
                    break;
                case "Left":
                    _model.move(Move.LEFT);
                    break;
                case "Down":
                    _model.move(Move.DOWN);
                    break;
                case "Right":
                    _model.move(Move.RIGHT);
                    break;
                default:
                    break;
            }

            RefreshTable();
        }

        private Dictionary<Coordinate, Field> generateTable(int gameSize)
        {
            Dictionary<Coordinate, Field> gameBoard = new Dictionary<Coordinate, Field>();

            for (int i = 0; i < gameSize; i++)
            {
                for (int j = 0; j < gameSize; j++)
                {
                    Field f = new Field(i, j, i);

                    gameBoard.Add(new Coordinate(i, j), f);
                }
            }

            return gameBoard;
        }


    }
}
