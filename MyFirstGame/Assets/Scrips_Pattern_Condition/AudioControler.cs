using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    AudioSource _delayedAudio;

    private void Start()
    {
        _delayedAudio = GameObject.FindGameObjectWithTag("AudioDelayed").GetComponent<AudioSource>();
    }

    public void PlayDelayedAudio()
    {
        _delayedAudio.Play();
    }
}
