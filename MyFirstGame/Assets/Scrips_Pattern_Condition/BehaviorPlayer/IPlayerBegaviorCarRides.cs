using FlyMan.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarRides : IPlayerBehavior
    {
        private CarControler _carControler;
        private Player _player;
        private GameUIControler _gameUIControler;
        private ScoreControler _scoreControler;
        private DifficultyControler _difficultyControler;
        private AudioControler _audioControler;

        public void Enter()
        {
            this.Initialization();
            _gameUIControler.ActivateRestartButtonAllTimeIsOn();
            _gameUIControler.ActivateMenuButtonAllTimeIsOnOnClick();
        }

        public void Exit()
        {
            _gameUIControler.DisableRestartButtonAllTimeIsOn();
            _gameUIControler.DisableMenuButtonAllTimeIsOnOnClick();
            _audioControler.PlayDelayedAudio();
        }

        public void Update()
        {
            if (_carControler.CarCrashedIntoBarrier) this.FiringMan();
            if (_carControler.CheckACarsStop()) _player.SetBehaviorManStopped();
            if (_gameUIControler.GetRestartButtonAllTimeIsOn()) this.RestartGame();
            if (_gameUIControler.GetMenuButtonAllTimeIsOnOnClick()) this.BackToMenu();
        }

        private void Initialization()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _scoreControler = GameObject.FindGameObjectWithTag("ScoreControler").GetComponent<ScoreControler>();
            _difficultyControler = GameObject.FindGameObjectWithTag("DifficultyControler").GetComponent<DifficultyControler>();
            _audioControler = GameObject.FindGameObjectWithTag("AudioControler").GetComponent<AudioControler>();
        }

        private void FiringMan()
        {
            _player.SetBehaviorManFlies();
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void RestartGame()
        {
            _scoreControler.ResetScore();
            _gameUIControler.SetScoreText(0);
            _difficultyControler.ResetDifficulty();
            _player.SetBehaviorCarStanding();
        }
    }
}
