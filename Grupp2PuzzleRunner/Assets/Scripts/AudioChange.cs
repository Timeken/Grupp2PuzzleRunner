using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource Sound;
    public void OnValueChange()
    {
        Sound.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
