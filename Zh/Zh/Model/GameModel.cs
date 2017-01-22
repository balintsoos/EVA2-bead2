using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zh.Model
{
    public class GameModel
    {
        private int gameSize;
        private Dictionary<Coordinate, Field> gameBoard;

        public void newGame(int gameSize, Dictionary<Coordinate, Field> gameBoard)
        {
            this.gameSize = gameSize;
            this.gameBoard = gameBoard;
        }

        public int GameSize
        {
            get { return gameSize; }
        }

        public Boolean isFieldOnBoard(Coordinate p)
        {
            return gameBoard.ContainsKey(p);
        }

        public Field getField(int x, int y)
        {
            return gameBoard[new Coordinate(x, y)];
        }

        public List<Field> getFields()
        {
            if (gameBoard != null)
            {
                return gameBoard.Values.ToList();
            }
            return null;
        }

        public Dictionary<Coordinate, Field> GameBoard
        {
            get { return gameBoard; }
        }

        public Coordinate Selected { get; set; }

        public void move(Move direction)
        {
            switch (direction)
            {
                case Move.UP:
                    MoveUp();
                    break;
                case Move.DOWN:
                    MoveDown();
                    break;
                case Move.LEFT:
                    MoveLeft();
                    break;
                case Move.RIGHT:
                    MoveRight();
                    break;
            }
        }

        public void MoveUp()
        {
            if (Selected == null)
            {
                return;
            }

            List<Field> list = gameBoard.Values.ToList();

            foreach (Field field in list)
            {
                if (field.Y == Selected.Y)
                {
                    field.Coords = new Coordinate((field.X - 1) % GameSize, field.Y);
                }
            }

            rebuild(list);
        }

        public void MoveDown()
        {
            if (Selected == null)
            {
                return;
            }

            List<Field> list = gameBoard.Values.ToList();

            foreach (Field field in list)
            {
                if (field.Y == Selected.Y)
                {
                    field.Coords = new Coordinate((field.X + 1) % GameSize, field.Y);
                }
            }

            rebuild(list);
        }

        public void MoveLeft()
        {
            if (Selected == null)
            {
                return;
            }

            List<Field> list = gameBoard.Values.ToList();

            foreach (Field field in list)
            {
                if (field.X == Selected.X)
                {
                    field.Coords = new Coordinate(field.X, (field.Y - 1) % GameSize);
                }
            }

            rebuild(list);
        }

        public void MoveRight()
        {
            if (Selected == null)
            {
                return;
            }

            List<Field> list = gameBoard.Values.ToList();

            foreach (Field field in list)
            {
                if (field.X == Selected.X)
                {
                    field.Coords = new Coordinate(field.X, (field.Y + 1) % GameSize);
                }
            }

            rebuild(list);
        }

        private void rebuild(List<Field> list)
        {
            gameBoard.Clear();

            foreach (Field field in list)
            {
                gameBoard.Add(new Coordinate(field.X, field.Y), new Field(field.X, field.Y, field.Color));
            }
        }

    }
}
