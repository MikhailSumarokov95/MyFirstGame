using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private InputControler _inputControler;
    [SerializeField] private Slider _pushForceValueSlider;
    private bool _frezeeSliderPushForceValue;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private StatusPlayer _statusPlayer;
    
    private void Start()
    {
        _restartButton.GetComponent<Button>().onClick.AddListener(_statusPlayer.Restart);
    }
    private void Update()
    {
        if (!_frezeeSliderPushForceValue) SetPushForceValue();
    }

    private void SetPushForceValue()
    {
        if (_inputControler.PlayerDidPush) _frezeeSliderPushForceValue = true;
        else _pushForceValueSlider.value = _inputControler.ValueAcceleration/100;
    }

    public void SetScoreText (int scoreRound)
    {
        _scoreText.text = "Score: " + scoreRound;
    }

    public void RestartRound()
    {
        _frezeeSliderPushForceValue = false;
        SetScoreText(0);
        _pushForceValueSlider.value = 0;
    }
}
