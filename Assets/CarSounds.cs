using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 0.1f;
    public float maxPitch = 1.5f;
    private float pitchFromCar;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }

    private void Update() {
        pitchFromCar = ControlCar.cc.carSpeed;
        if (pitchFromCar < minPitch) audioSource.pitch = minPitch;
        else audioSource.pitch = pitchFromCar;
        if (pitchFromCar > maxPitch) audioSource.pitch = maxPitch;
        
    }
}
