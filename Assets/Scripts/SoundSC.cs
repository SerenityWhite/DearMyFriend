using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSC : MonoBehaviour
{
    static SoundSC _instance = null;
    public static SoundSC Instance()
    {
        return _instance;
    }
    public AudioSource Sound;
    public AudioClip Click;
    public AudioClip ButtonClick;
    public AudioClip Door1;
    public AudioClip Door2;
    public AudioClip DoorOpen;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        Sound = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
		
	}
}
