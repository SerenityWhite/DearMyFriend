using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSC : MonoBehaviour
{
    public GameObject main;
    public GameObject naming;
    public GameObject warning;
    public GameObject warning2;
    public GameObject exit;
    public UIInput NamingInput;
    public GameObject ClickSound;

    public void GameStart()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        main.SetActive(false);
        if (!PlayerPrefs.HasKey("UserName"))
        {
            naming.SetActive(true);
        }
        else
        {
            warning.SetActive(true);
        }
    }

    public void NamingSet()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        PlayerPrefs.SetString("UserName", NamingInput.value);
        SceneManager.LoadScene(1);
    }

    public void WarningNo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        warning.SetActive(false);
        main.SetActive(true);
    }

    public void WarningYes()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        warning.SetActive(false);
        PlayerPrefs.DeleteAll();
        naming.SetActive(true);
    }

    public void WarningClose()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        warning2.SetActive(false);
        main.SetActive(true);
    }

    public void GameIng()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().Click;
        SoundSC.Instance().Sound.Play();
        main.SetActive(false);
        if (PlayerPrefs.HasKey("UserName"))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            ClickSound.SetActive(false);
            warning2.SetActive(true);
        }
    }

    public void GameEXIT()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        exit.SetActive(true);
        main.SetActive(false);
    }

    public void EXITyes()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        Application.Quit();
    }

    public void EXITno()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        exit.SetActive(false);
        main.SetActive(true);
    }
}
