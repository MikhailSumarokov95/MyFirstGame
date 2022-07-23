using UnityEngine;
using FlyMan.Game;

namespace FlyMan.Behavior

{
    public class IPlayerBehaviorManFlies : IPlayerBehavior
    {
        private CameraControl _cameraControl;
        public void Enter()
        {
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _cameraControl.ManIsCreated = true;
        }

        public void Exit()
        {

        }

        public void Update()
        {

        }
    }
}
