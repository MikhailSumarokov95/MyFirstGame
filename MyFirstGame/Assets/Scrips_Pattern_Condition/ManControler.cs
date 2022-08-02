using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ManControler : MonoBehaviour
{
    private Rigidbody _manRb;
    private bool _delayed;

    private void Awake()
    {
        _manRb = this.GetComponent<Rigidbody>();
    }
    public void Move(float forsePush, Vector3 directionPush)
    {
        _manRb.AddForce(directionPush * forsePush, ForceMode.Impulse);
        StartCoroutine(DelayTimeOfAwake());
    }

    public bool CheckAMansStop()
    {
        if (_delayed) return _manRb.velocity.magnitude < 0.01;
        else return false;
    }

    private IEnumerator DelayTimeOfAwake()
    {
        yield return new WaitForSeconds(1);
        _delayed = true;
    }
}

