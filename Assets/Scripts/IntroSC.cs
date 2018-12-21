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

    public void GameStart()
    {
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
        PlayerPrefs.SetString("UserName", NamingInput.value);
        SceneManager.LoadScene(1);
    }

    public void WarningNo()
    {
        warning.SetActive(false);
        main.SetActive(true);
    }

    public void WarningYes()
    {
        warning.SetActive(false);
        PlayerPrefs.DeleteAll();
        naming.SetActive(true);
    }

    public void WarningClose()
    {
        warning2.SetActive(false);
        main.SetActive(true);
    }

    public void GameIng()
    {
        main.SetActive(false);
        if (PlayerPrefs.HasKey("UserName"))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            warning2.SetActive(true);
        }
    }

    public void GameEXIT()
    {
        exit.SetActive(true);
        main.SetActive(false);
    }

    public void EXITyes()
    {
        Application.Quit();
    }

    public void EXITno()
    {
        exit.SetActive(false);
        main.SetActive(true);
    }
}
