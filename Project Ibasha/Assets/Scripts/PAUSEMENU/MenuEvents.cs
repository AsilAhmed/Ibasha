﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }
    public void setVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
