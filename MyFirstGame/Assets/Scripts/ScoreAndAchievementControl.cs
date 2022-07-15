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
    [SerializeField] float _distanceToTheCenter;
    [SerializeField] int _scoreRound;
    private bool _startedCoroutineGetTheDistanceToTheCenter;
    [SerializeField] private UIControl _uIControl;

    private void Update()
    {
        if (_statusPlayer.PlayerIsMan) GetHitAccuracy();
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
        if (_statusPlayer.RoundIsOver)
        {
            _scoreRound = (int)_distanceToTheCenter;
            _uIControl.SetScoreText(_scoreRound);
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
                _distanceToTheCenter = (_man.transform.position - _target.transform.position).magnitude;
                _startedCoroutineGetTheDistanceToTheCenter = false;
                _statusPlayer.SetRoundIsOver();
                StopCoroutine("GetTheDistanceToTheCenter");
            }
        }
    }
}
