using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game {
    public class CameraControl : MonoBehaviour
    {
        private Vector3 _distanceOffset = new Vector3(0, 7.5f, -6.7f);
        private GameObject _folloverTarget;

        private void LateUpdate()
        {
            Move();
        }

        public void FollowGameObject(GameObject folloverTarget)
        {
            _folloverTarget = folloverTarget;
        }

        private void Move()
        {
            this.transform.position = _folloverTarget.transform.position + _distanceOffset;
        }  
    }
}
