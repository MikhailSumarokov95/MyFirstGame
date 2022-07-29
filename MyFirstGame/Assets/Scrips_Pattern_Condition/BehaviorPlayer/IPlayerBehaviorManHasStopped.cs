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
        private int _topScore;

        public void Enter()
        {
            Initialization();
            _gameUIControler.ActivateRoundIsOverWindows();
            SetScore();
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
        }
        // перенести логику топ скор  и гет скор в скор контролер
        // реализовать дификалтсонтролер
        private void SetScore()
        {
            _scoreRound = _scoreControler.GetScore();
            _gameUIControler.SetScoreText(_scoreRound);
            _topScore = _scoreControler.GetTopScore();
            if (_topScore < _scoreRound)
            {
                _topScore = _scoreRound;
                _storageDataGame.SetTopScore(_topScore);
            }
            _gameUIControler.SetTopScoreText(_topScore);

        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
