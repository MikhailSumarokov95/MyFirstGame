using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private InputControler _inputControler;
    [SerializeField] private Slider _pushForceValueSlider;
    private bool _theSliderValueCheckIsRunning = true;
    [SerializeField] private Text _scoreText;
    
    private void Update()
    {
        if (_theSliderValueCheckIsRunning) SetPushForceValue();
    }

    private void SetPushForceValue()
    {
        if (_inputControler.PlayerDidPush) _theSliderValueCheckIsRunning = false;
        else _pushForceValueSlider.value = _inputControler.ValueAcceleration/100;
    }

    public void SetScoreText (int scoreRound)
    {
        _scoreText.text = "Score: " + scoreRound;
    }
}
