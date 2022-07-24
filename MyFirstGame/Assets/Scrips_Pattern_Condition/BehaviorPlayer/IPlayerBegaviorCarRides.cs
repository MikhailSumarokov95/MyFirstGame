using FlyMan.Game;
using UnityEngine;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarRides : IPlayerBehavior
    {
        private float _speedCarInMomentCrash;
        private CarControler _carControler;
        private ManControler _manControler;
        private Creator _creator;
        private Player _player;
        private bool _manCreated;
        private int _boostSpeedMoveMan = 100;
        private Vector3 _manStartPosition;
        private Vector3 _indetManPosition = new Vector3(0, 1.7f, 1.5f);

        public void Enter()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void Exit()
        {
            _carControler.ResetCrashedValue();
        }

        public void Update()
        {
            if (_carControler.CarCrashedIntoBarrier && !_manCreated) FiringMan();
        }

        private void FiringMan()
        {
            _manStartPosition = _carControler.PositionCarInMomentCrash + _indetManPosition;
            _creator.CreateMan(_manStartPosition);
            _manCreated = true;
            _manControler = GameObject.FindGameObjectWithTag("Man").GetComponent<ManControler>();
            _speedCarInMomentCrash = _carControler.SpeedCarInMomentCrash;
            _manControler.Move(_speedCarInMomentCrash * _boostSpeedMoveMan, Vector3.forward);
            _player.SetBehaviorManFlies();
        }
    }
}
