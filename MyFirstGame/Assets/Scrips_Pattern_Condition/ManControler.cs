using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManControler : MonoBehaviour
{
    private Rigidbody _manRb;

    private void Awake()
    {
        _manRb = this.GetComponent<Rigidbody>();
    }
    public void Move(float forsePush, Vector3 directionPush)
    {
        _manRb.AddForce(directionPush * forsePush, ForceMode.Impulse);
    }

    public bool CheckAMansStop()
    {
        return _manRb.velocity.magnitude < 0.01;
    }
}
