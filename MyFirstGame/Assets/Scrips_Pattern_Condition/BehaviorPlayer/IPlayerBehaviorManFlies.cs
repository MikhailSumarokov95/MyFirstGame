﻿using UnityEngine;
using FlyMan.Game;
using UnityEngine.SceneManagement;

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
        private GameUIControler _gameUIControler;

        public void Enter()
        {
            this.Initialization();
            _man = _creator.CreateMan(_carControler.PositionCarInMomentCrash + _indetManPosition);
            _cameraControl.FollowGameObject(_man);
            _manControler = _man.GetComponent<ManControler>();
            _manControler.Move(_carControler.SpeedCarInMomentCrash * _boostSpeedMoveMan, Vector3.forward);
            _carControler.ResetCrashedValue();
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
            if (_manControler.CheckAMansStop())
                _player.SetBehaviorManStopped();
            if (_gameUIControler.GetRestartButtonAllTimeIsOn()) _player.SetBehaviorCarStanding();
            if (_gameUIControler.GetMenuButtonAllTimeIsOnOnClick()) this.BackToMenu(); 
        }

        private void Initialization()
        {
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
