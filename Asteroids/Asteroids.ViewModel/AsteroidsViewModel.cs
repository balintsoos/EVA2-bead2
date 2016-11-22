using Asteroids.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Asteroids.ViewModel
{
    public class AsteroidsViewModel : INotifyPropertyChanged
    {
        public NewGameCommand NewGame { get; private set; }
        public PauseResumeCommand PauseResumeGame { get; private set; }

        public String PauseResumeLabel
        {
            get
            {
                if (_model.Paused)
                {
                    return "Resume";
                }
                else
                {
                    return "Pause";
                }
            }
        }
        
        #region Private fields

        private AsteroidsModel _model;

        #endregion

        #region Constructor

        public AsteroidsViewModel()
        {
            _model = new AsteroidsModel(5, 5);
            _model.FieldsChanged += new EventHandler(Model_FieldsChanged);
            _model.TimePassed += new EventHandler<int>(Model_TimePassed);
            _model.GameOver += new EventHandler<int>(Model_GameOver);

            NewGame = new NewGameCommand(this);
            PauseResumeGame = new PauseResumeCommand(this);
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
            StartNewGame();
        }

        #endregion

        #region Private Methods

        private void RefreshPanel()
        {

        }

        private void RefreshTime(int time)
        {

        }

        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        public void StartNewGame()
        {
            _model.NewGame();

            RefreshTime(0);
        }

        public void PauseResume()
        {
            if (_model.Paused)
            {
                _model.Resume();
            }
            else
            {
                _model.Pause();
            }
        }

        #endregion
    }
}
