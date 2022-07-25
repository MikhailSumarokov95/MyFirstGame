using FlyMan.Game;
using UnityEngine;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarStanding : IPlayerBehavior
    {
        private Creator _creator;
        private InputControler _inputControler;
        private GameUIControler _gameUIControl;
        private CarControler _carControler;
        private Player _player;
        private int _numberOfTapsOnTheScreen;
        private Vector3 _carStartPosition;
        private CameraControl _cameraControl;
        private GameObject _car;

        public void Enter()
        {
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _car = _creator.CreateCar(_carStartPosition);
            _inputControler = GameObject.FindGameObjectWithTag("InputControler").GetComponent<InputControler>();
            _gameUIControl = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _carControler = _car.GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _cameraControl.FollowGameObject(_car);
        }

        public void Exit()
        {
            _inputControler.ResetValuePush();
            _numberOfTapsOnTheScreen = 0;
        }

        public void Update()
        {
            if (_inputControler.FollowTheTouchOnTheScreen())
            {
                _numberOfTapsOnTheScreen++;
                _inputControler.ChoiceOfValuePushing();
            }
            _gameUIControl.GetValueSliderPushForce(_inputControler.ValuePush);
            if (_numberOfTapsOnTheScreen > 1)
            {
                _carControler.Move(_inputControler.ValuePush);
                _player.SetBehaviorCarRides();
            }
        }
    }
}