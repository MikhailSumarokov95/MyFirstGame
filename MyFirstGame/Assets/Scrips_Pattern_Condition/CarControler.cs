using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarControler : MonoBehaviour
{
    public float SpeedCarInMomentCrash { get; private set; }
    public bool CarCrashedIntoBarrier { get; private set; }
    public Vector3 PositionCarInMomentCrash { get; private set; }
    private Rigidbody _carRb;
    private GameObject _startingPointBarrier;
    private GameObject _triggerForRegistrationSpeed;
    private bool _delayed;

    private void Awake()
    {
        _startingPointBarrier = GameObject.FindGameObjectWithTag("StartingPointBarrier");
        _triggerForRegistrationSpeed = GameObject.FindGameObjectWithTag("TriggerForRegistrationSpeed");
        _carRb = this.GetComponent<Rigidbody>();
    }

    public void ResetCrashedValue()
    {
        SpeedCarInMomentCrash = 0;
        CarCrashedIntoBarrier = false;
        PositionCarInMomentCrash = Vector3.zero;
    }

    public void Move(float valuePush)
    {
        _carRb.AddForce(Vector3.forward * valuePush, ForceMode.Impulse);
        StartCoroutine(DelayTimeOfAwake());
    }

    public bool CheckACarsStop()
    {
        if (_delayed) return _carRb.velocity.magnitude < 0.01;
        else return false;
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

    private IEnumerator DelayTimeOfAwake()
    {
        yield return new WaitForSeconds(1);
        _delayed = true;
    }
}
