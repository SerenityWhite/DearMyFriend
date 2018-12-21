using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartTimeSC : MonoBehaviour
{
    public GameObject exit;
    public GameObject option;

    public int partTimeNum;
    public GameObject systemMassage;
    public UILabel systemMassageTX;
    public GameObject sceneBack;

    public GameObject TimeSelec;
    public GameObject Timer;
    public UILabel TimerTX;

    public int partTime;
    public string partTimeStart;
    public string partTimeEnd;
    public bool partTimeComple = false;
    public GameObject Massage;
    public UILabel MassageTX;

    void Start ()
    {
        partTimeStart = PlayerPrefs.GetString("partTimeStart");
        partTimeEnd = PlayerPrefs.GetString("partTimeEnd");
        partTimeNum = PlayerPrefs.GetInt("partTimeNum");
        partTime = PlayerPrefs.GetInt("partTime");
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit.SetActive(true);
            option.SetActive(false);
        }

        if(partTime == 1)
        {
            sceneBack.SetActive(false);
            TimeSelec.SetActive(false);
            Timer.SetActive(true);

            System.DateTime partEndTime = System.DateTime.Parse(partTimeEnd, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat, System.Globalization.DateTimeStyles.None);
            System.DateTime nowTime = System.DateTime.Now;
            System.TimeSpan timeCal = partEndTime - nowTime;

            int timeCalHour = timeCal.Hours;
            int timeCalMinute = timeCal.Minutes;
            int timeCalSec = timeCal.Seconds;

            TimerTX.text = timeCalHour.ToString("00") + ":" + timeCalMinute.ToString("00") + ":" + timeCalSec.ToString("00");

            if (timeCalHour <= 0 && timeCalMinute <= 0 && timeCalSec <= 0)
            {
                partTimeComple = true;
                TimerTX.text = "COMPLETE";
            }
        }
    }

    public void Time1Clock()
    {
        partTimeNum = 1;
        PlayerPrefs.SetInt("partTimeNum", partTimeNum);
        systemMassage.SetActive(true);
        systemMassageTX.text = "1시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
    }

    public void Time3Clock()
    {
        partTimeNum = 3;
        PlayerPrefs.SetInt("partTimeNum", partTimeNum);
        systemMassage.SetActive(true);
        systemMassageTX.text = "3시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
    }

    public void Time5Clock()
    {
        partTimeNum = 5;
        PlayerPrefs.SetInt("partTimeNum", partTimeNum);
        systemMassage.SetActive(true);
        systemMassageTX.text = "5시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
    }

    public void Time8Clock()
    {
        partTimeNum = 8;
        PlayerPrefs.SetInt("partTimeNum", partTimeNum);
        systemMassage.SetActive(true);
        systemMassageTX.text = "8시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
    }

    public void SystemMassageYes()
    {
        systemMassage.SetActive(false);
        sceneBack.SetActive(false);
        TimeSelec.SetActive(false);
        Timer.SetActive(true);

        partTime = 1;
        PlayerPrefs.SetInt("partTime", partTime);

        System.DateTime StartTime = System.DateTime.Now;
        partTimeStart = StartTime.ToString("MM/dd/yyyy hh:mm:ss tt");
        PlayerPrefs.SetString("partTimeStart", partTimeStart);

        System.DateTime EndTime = StartTime.AddHours(partTimeNum);
        partTimeEnd = EndTime.ToString("MM/dd/yyyy hh:mm:ss tt");
        PlayerPrefs.SetString("partTimeEnd", partTimeEnd);
    }

    public void SystemMassageNo()
    {
        systemMassage.SetActive(false);
    }

    public void GetMoney()
    {
        if(partTimeComple == true)
        {
            partTime = 0;
            PlayerPrefs.SetInt("partTime", partTime);

            sceneBack.SetActive(true);
            TimeSelec.SetActive(true);
            Timer.SetActive(false);

            Massage.SetActive(true);
            MassageTX.text = "급여를 받았습니다.";

            if (partTimeNum == 1)
            {
                PlayerState.Instance().money += 7530;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            }
            if (partTimeNum == 3)
            {
                PlayerState.Instance().money += 22590;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            }
            if (partTimeNum == 5)
            {
                PlayerState.Instance().money += 37650;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            }
            if (partTimeNum == 8)
            {
                PlayerState.Instance().money += 60240;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            }
        }
        if (partTimeComple == false)
        {
            Massage.SetActive(true);
            MassageTX.text = "아직 아르바이트를 완료하지 않아 \n급여를 받을 수 없습니다.";
        }
    }

    public void MassageBoxOff()
    {
        Massage.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionOn()
    {
        option.SetActive(true);
        exit.SetActive(false);
    }

    public void OptionOff()
    {
        option.SetActive(false);
    }

    public void EXITOn()
    {
        exit.SetActive(true);
        option.SetActive(false);
    }

    public void EXITyes()
    {
        Application.Quit();
    }

    public void EXITno()
    {
        exit.SetActive(false);
    }
}
