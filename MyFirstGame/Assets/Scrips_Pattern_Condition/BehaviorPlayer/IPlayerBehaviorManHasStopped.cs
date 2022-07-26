using UnityEngine;
using FlyMan.Game;
using UnityEngine.SceneManagement;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorManHasStopped : IPlayerBehavior
    {
        private GameUIControler _gameUIControler;
        private Player _player;
        private Destroyer _destroyer;
        private ScoreControler _scoreControler;
        private StorageDataGame _storageDataGame;
        private int _scoreRound;
        private int _topScore;

        public void Enter()
        {
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _gameUIControler.ActivateRoundIsOverWindows();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _destroyer = GameObject.FindGameObjectWithTag("Destroyer").GetComponent<Destroyer>();
            SetScore();
        }

        public void Exit()
        {
            _destroyer.DestroyMan();
            _destroyer.DestroyCar();
        }

        public void Update()
        {
            if (_gameUIControler.MenuButtonOnClick)
            {
                _gameUIControler.DisableRoundIsOverWindows();
                BackToMenu();
            }
            if (_gameUIControler.RestartButtonOnClick)
            {
                _gameUIControler.DisableRoundIsOverWindows();
                _player.SetBehaviorCarStanding();
            }
        }

        private void SetScore()
        {
            _scoreControler = GameObject.FindGameObjectWithTag("ScoreControler").GetComponent<ScoreControler>();
            _scoreRound = _scoreControler.GetScore();
            _gameUIControler.SetScoreText(_scoreRound);
            _storageDataGame = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>();
            _topScore = _storageDataGame.GetTopScore();
            if (_topScore > _scoreRound)
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
