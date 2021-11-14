using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioPlayer : MonoBehaviour
{
    public AudioSource audios;
    public AudioClip hover;
    public AudioClip click;

    public void PlayHover(){
        audios.PlayOneShot(hover);
    }

    public void PlayClick(){
        audios.PlayOneShot(click);
    }
}
