using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPrograss : MonoBehaviour
{
    static OptionPrograss _instance = null;
    public static OptionPrograss Instance()
    {
        return _instance;
    }

    public UISlider Music;
    public UISlider Sound;

    public AudioSource BGM;
    public AudioSource FullSound;

    void Start ()
    {
        if (_instance == null)
            _instance = this;

        Music.value = PlayerPrefs.GetFloat("BGMVolume", 1);
        Sound.value = PlayerPrefs.GetFloat("SOUNDVolume", 1);
    }

	void Update ()
    {
        BGM.volume = Music.value;
        FullSound.volume = Sound.value;
    }
}
