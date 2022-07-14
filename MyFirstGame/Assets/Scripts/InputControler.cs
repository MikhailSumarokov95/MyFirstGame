using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControler : MonoBehaviour
{
    public float ValueAcceleration { get; private set; }
    [SerializeField] private CarControler _car;
    public bool PlayerDidPush { get; private set; }
    private bool _coroutineGetAccelerationIsStarted;
    private Slider _slider;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && !PlayerDidPush) GivePushPlayer();
#else   
        if (Input.touchCount > 0 &&
            !_playerDidPush) GivePushPlayer();
#endif
    }

    private void GivePushPlayer()
    {
        if (!_coroutineGetAccelerationIsStarted) StartCoroutine("GetAcceleration");
        else
        {
            StopCoroutine("GetAcceleration");
            _coroutineGetAccelerationIsStarted = false;
            _car.Move(ValueAcceleration);

            ValueAcceleration = 0;
            PlayerDidPush = true;
        }    
    }

    IEnumerator GetAcceleration()
    {
        _coroutineGetAccelerationIsStarted = true;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (ValueAcceleration < 100) ValueAcceleration++;
            else ValueAcceleration = 0; 
        }
    }
}
