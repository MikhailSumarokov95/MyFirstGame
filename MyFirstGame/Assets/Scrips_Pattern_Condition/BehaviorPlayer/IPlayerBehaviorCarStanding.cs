﻿using FlyMan.Game;
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
        public void Enter()
        {
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _creator.CreateCar(_carStartPosition);
            _inputControler = GameObject.FindGameObjectWithTag("InputControler").GetComponent<InputControler>();
            _gameUIControl = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _cameraControl.ManIsCreated = false;
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