using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Old
{
    public class ScoreAndAchievementControl : MonoBehaviour
    {
        private GameObject _man;
        private Rigidbody _manRb;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _distanceToTheCenter;
        [SerializeField] private int _scoreRound;
        private bool _startedCoroutineGetTheDistanceToTheCenter;
        [SerializeField] private GameUIControl _gameUIControl;
        private StorageDataGame _storageDataGame;
        private CarControler _carControler;
        [SerializeField] private InputControler _inputControler;


        private void Update()
        {
            Debug.Log("PlayerIsMan " + _gameManager.PlayerIsMan);
            Debug.Log("PlayerDidPush " + _inputControler.PlayerDidPush);
            Debug.Log("RoundIsOver " + _gameManager.RoundIsOver);
            Debug.Log("SpeedCar " + _carControler.SpeedCar);
            if (_gameManager.RoundIsOver && _gameManager.PlayerIsMan)
            {
                Debug.Log("GetSCore");
                GetScore();
                _gameUIControl.SetScoreText(_scoreRound);
                SetTopScore();
            }
            else if (_gameManager.PlayerIsMan)
            {
                GetHitAccuracy();
                Debug.Log("GetHitAccuracy");
            }
            else if (!_gameManager.PlayerIsMan && _inputControler.PlayerDidPush
                && _carControler.SpeedCar > 0.01 && _carControler.SpeedCar < 2)
            {
                _gameManager.SetRoundIsOver();
                Debug.Log("RoundIsOver");
            }
        }

        private void GetHitAccuracy()
        {
            if (_manRb == null)
            {
                _man = GameObject.FindGameObjectWithTag("Man");
                _manRb = _man.GetComponent<Rigidbody>();
            }
            if (!_startedCoroutineGetTheDistanceToTheCenter)
            {
                StartCoroutine("GetTheDistanceToTheCenter");
            }
        }

        IEnumerator GetTheDistanceToTheCenter()
        {
            _startedCoroutineGetTheDistanceToTheCenter = true;
            while (true)
            {
                yield return new WaitForSeconds(1);
                if (_manRb.velocity.magnitude < 0.1)
                {
                    _distanceToTheCenter = Vector3.Distance(_target.transform.position, _man.transform.position);
                    _startedCoroutineGetTheDistanceToTheCenter = false;
                    _gameManager.SetRoundIsOver();
                    StopCoroutine("GetTheDistanceToTheCenter");
                }
            }
        }
        private void GetScore()
        {
            _scoreRound++;
            //if (_distanceToTheCenter > _target.GetComponent<MeshFilter>().sharedMesh.bounds.size.z)
            //    _scoreRound = 0;
            //else _scoreRound = (int)(_target.GetComponent<MeshFilter>().sharedMesh.bounds.size.z
            //        - _distanceToTheCenter);
        }

        private void SetTopScore()
        {
            if (_storageDataGame == null)
                _storageDataGame = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>();
            if (_scoreRound > _storageDataGame.GetTopScore())
            {
                _gameUIControl.SetTopScoreText(_scoreRound);
                _storageDataGame.SetTopScore(_scoreRound);
            }
        }

        public void StartRound()
        {
            _scoreRound = 0;
            StopAllCoroutines();
            _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
        }
    }
}
