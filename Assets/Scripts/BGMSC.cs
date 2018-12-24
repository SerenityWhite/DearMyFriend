using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSC : MonoBehaviour
{
    static BGMSC _instance = null;
    public static BGMSC Instance()
    {
        return _instance;
    }
    public AudioSource BGMSource;
    public AudioClip stage;
    public AudioClip HappyEnd;
    public AudioClip HappyEndLast;
    public AudioClip BadEnd;
    public AudioClip partTime;
    public AudioClip SchoolFirst;
    public AudioClip School;
    public AudioClip Street;
    public AudioClip Shop;
    public AudioClip Park;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        BGMSource = GetComponent<AudioSource>();
    }

	void Update ()
    {
		
	}
}
