using System.Collections;
using System.Collections.Generic;
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
        private StorageDataGame _storageDataGame;
        private int _topScore;
        public int GetScore()
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

        public int GetTopScore()
        {
            _topScore = _storageDataGame.GetTopScore();
            return _topScore;
        }

        private bool CheckManIsCreated()
        {
            _man = GameObject.FindGameObjectWithTag("Man");
            return _man != null;
        }
    }
}
