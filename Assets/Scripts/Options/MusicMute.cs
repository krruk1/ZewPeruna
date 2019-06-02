using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMute : MonoBehaviour
{

    public void ToggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}