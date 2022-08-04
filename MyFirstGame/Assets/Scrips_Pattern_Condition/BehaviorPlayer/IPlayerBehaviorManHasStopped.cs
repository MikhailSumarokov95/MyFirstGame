using UnityEngine;
using FlyMan.Game;
using UnityEngine.SceneManagement;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorManHasStopped : IPlayerBehavior
    {
        private GameUIControler _gameUIControler;
        private Player _player;
        private ScoreControler _scoreControler;
        private StorageDataGame _storageDataGame;
        private int _scoreRound;
        private int _difficulty;
        private DifficultyControler _difficultyControler;
        private int _score;
        private int _oldTopScore;
        private int _newTopScore;

        public void Enter()
        {
            this.Initialization();
            _scoreRound = _scoreControler.GetRoundScore();
            if (_scoreRound > 0)
            {
                this.SetScore();
                _difficultyControler.UpDifficulty();
                _player.SetBehaviorCarStanding();
            }
            else 
            {
                _gameUIControler.ActivateRoundIsOverWindows();
                _difficultyControler.ResetDifficulty();
                _gameUIControler.SetScoreText(0);
                _scoreControler.ResetScore();
            }
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_gameUIControler.GetMenuButtonOnClick())
            {
                _gameUIControler.DisableRoundIsOverWindows();
                this.BackToMenu();
            }
            if (_gameUIControler.GetRestartButtonOnClick())
            {
                _gameUIControler.DisableRoundIsOverWindows();
                _player.SetBehaviorCarStanding();
            }
            if (_gameUIControler.GetMenuButtonAllTimeIsOnOnClick()) this.BackToMenu();
        }

        private void Initialization()
        {
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _scoreControler = GameObject.FindGameObjectWithTag("ScoreControler").GetComponent<ScoreControler>();
            _storageDataGame = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>();
            _difficultyControler = GameObject.FindGameObjectWithTag("DifficultyControler").GetComponent<DifficultyControler>();
        }

        private void SetScore()
        {
            _difficulty = _difficultyControler.Difficulty;
            _score = _scoreControler.GetScore(_scoreRound, _difficulty);
            _oldTopScore = _storageDataGame.GetTopScore();
            _newTopScore = _scoreControler.GetTopScore(_score, _oldTopScore);
            _storageDataGame.SetTopScore(_newTopScore);
            _gameUIControler.SetTopScoreText(_newTopScore);
            _gameUIControler.SetScoreText(_score);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
