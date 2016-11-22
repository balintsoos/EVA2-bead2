using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.ViewModel
{
    public class AsteroidsViewModel
    {
        #region Private fields

        private AsteroidsModel _model;

        private int _rows;
        private int _columns;
        private int _fieldSize;

        #endregion

        #region Constructor

        public AsteroidsViewModel()
        {
            _rows = 5;
            _columns = 5;
            _fieldSize = 100;

            _model = new AsteroidsModel(_rows, _columns);
            _model.FieldsChanged += new EventHandler(Model_FieldsChanged);
            _model.TimePassed += new EventHandler<int>(Model_TimePassed);
            _model.GameOver += new EventHandler<int>(Model_GameOver);
        }

        #endregion

        #region Model event handlers

        private void Model_FieldsChanged(object sender, EventArgs e)
        {
            RefreshPanel();
        }

        private void Model_TimePassed(object sender, int time)
        {
            RefreshTime(time);
        }

        private void Model_GameOver(object sender, int time)
        {
            string header = "Game Over";
            string text = "You lived for " + time.ToString() + " seconds";
            // MessageBox.Show(text, header, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            InitGame();
        }

        #endregion

        #region Private Methods

        private void RefreshPanel()
        {

        }

        private void RefreshTime(int time)
        {

        }

        private void InitGame()
        {

        }

        #endregion
    }
}
