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
        private int _difficulty;
        private DifficultyControler _difficultyControler;
        private int _finalRoundScore;

        public void Enter()
        {
            Initialization();
            SetScore();
            if (_scoreRound > 0) _player.SetBehaviorCarStanding();
            else 
            {
                _gameUIControler.ActivateRoundIsOverWindows();
                _difficultyControler.DefinitionDifficulty(_scoreRound);
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
            //_finalRoundScore = (_scoreRound, )
            //_gameUIControler.SetScoreText(_difficulty);
            //_topScore = _storageDataGame.GetTopScore();
            //_topScore = _scoreControler.GetTopScore(_difficulty);
            //_gameUIControler.SetTopScoreText(_topScore);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
