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
        private float difficulteFactor = 0.001f;

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
            float speedAcceleration = difficulty * difficulteFactor;
            if (!_coroutineGetAccelerationIsStarted) StartCoroutine(GetAcceleration(speedAcceleration));
            else
            {
                StopAllCoroutines();
                _coroutineGetAccelerationIsStarted = false; 
            }
        }

        public void ResetValuePush()
        {
            ValuePush = 0;
        }

        IEnumerator GetAcceleration(float speedAcceleration)
        {
            _coroutineGetAccelerationIsStarted = true;
            while (true)
            {
                yield return new WaitForSeconds(speedAcceleration);
                if (ValuePush < 100) ValuePush++;
                else ValuePush = 0;
            }
        }
    }
}
