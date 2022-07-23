using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
    public float SpeedCarInMomentCrash { get; private set; }
    public bool CarCrashedIntoBarrier { get; private set; }
    public Vector3 PositionCarInMomentCrash { get; private set; }
    private Rigidbody _carRb;
    //private GameManager _statusPlayerSP;
    private GameObject _startingPointBarrier;
    private GameObject _triggerForRegistrationSpeed;
    


    //public float SpeedCar { get; private set; }


    private void Awake()
    {
    //    _statusPlayerSP = GameObject.FindGameObjectWithTag("StatusPlayer").GetComponent<GameManager>();
        _startingPointBarrier = GameObject.FindGameObjectWithTag("StartingPointBarrier");
        _triggerForRegistrationSpeed = GameObject.FindGameObjectWithTag("TriggerForRegistrationSpeed");
        _carRb = this.GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    SpeedCar = _carRb.velocity.magnitude;
    //    Debug.Log(SpeedCar);
    //}
    public void ResetCrashedValue()
    {
        SpeedCarInMomentCrash = 0;
        CarCrashedIntoBarrier = false;
        PositionCarInMomentCrash = Vector3.zero;
    }

    public void Move(float valuePush)
    {
        _carRb.AddForce(Vector3.forward * valuePush, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _triggerForRegistrationSpeed.name)
            SpeedCarInMomentCrash = _carRb.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == _startingPointBarrier.name)
        {
            PositionCarInMomentCrash = this.transform.position;
            CarCrashedIntoBarrier = true;
        }
    }
}
