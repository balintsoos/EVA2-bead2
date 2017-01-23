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
        private Random _random;
        public int GameSize { get; set; }

        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand StepCommand { get; private set; }

        public ObservableCollection<GameField> Fields { get; set; }

        public GameViewModel(int gameSize, GameModel model)
        {
            _model = model;

            _random = new Random();

            GameSize = gameSize;

            NewGameCommand = new DelegateCommand(param => StartNewGame());
            StepCommand = new DelegateCommand(param => { StepGame(param.ToString()); });

            Fields = new ObservableCollection<GameField>();



            StartNewGame();
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
                Fields.Add(new GameField
                {
                    Color = field.Color,
                    X = field.X,
                    Y = field.Y,
                    SelectCommand = new DelegateCommand(selectedField => _model.Selected = new Coordinate((selectedField as GameField).X, (selectedField as GameField).Y))
                });
            }

            Shuffle();
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

        private void Shuffle()
        {
            for(int i = 0; i < GameSize; ++i)
            {
                _model.Selected = new Coordinate(_random.Next(GameSize), _random.Next(GameSize));

                int direction = _random.Next(4);

                switch (direction)
                {
                    case 0:
                        StepGame("Up");
                        break;
                    case 1:
                        StepGame("Left");
                        break;
                    case 2:
                        StepGame("Down");
                        break;
                    case 3:
                        StepGame("Right");
                        break;
                    default:
                        break;
                }
            }
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
