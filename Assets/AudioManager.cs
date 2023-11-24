using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambience, breathing, clock, door, footsteps, horror, scream;

    // Start is called before the first frame update
    void Start()
    {
        ambience.Play();
    }
}
