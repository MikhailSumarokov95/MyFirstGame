using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndAchievementControl : MonoBehaviour
{
    private GameObject _man;
    private Rigidbody _manRb;
    [SerializeField] private StatusPlayer _statusPlayer;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _distanceToTheCenter;
    [SerializeField] private int _scoreRound;
    private bool _startedCoroutineGetTheDistanceToTheCenter;
    [SerializeField] private GameUIControl _gameUIControl;
    private StorageDataGame _storageDataGame;
    private CarControler _carControler;

    private void Update()
    {
        if (_statusPlayer.RoundIsOver)
        {
            GetScore();
            _gameUIControl.SetScoreText(_scoreRound);
            if (_storageDataGame == null)
                _storageDataGame = GameObject.FindGameObjectWithTag("StorageDataGame").GetComponent<StorageDataGame>();
            if (_scoreRound > _storageDataGame.GetTopScore())
            {
                _gameUIControl.SetTopScoreText(_scoreRound);
                _storageDataGame.SetTopScore(_scoreRound);
            }
        }
        else if (_statusPlayer.PlayerIsMan) GetHitAccuracy();
        else if (!_statusPlayer.PlayerIsMan && _carControler.SpeedCar == 0)
            _statusPlayer.SetRoundIsOver();
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
                _statusPlayer.SetRoundIsOver();
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

    public void StartRound()
    {
        _scoreRound = 0;
        StopAllCoroutines();
        _carControler = GameObject.FindGameObjectWithTag("Car").GetComponent<CarControler>();
    }
}
