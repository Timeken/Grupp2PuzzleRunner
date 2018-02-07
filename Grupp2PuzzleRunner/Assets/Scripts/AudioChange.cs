using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void OnValueChange()
    {
        volumeAudio.volume = volumeSlider.value;

    }
}
