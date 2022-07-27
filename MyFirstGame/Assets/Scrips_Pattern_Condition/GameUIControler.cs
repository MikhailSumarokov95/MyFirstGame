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
        public bool RestartButtonOnClick { get; private set; }
        public bool MenuButtonOnClick { get; private set; }

        //private void Awake()
        //{
        //    Instantiate(_storageTopScore);
        //    _topScore = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>().GetTopScore();
        //    SetTopScoreText(_topScore);
        //}

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
            Debug.Log(topScore + " UI");
            _topScoreText.text = "Top Score: " + topScore;
        }

        public void ActivateRoundIsOverWindows()
        {
            _restartButton.SetActive(true);
            _menuButton.SetActive(true);
            _restartButton.GetComponent<Button>().onClick.AddListener(SetRestartButtonOnClick);
            _menuButton.GetComponent<Button>().onClick.AddListener(SetMenuButtonOnClick);
        }

        public void DisableRoundIsOverWindows()
        {
            RestartButtonOnClick = false;
            MenuButtonOnClick = false;
            _restartButton.SetActive(false);
            _menuButton.SetActive(false);
        }

        private void SetRestartButtonOnClick()
        {
            RestartButtonOnClick = true;
        }
        private void SetMenuButtonOnClick()
        {
            MenuButtonOnClick = true;
        }
    }
}
