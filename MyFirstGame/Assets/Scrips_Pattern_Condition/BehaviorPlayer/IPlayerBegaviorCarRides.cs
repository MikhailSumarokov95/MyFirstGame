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
        }

        public void Update()
        {
            if (_carControler.CarCrashedIntoBarrier) this.FiringMan();
            if (_carControler.CheckACarsStop()) _player.SetBehaviorManStopped();
            if (_gameUIControler.GetRestartButtonAllTimeIsOn()) _player.SetBehaviorCarStanding();
            if (_gameUIControler.GetMenuButtonAllTimeIsOnOnClick()) this.BackToMenu();
        }

        private void Initialization()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
        }

        private void FiringMan()
        {
            _player.SetBehaviorManFlies();
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
