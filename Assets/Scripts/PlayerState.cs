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
    public float accumhart;
    public int hartLevel;
    public int tutorialBool;
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
        accumhart = PlayerPrefs.GetFloat("accumhart");
        hartLevel = PlayerPrefs.GetInt("hartLevel");
        tutorialBool = PlayerPrefs.GetInt("tutorialBool");
        outdoorNum = PlayerPrefs.GetInt("OutDoorNum");

        if (hart <= -100)
            SceneManager.LoadScene(5);

        if (accumhart >= 1500)
        {
            hartLevel = 1;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
            hart = 0;
            PlayerPrefs.SetFloat("hart", hart);
        }

        if (accumhart >= 3500)
        {
            hartLevel = 2;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
            hart = 0;
            PlayerPrefs.SetFloat("hart", hart);
        }

        if (accumhart >= 5500)
        {
            hartLevel = 3;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
            hart = 0;
            PlayerPrefs.SetFloat("hart", hart);
        }

        if (accumhart >= 8500)
        {
            hartLevel = 4;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
            hart = 0;
            PlayerPrefs.SetFloat("hart", hart);
        }

        if (accumhart >= 10000)
        {
            hartLevel = 5;
            PlayerPrefs.SetInt("hartLevel", hartLevel);
            hart = 0;
            PlayerPrefs.SetFloat("hart", hart);
        }
    }
}
