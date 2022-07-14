using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAndAchievementControl : MonoBehaviour
{
    [SerializeField] private GameObject _man;
    private Rigidbody _manRb;
    [SerializeField] private StatusPlayer _statusPlayer;
    [SerializeField] private GameObject _target;
    [SerializeField] float _distanceToTheCenter;

    private void Start()
    {
        
    }

    //private void Update()
    //{
    //    if (_statusPlayer.PlayerIsMan)
    //    {
    //        _manRb = _man.GetComponent<Rigidbody>();
    //        StartCoroutine("GetHitAccuracy");
    //    }
    //}

    //IEnumerator GetHitAccuracy()
    //{
    //    while (true)
    //    {

    //        if (_manRb.velocity.magnitude == 0)
    //        {
    //            _distanceToTheCenter = (_man.transform.position - _target.transform.position).magnitude;
    //        }
    //    }
    //}
}
