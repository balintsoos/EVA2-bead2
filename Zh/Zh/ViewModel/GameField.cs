using Zh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zh.ViewModel
{
    public class GameField : ViewModelBase
    {
        private int _color;

        public DelegateCommand SelectCommand { get; private set; }

        /// <summary>
        /// Felirat lekérdezése, vagy beállítása.
        /// </summary>
        public int Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public GameModel Model { get; set; }

        public GameField()
        {
            SelectCommand = new DelegateCommand(param => { Model.Selected = new Coordinate(X, Y); });
        }



        /// <summary>
        /// Vízszintes koordináta lekérdezése, vagy beállítása.
        /// </summary>
        public Int32 X { get; set; }

        /// <summary>
        /// Függőleges koordináta lekérdezése, vagy beállítása.
        /// </summary>
        public Int32 Y { get; set; }

        /// <summary>
        /// Sorszám lekérdezése.
        /// </summary>
        //public Int32 Number { get; set; }

    }
}
