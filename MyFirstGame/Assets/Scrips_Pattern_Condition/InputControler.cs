using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlyMan.Behavior;

namespace FlyMan.Game
{
    public class InputControler : MonoBehaviour
    {
        public float ValuePush { get; private set; }
        private bool _coroutineGetAccelerationIsStarted;
        private float difficulteFactor = 2f;
        private float _speedAcceleration;

        public bool FollowTheTouchOnTheScreen()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }
#else
            if (Input.touchCount > 0) return true;
#endif
            return false;
        }

        public void ChoiceOfValuePushing(int difficulty)
        {
            _speedAcceleration = difficulty * difficulteFactor;
            if (!_coroutineGetAccelerationIsStarted) StartCoroutine("GetAcceleration");
            else
            {
                StopCoroutine("GetAcceleration");
                _coroutineGetAccelerationIsStarted = false; 
            }
        }

        public void ResetValuePush()
        {
            ValuePush = 0;
        }

        IEnumerator GetAcceleration()
        {
            _coroutineGetAccelerationIsStarted = true;
            while (true)
            {
                yield return null;
                if (ValuePush < 100) ValuePush += _speedAcceleration;
                else ValuePush = 0;
            }
        }
    }
}
