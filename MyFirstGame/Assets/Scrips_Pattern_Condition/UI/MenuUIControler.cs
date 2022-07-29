using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FlyMan.Game
{
    public class MenuUIControler : MonoBehaviour
    {
        [SerializeField] private GameObject _start;
        [SerializeField] private Text _topScoreText;
        private int _topScore;

        private void Start()
        {
            _topScore = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>().GetTopScore();
            SetTopScoreText(_topScore);
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