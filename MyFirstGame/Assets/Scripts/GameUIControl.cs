using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FlyMan.Old
{
    public class GameUIControl : MonoBehaviour
    {
        [SerializeField] private InputControler _inputControler;
        [SerializeField] private Slider _SliderPushForceValue;
        private bool _frezeeSliderPushForceValue;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _topScoreText;
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _menuButton;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _storageTopScore;
        [SerializeField] private int _topScore;

        private void Awake()
        {
            Instantiate(_storageTopScore);
            _topScore = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>().GetTopScore();
            SetTopScoreText(_topScore);
        }
        private void Start()
        {
            _restartButton.GetComponent<Button>().onClick.AddListener(_gameManager.StartRound);
            _menuButton.GetComponent<Button>().onClick.AddListener(BackToMenu);
        }
        private void Update()
        {
            if (!_frezeeSliderPushForceValue) GerValueSliderPushForce();
        }

        private void GerValueSliderPushForce()
        {
            if (_inputControler.PlayerDidPush) _frezeeSliderPushForceValue = true;
            else _SliderPushForceValue.value =  100;
        }

        public void SetScoreText(int scoreRound)
        {
            _scoreText.text = "Score: " + scoreRound;
        }

        public void SetTopScoreText(int topScore)
        {
            _topScoreText.text = "Top Score: " + topScore;
        }

        public void StartRound()
        {
            _frezeeSliderPushForceValue = false;
            SetScoreText(0);
            _SliderPushForceValue.value = 0;
            _restartButton.SetActive(false);
            _menuButton.SetActive(false);

        }

        public void RoundIsOverWindows()
        {
            _restartButton.SetActive(true);
            _menuButton.SetActive(true);
        }
        private void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
