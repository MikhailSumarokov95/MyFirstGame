using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FlyMan.Old
{
    public class MenuUIControl : MonoBehaviour
    {
        [SerializeField] private GameObject _start;
        [SerializeField] private Text _topScoreText;
        [SerializeField] private GameObject _storageTopScore;
        private int _topScore;
        private void Awake()
        {
            Instantiate(_storageTopScore);
            _topScore = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>().GetTopScore();
            SetTopScoreText(_topScore);
        }

        private void Start()
        {
            _start.GetComponent<Button>().onClick.AddListener(GoToGame);
        }

        private void GoToGame()
        {
            SceneManager.LoadScene(1);
        }

        private void SetTopScoreText(int topScore)
        {
            _topScoreText.text = "Top Score: " + topScore;
        }
    }
}
