using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _man;
    [SerializeField] private GameObject _car;
    [SerializeField] private Quaternion _rotationMan = new Quaternion(73f, 0, 0, 0);
    [SerializeField] private Vector3 _positionDeltaCarAndMan = new Vector3 (0, 2f, 3f);
    public bool PlayerIsMan { get; private set; }

    public void PlayerLeaveFromCar()
    {
        PlayerIsMan = true;
        Instantiate(_man, _car.transform.position + _positionDeltaCarAndMan, _rotationMan);
    }    
}
