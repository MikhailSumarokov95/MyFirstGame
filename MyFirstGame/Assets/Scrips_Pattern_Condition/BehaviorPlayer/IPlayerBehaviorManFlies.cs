using UnityEngine;
using FlyMan.Game;

namespace FlyMan.Behavior

{
    public class IPlayerBehaviorManFlies : IPlayerBehavior
    {
        private CameraControl _cameraControl;
        private ManControler _manControler;
        private Player _player;

        public void Enter()
        {
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _cameraControl.FollowMan();
            _manControler = GameObject.FindGameObjectWithTag("Man").GetComponent<ManControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        public void Exit()
        {

        }

        public void Update()
        {
            if (_manControler.CheckAMansStop())
                _player.SetBehaviorManStopped();
        }
    }
}
