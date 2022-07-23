using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game {
    public class CameraControl : MonoBehaviour
    {
        public bool ManIsCreated;
        public Vector3 _positionGamers;
        private Vector3 _distanceOffset = new Vector3(0, 7.5f, -6.7f);
        private GameObject _car;
        private GameObject _man;


        private void LateUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (!ManIsCreated)
            {
                _car = GameObject.FindGameObjectWithTag("Car");
                this.transform.position = _car.transform.position + _distanceOffset;
            }
            else
            {
                _man = GameObject.FindGameObjectWithTag("Man");
                this.transform.position = _man.transform.position + _distanceOffset;
            }
        }
    }
}
