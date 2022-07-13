using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _man;
    [SerializeField] private GameObject _car;
    [SerializeField] private Quaternion _rotationMan = new Quaternion(73f, 0, 0, 0);
    [SerializeField] private Vector3 _positionDeltaCarAndMan = new Vector3 (0, 2f, 3f);
    [SerializeField] public bool PlayerIsMan { get; private set; }
<<<<<<< HEAD
=======
    [SerializeField] public bool PlayerDidPush { get; private set; }
>>>>>>> f5942d726b97b038ae99630c0344099dc5e26114

    
    public void PlayerLeaveFromCar()
    {
<<<<<<< HEAD
        
=======
>>>>>>> f5942d726b97b038ae99630c0344099dc5e26114
        PlayerIsMan = true;
        Instantiate(_man, _car.transform.position + _positionDeltaCarAndMan, _rotationMan);
    }    
}
