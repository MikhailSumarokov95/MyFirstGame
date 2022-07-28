using UnityEngine;
using FlyMan.Game;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorManFlies : IPlayerBehavior
    {
        private CameraControl _cameraControl;
        private Player _player;
        private Vector3 _indetManPosition = new Vector3(0, 1.7f, 1.5f);
        private Creator _creator;
        private CarControler _carControler;
        private GameObject _man;
        private int _boostSpeedMoveMan = 100;
        private ManControler _manControler;
        private GameUIControler _gameUIControl;

        public void Enter()
        {
            this.Initialization();
            _man = _creator.CreateMan(_carControler.PositionCarInMomentCrash + _indetManPosition);
            _cameraControl.FollowGameObject(_man);
            _manControler = _man.GetComponent<ManControler>();
            _manControler.Move(_carControler.SpeedCarInMomentCrash * _boostSpeedMoveMan, Vector3.forward);
            _carControler.ResetCrashedValue();
    }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_manControler.CheckAMansStop())
                _player.SetBehaviorManStopped();
            if (_gameUIControl.GetRestartButtonAllTimeIsOn()) _player.SetBehaviorCarStanding();
        }

        private void Initialization()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameUIControl = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
        }
    }
}
