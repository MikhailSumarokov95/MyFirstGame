using FlyMan.Game;
using UnityEngine;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarRides : IPlayerBehavior
    {
        private CarControler _carControler;
        private Player _player;

        public void Enter()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_carControler.CarCrashedIntoBarrier) FiringMan();
            if (_carControler.CheckACarsStop()) _player.SetBehaviorManStopped();
        }

        private void FiringMan()
        {
            _player.SetBehaviorManFlies();
        }
    }
}
