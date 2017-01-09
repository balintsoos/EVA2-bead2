using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zh.Model;

namespace Zh.ViewModel
{
    public class GameField : ViewModelBase
    {
        private FieldType _type;

        public FieldType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public Int32 X { get; set; }

        public Int32 Y { get; set; }
    }
}
