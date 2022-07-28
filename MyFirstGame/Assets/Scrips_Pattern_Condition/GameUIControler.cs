using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlyMan.Game
{
    public class GameUIControler : MonoBehaviour
    {
        [SerializeField] private Slider _sliderPushForceValue;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _topScoreText;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameObject _restartButtonAllTimeIsOn;
        private bool _restartButtonOnClick;
        private bool _menuButtonOnClick;
        private bool _restartButtonAllTimeIsOnOnClick;

        public void GetValueSliderPushForce(float value)
        {
            _sliderPushForceValue.value = value / 100;
        }

        public void SetScoreText(int scoreRound)
        {
            _scoreText.text = "Score: " + scoreRound;
        }

        public void SetTopScoreText(int topScore)
        {
            _topScoreText.text = "Top Score: " + topScore;
        }

        public void ActivateRoundIsOverWindows()
        {
            _restartButton.SetActive(true);
            _menuButton.SetActive(true);
            _restartButton.GetComponent<Button>().onClick.AddListener(SetOnRestartButtonOnClick);
            _menuButton.GetComponent<Button>().onClick.AddListener(SetOnMenuButtonOnClick);
            _restartButtonAllTimeIsOn.GetComponent<Button>().onClick.AddListener(SetOnRestartButtonAllTimeIsOn);
        }

        public void DisableRoundIsOverWindows()
        {
            _restartButton.SetActive(false);
            _menuButton.SetActive(false);
        }

        public bool GetRestartButtonOnClick()
        {
            if (_restartButtonOnClick)
            {
                _restartButtonOnClick = false;
                return true;
            }
            else return false;
        }

        public bool GetMenuButtonOnClick()
        {
            if (_menuButtonOnClick)
            {
                _menuButtonOnClick = false;
                return true;
            }
            else return false;
        }
        
        public bool GetRestartButtonAllTimeIsOn()
        {
            if (_restartButtonAllTimeIsOnOnClick)
            {
                _restartButtonAllTimeIsOnOnClick = false;
                return true;
            }
            else return false;
        }

        private void SetOnRestartButtonOnClick()
        {
            _restartButtonOnClick = true;
        }
        private void SetOnMenuButtonOnClick()
        {
            _menuButtonOnClick = true;
        }

        private void SetOnRestartButtonAllTimeIsOn()
        {
            _restartButtonAllTimeIsOnOnClick = true;
        }
    }
}
