using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private InputControler _inputControler;
    [SerializeField] private Slider _slider;
    
    private void Update()
    {
        _slider.value = _inputControler.ValueAcceleration/100;
    }
}
