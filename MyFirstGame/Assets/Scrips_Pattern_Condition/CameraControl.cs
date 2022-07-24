using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game {
    public class CameraControl : MonoBehaviour
    {
        private bool ManIsTarget;
        private Vector3 _distanceOffset = new Vector3(0, 7.5f, -6.7f);
        private GameObject _car;
        private GameObject _man;
        private bool _stopFollow;

        private void LateUpdate()
        {
            if (!_stopFollow) Move();
        }

        public void FollowMan()
        {
            _man = GameObject.FindGameObjectWithTag("Man");
            ManIsTarget = true;
            _stopFollow = false;
        }

        public void FollowCar()
        {
            _car = GameObject.FindGameObjectWithTag("Car");
            ManIsTarget = false;
            _stopFollow = false;
        }

        public void StopFollow()
        {
            _stopFollow = true;
        }

        private void Move()
        {
            if (ManIsTarget)
            {
                this.transform.position = _man.transform.position + _distanceOffset;
            }
            else
            {
                this.transform.position = _car.transform.position + _distanceOffset;
            }
        }  
    }
}
