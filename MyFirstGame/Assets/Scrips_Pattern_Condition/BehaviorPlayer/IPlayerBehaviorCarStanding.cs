using FlyMan.Game;
using UnityEngine;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarStanding : IPlayerBehavior
    {
        private Creator _creator;
        private InputControler _inputControler;
        private GameUIControler _gameUIControl;
        private CarControler _car;
        private Player _player;
        private int _numberOfTapsOnTheScreen;
        public void Enter()
        {
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _creator.CreateCar();
            _inputControler = GameObject.FindGameObjectWithTag("InputControler").GetComponent<InputControler>();
            _gameUIControl = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _car = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
                _car.Move(_inputControler.ValuePush);
                _player.SetBehaviorCarRides();
            }
        }
    }
}