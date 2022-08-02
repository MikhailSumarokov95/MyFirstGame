using FlyMan.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlyMan.Behavior
{
    public class IPlayerBehaviorCarStanding : IPlayerBehavior
    {
        private Creator _creator;
        private InputControler _inputControler;
        private GameUIControler _gameUIControler;
        private CarControler _carControler;
        private Player _player;
        private int _numberOfTapsOnTheScreen;
        private Vector3 _carStartPosition;
        private CameraControl _cameraControl;
        private GameObject _car;
        private StorageDataGame _storageDataGame;
        private Destroyer _destroyer;
        private DifficultyControler _difficultyControler;
        private int _difficulty;

        public void Enter()
        {
            this.Initialization();
            _destroyer.DestroyMan();
            _destroyer.DestroyCar();
            _car = _creator.CreateCar(_carStartPosition);
            _carControler = _car.GetComponent<CarControler>();
            _cameraControl.FollowGameObject(_car);
            _gameUIControler.SetTopScoreText(_storageDataGame.GetTopScore());
            _gameUIControler.ActivateMenuButtonAllTimeIsOnOnClick();
            _difficulty = _difficultyControler.Difficulty;
        }

        public void Exit()
        {
            _inputControler.ResetValuePush();
            _numberOfTapsOnTheScreen = 0;
            _gameUIControler.DisableMenuButtonAllTimeIsOnOnClick();
        }

        public void Update()
        {
            if (_inputControler.FollowTheTouchOnTheScreen())
            {
                _numberOfTapsOnTheScreen++;
                _inputControler.ChoiceOfValuePushing(_difficulty);
            }
            _gameUIControler.GetValueSliderPushForce(_inputControler.ValuePush);
            if (_numberOfTapsOnTheScreen > 1)
            {
                _carControler.Move(_inputControler.ValuePush);
                _player.SetBehaviorCarRides();
            }
            if (_gameUIControler.GetMenuButtonAllTimeIsOnOnClick()) this.BackToMenu();
        }

        private void Initialization ()
        {
            _creator = GameObject.FindGameObjectWithTag("Creator").GetComponent<Creator>();
            _inputControler = GameObject.FindGameObjectWithTag("InputControler").GetComponent<InputControler>();
            _gameUIControler = GameObject.FindGameObjectWithTag("GameUIControler").GetComponent<GameUIControler>();
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _cameraControl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>();
            _storageDataGame = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>();
            _destroyer = GameObject.FindGameObjectWithTag("Destroyer").GetComponent<Destroyer>();
            _difficultyControler = GameObject.FindGameObjectWithTag("DifficultyControler").GetComponent<DifficultyControler>();
            _carStartPosition = new(0, 1, 0);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}