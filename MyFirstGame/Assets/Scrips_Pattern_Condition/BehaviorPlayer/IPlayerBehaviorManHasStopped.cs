using UnityEngine;
using FlyMan.Game;
using UnityEngine.SceneManagement;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorManHasStopped : IPlayerBehavior
    {
        private GameUIControler _gameUIControler;
        private Player _player;
        private Destroyer _destroyer;
        private CameraControl _cameraControl;

        public void Enter()
        {
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _gameUIControler.ActivateRoundIsOverWindows();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _destroyer = GameObject.FindGameObjectWithTag("Destroyer").GetComponent<Destroyer>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
        }

        public void Exit()
        {
            _cameraControl.StopFollow();
            _destroyer.DestroyMan();
            _destroyer.DestroyCar();
        }

        public void Update()
        {
            if (_gameUIControler.MenuButtonOnClick) BackToMenu();
            if (_gameUIControler.RestartButtonOnClick) _player.SetBehaviorCarStanding();
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
