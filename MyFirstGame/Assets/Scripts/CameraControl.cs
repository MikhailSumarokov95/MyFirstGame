using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 _distanceOffset = new Vector3(0, 7.5f, -6.7f);
    private GameObject _car;
    [SerializeField] private GameManager _statusPlayer;
    private GameObject _man;

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_statusPlayer.PlayerIsMan)
        {
            _car = GameObject.FindGameObjectWithTag("Car");
            this.transform.position = _car.transform.position + _distanceOffset;
        }
        else
        {
            _man = GameObject.FindGameObjectWithTag("Man");
            this.transform.position = _man.transform.position + _distanceOffset;
        }
    }
}
