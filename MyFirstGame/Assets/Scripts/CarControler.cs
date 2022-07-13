using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
    private Rigidbody _carRb;
    [SerializeField] private StatusPlayer _statusPlayerSP;
    [SerializeField] private GameObject _startingPointBarrier;
    [SerializeField] private GameObject _triggerForRegistrationSpeed;
    public float SpeedCarInMomentCrash { get; private set; }

    private void Start()
    {
        _carRb = this.GetComponent<Rigidbody>();
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
