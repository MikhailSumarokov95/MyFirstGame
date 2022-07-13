using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControler : MonoBehaviour
{
    [SerializeField] private float _valueAcceleration = 0;
    [SerializeField] private CarControler _car;
    [SerializeField] public bool _playerDidPush { get; private set; }
    private bool _coroutineGetAccelerationIsStarted;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && !_playerDidPush) GivePushPlayer();
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
            _car.Move(_valueAcceleration);
            _valueAcceleration = 0;
            _playerDidPush = true;
        }    
    }

    IEnumerator GetAcceleration()
    {
        _coroutineGetAccelerationIsStarted = true;
        while (true)
        {
            
            yield return new WaitForSeconds(0.01f);
            if (_valueAcceleration < 100) _valueAcceleration++;
            else _valueAcceleration = 0;
            
        }
    }
}
