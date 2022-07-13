using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManControler : MonoBehaviour
{
    private Rigidbody _manRb;
    private CarControler _carControler;
    [SerializeField] private int _boost = 100;

    private void Awake()
    {
        Move();
    }
    public void Move()
    {
        _manRb = this.GetComponent<Rigidbody>();
        _carControler = GameObject.Find("Car").GetComponent<CarControler>();
        _manRb.AddForce(Vector3.forward * _carControler.SpeedCarInMomentCrash * _boost, ForceMode.Impulse);
    }
}
