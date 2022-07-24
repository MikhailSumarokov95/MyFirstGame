using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyMan.Game
{
    public class Creator : MonoBehaviour
    {
        [SerializeField] private GameObject[] _carPrefabs;
        [SerializeField] private GameObject _manPrefabs;


        public void CreateCar(Vector3 startPosition)
        {
            Instantiate(_carPrefabs[0], startPosition, _carPrefabs[0].transform.rotation);
        }

        public void CreateMan(Vector3 startPosition)
        { 
            Instantiate(_manPrefabs, startPosition, _manPrefabs.transform.rotation);
        }
    }
}

