using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _manPrefabs;
    private GameObject _car;
    [SerializeField] private GameObject _carPrefabs;
    [SerializeField] private UIControl _uIControl;
    [SerializeField] private InputControler _inputControler;
    [SerializeField] private ScoreAndAchievementControl _scoreAndAchievementControl;

    [SerializeField] private Quaternion _rotationMan = new Quaternion(73f, 0, 0, 0);
    [SerializeField] private Vector3 _positionDeltaCarAndMan = new Vector3 (0, 2f, 3f);
    [SerializeField] private Vector3 _startsCarPosition = new Vector3(0, 0, 0);
    public bool PlayerIsMan { get; private set; }
    public bool RoundIsOver { get; private set; }

    public void PlayerLeaveFromCar()
    {
        _car = GameObject.FindGameObjectWithTag("Car");
        PlayerIsMan = true;
        Instantiate(_manPrefabs, _car.transform.position + _positionDeltaCarAndMan, _rotationMan);
    }

    public void SetRoundIsOver()
    {
        RoundIsOver = true;
    }

    public void Restart()
    {
        _car = GameObject.FindGameObjectWithTag("Car");
        Destroy(_car);
        Instantiate(_carPrefabs, _startsCarPosition, _carPrefabs.transform.rotation);
        Destroy(GameObject.FindGameObjectWithTag("Man"));
        PlayerIsMan = false;
        RoundIsOver = false;
        _scoreAndAchievementControl.RestartRound();
        _inputControler.RestartRound();
        _uIControl.RestartRound();
    }
}
