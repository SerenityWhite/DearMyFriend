using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    static PlayerState _instance = null;
    public static PlayerState Instance()
    {
        return _instance;
    }

    public int day;
    public int money;
    public int talkChance;
    public int outdoorChance;
    public float hart;
    public int hartLevel;
    public int tutorialBool;
    public int tutorialBool02;
    public int outdoorNum;

	void Start ()
    {
        if (_instance == null)
            _instance = this;
    }
	
	void Update ()
    {
        day = PlayerPrefs.GetInt("day");
        money = PlayerPrefs.GetInt("money");
        talkChance = PlayerPrefs.GetInt("talkChance");
        outdoorChance = PlayerPrefs.GetInt("outdoorChance");
        hart = PlayerPrefs.GetFloat("hart");
        hartLevel = PlayerPrefs.GetInt("hartLevel");
        tutorialBool = PlayerPrefs.GetInt("tutorialBool");
        tutorialBool02 = PlayerPrefs.GetInt("tutorialBool02");
        outdoorNum = PlayerPrefs.GetInt("OutDoorNum");

        if (hart <= -100)
            SceneManager.LoadScene(5);

        if (hart >= 1500)
        {
            hartLevel = 1;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
        }
        if (hart >= 3500)
        {
            hartLevel = 2;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
        }
        if (hart >= 5500)
        {
            hartLevel = 3;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
        }
        if (hart >= 8500)
        {
            hartLevel = 4;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
        }
        if (hart >= 10000)
        {
            hartLevel = 5;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
        }
    }
}
