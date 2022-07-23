using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game
{
    public class Creator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _carPrefabs;
        [SerializeField] private Vector3 _startsCarPosition = new Vector3(0, 0, 0);

        public void CreateCar()
        {
            Instantiate(_carPrefabs[0], _startsCarPosition, _carPrefabs[0].transform.rotation);
        }
    }
}

