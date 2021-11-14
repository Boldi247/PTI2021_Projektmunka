using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource buttonAudios;
    public AudioClip buttonHover;
    public AudioClip buttonClick;

    public void PlayHoverSound(){
        buttonAudios.PlayOneShot(buttonHover);
    }

    public void PlayClickSound(){
        buttonAudios.PlayOneShot(buttonClick);
    }
}
