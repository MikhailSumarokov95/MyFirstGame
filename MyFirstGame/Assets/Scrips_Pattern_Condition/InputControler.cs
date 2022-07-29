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

        public void ChoiceOfValuePushing(float difficulty)
        {
            if (!_coroutineGetAccelerationIsStarted) StartCoroutine(GetAcceleration(difficulty));
            else
            {
                StopCoroutine(GetAcceleration(difficulty));
                _coroutineGetAccelerationIsStarted = false; 
            }
        }

        public void ResetValuePush()
        {
            ValuePush = 0;
        }

        IEnumerator GetAcceleration(float difficulty)
        {
            _coroutineGetAccelerationIsStarted = true;
            while (true)
            {
                yield return new WaitForSeconds(difficulty);
                if (ValuePush < 100) ValuePush++;
                else ValuePush = 0;
            }
        }
    }
}
