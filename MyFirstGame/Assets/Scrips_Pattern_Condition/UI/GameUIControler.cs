using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
        [SerializeField] private GameObject _menuButtonAllTimeIsOn;
        public bool RestartButtonOnClick { get; private set; }
        public bool MenuButtonOnClick { get; private set; }
        public bool RestartButtonAllTimeIsOnOnClick { get; private set; }
        public bool MenuButtonAllTimeIsOnOnClick { get; private set; }

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
            _restartButton.GetComponent<Button>().onClick.AddListener(delegate { RestartButtonOnClick = true; } );
            _menuButton.GetComponent<Button>().onClick.AddListener(delegate { MenuButtonOnClick = true; } );
        }

        public void DisableRoundIsOverWindows()
        {
            _restartButton.SetActive(false);
            _menuButton.SetActive(false);
        }

        public bool GetRestartButtonOnClick()
        {
            if (RestartButtonOnClick)
            {
                RestartButtonOnClick = false;
                return true;
            }
            else return false;
        }

        public bool GetMenuButtonOnClick()
        {
            if (MenuButtonOnClick)
            {
                MenuButtonOnClick = false;
                return true;
            }
            else return false;
        }

        public void ActivateRestartButtonAllTimeIsOn()
        {
            _restartButtonAllTimeIsOn.SetActive(true);
            _restartButtonAllTimeIsOn.GetComponent<Button>().onClick.AddListener(delegate { RestartButtonAllTimeIsOnOnClick = true; } );
        }

        public void DisableRestartButtonAllTimeIsOn()
        {
            _restartButtonAllTimeIsOn.SetActive(false);
        }

        public bool GetRestartButtonAllTimeIsOn()
        {
            if (RestartButtonAllTimeIsOnOnClick)
            {
                RestartButtonAllTimeIsOnOnClick = false;
                return true;
            }
            else return false;
        }

        public void ActivateMenuButtonAllTimeIsOnOnClick()
        {
            _menuButtonAllTimeIsOn.SetActive(true);
            _menuButtonAllTimeIsOn.GetComponent<Button>().onClick.AddListener(delegate { MenuButtonAllTimeIsOnOnClick = true; });
        }

        public void DisableMenuButtonAllTimeIsOnOnClick()
        {
            _menuButtonAllTimeIsOn.SetActive(false);
        }

        public bool GetMenuButtonAllTimeIsOnOnClick()
        {
            if (MenuButtonAllTimeIsOnOnClick)
            {
                MenuButtonAllTimeIsOnOnClick = false;
                return true;
            }
            else return false;
        }
    }
}
