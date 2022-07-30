using UnityEngine;

namespace FlyMan.Game
{
    public class ScoreControler : MonoBehaviour
    {
        private GameObject _man;
        private Vector3 _manPosition;
        private GameObject _target;
        private Vector3 _targetPosition;
        private MeshCollider _targetMesh;
        private int _scoreRound;
        private int _totalScore;
        public int GetRoundScore()
        {
            if (CheckManIsCreated())
            {
                _manPosition = _man.transform.position;
                _target = GameObject.FindGameObjectWithTag("Target");
                _targetPosition = _target.transform.position;
                _targetMesh = _target.GetComponent<MeshCollider>();
                _scoreRound = (int)(100 - (200 / _targetMesh.bounds.size.x * Vector3.Distance(_manPosition, _targetPosition)));
                if (_scoreRound < 0) return 0;
                else return _scoreRound;
            }
            else return 0;
        }

        public int GetTopScore(int score, int oldTopScore)
        {
            if (oldTopScore < score) oldTopScore = score;
            return oldTopScore;
        }

        public int GetTotalScore(int scoreRound, int difficultFactor)
        {
            if (scoreRound == 0) return 0; 
            else return _totalScore += scoreRound * difficultFactor;
        }

        public void ResetTotalScore()
        {
            _totalScore = 0;
        }

        private bool CheckManIsCreated()
        {
            _man = GameObject.FindGameObjectWithTag("Man");
            return _man != null;
        }
    }
}
