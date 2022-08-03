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
        private int _totalScore;
        private int _oldTopScore;

        public void Enter()
        {
            this.Initialization();
            this.SetScore();
            if (_scoreRound > 0)
            {
                _difficultyControler.UpDifficulty();
                _player.SetBehaviorCarStanding();
            }
            else 
            {
                _gameUIControler.ActivateRoundIsOverWindows();
                _difficultyControler.ResetDifficulty();
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
            _scoreRound = _scoreControler.GetRoundScore();
            _difficulty = _difficultyControler.Difficulty;
            _totalScore = _scoreControler.GetTotalScore(_scoreRound, _difficulty);
            _oldTopScore = _storageDataGame.GetTopScore();
            if (_oldTopScore < _totalScore)
            {
                _storageDataGame.SetTopScore(_totalScore);
                _gameUIControler.SetTopScoreText(_totalScore);
            }
            _gameUIControler.SetScoreText(_totalScore);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
