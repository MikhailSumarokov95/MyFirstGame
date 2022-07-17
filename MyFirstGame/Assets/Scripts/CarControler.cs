using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
    private Rigidbody _carRb;
    private StatusPlayer _statusPlayerSP;
    private GameObject _startingPointBarrier;
    private GameObject _triggerForRegistrationSpeed;
    public float SpeedCarInMomentCrash { get; private set; }
    public float SpeedCar { get; private set; }

    private void Awake()
    {
        _statusPlayerSP = GameObject.FindGameObjectWithTag("StatusPlayer").GetComponent<StatusPlayer>();
        _startingPointBarrier = GameObject.FindGameObjectWithTag("StartingPointBarrier");
        _triggerForRegistrationSpeed = GameObject.FindGameObjectWithTag("TriggerForRegistrationSpeed");
        _carRb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SpeedCar = _carRb.velocity.magnitude;
    }

    public void Move(float valueAcceleration)
    {
        _carRb.AddForce(Vector3.forward * valueAcceleration, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _triggerForRegistrationSpeed.name) 
            SpeedCarInMomentCrash = _carRb.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == _startingPointBarrier.name &&
            GameObject.FindGameObjectsWithTag("Man").Length < 1)
            _statusPlayerSP.PlayerLeaveFromCar();
    }
}
