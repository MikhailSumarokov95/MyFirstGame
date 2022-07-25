using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game
{
    public class Creator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _carPrefabs;
        [SerializeField] private GameObject _manPrefabs;

        public GameObject CreateCar(Vector3 startPosition)
        {
            return Instantiate(_carPrefabs[0], startPosition, _carPrefabs[0].transform.rotation);
        }

        public GameObject CreateMan(Vector3 startPosition)
        { 
            return Instantiate(_manPrefabs, startPosition, _manPrefabs.transform.rotation);
        }
    }
}

