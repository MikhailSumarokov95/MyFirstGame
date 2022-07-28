using FlyMan.Game;
using UnityEngine;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarRides : IPlayerBehavior
    {
        private CarControler _carControler;
        private Player _player;
        private GameUIControler _gameUIControl;

        public void Enter()
        {
            this.Initialization();
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_carControler.CarCrashedIntoBarrier) FiringMan();
            if (_carControler.CheckACarsStop()) _player.SetBehaviorManStopped();
            if (_gameUIControl.GetRestartButtonAllTimeIsOn()) _player.SetBehaviorCarStanding();
        }

        private void Initialization()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameUIControl = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
        }

        private void FiringMan()
        {
            _player.SetBehaviorManFlies();
        }
    }
}
