using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumee : MonoBehaviour
{

    public AudioMixer mixerr;

    public void SetLevel(float sliderValue)

    {
        mixerr.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

}