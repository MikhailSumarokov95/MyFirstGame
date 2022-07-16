using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIControl : MonoBehaviour
{
    [SerializeField] private GameObject _start;
    private void Start()
    {
        _start.GetComponent<Button>().onClick.AddListener(GoToGame);
    }

    private void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
