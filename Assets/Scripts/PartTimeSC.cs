using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Assets.SimpleAndroidNotifications
{
    public class PartTimeSC : MonoBehaviour
    {
        public int LastSceneNum;

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

        void Start()
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().partTime;
            BGMSC.Instance().BGMSource.Play();

            partTimeStart = PlayerPrefs.GetString("partTimeStart");
            partTimeEnd = PlayerPrefs.GetString("partTimeEnd");
            partTimeNum = PlayerPrefs.GetInt("partTimeNum");
            partTime = PlayerPrefs.GetInt("partTime");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exit.SetActive(true);
                option.SetActive(false);
            }

            if (partTime == 1)
            {
                sceneBack.SetActive(false);
                TimeSelec.SetActive(false);
                Timer.SetActive(true);

                DateTime partEndTime = DateTime.Parse(partTimeEnd, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat, System.Globalization.DateTimeStyles.None);
                DateTime nowTime = DateTime.Now;
                TimeSpan timeCal = partEndTime - nowTime;

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
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            partTimeNum = 1;
            PlayerPrefs.SetInt("partTimeNum", partTimeNum);
            systemMassage.SetActive(true);
            systemMassageTX.text = "1시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
        }

        public void Time3Clock()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            partTimeNum = 3;
            PlayerPrefs.SetInt("partTimeNum", partTimeNum);
            systemMassage.SetActive(true);
            systemMassageTX.text = "3시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
        }

        public void Time5Clock()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            partTimeNum = 5;
            PlayerPrefs.SetInt("partTimeNum", partTimeNum);
            systemMassage.SetActive(true);
            systemMassageTX.text = "5시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
        }

        public void Time8Clock()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            partTimeNum = 8;
            PlayerPrefs.SetInt("partTimeNum", partTimeNum);
            systemMassage.SetActive(true);
            systemMassageTX.text = "8시간 동안 아르바이트를 진행하시겠습니까?\n(취소가 불가능하니 신중하게 결정해주세요.)";
        }

        public void SystemMassageYes()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            systemMassage.SetActive(false);
            sceneBack.SetActive(false);
            TimeSelec.SetActive(false);
            Timer.SetActive(true);

            LastSceneNum = 4;
            PlayerPrefs.SetInt("LastSceneNum", LastSceneNum);

            partTime = 1;
            PlayerPrefs.SetInt("partTime", partTime);

            DateTime StartTime = DateTime.Now;
            partTimeStart = StartTime.ToString("MM/dd/yyyy hh:mm:ss tt");
            PlayerPrefs.SetString("partTimeStart", partTimeStart);

            DateTime EndTime = StartTime.AddHours(partTimeNum);
            partTimeEnd = EndTime.ToString("MM/dd/yyyy hh:mm:ss tt");
            PlayerPrefs.SetString("partTimeEnd", partTimeEnd);

            if (partTimeNum == 1)
                NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(3600), "아르바이트 완료!", "1시간 아르바이트가 끝났어요~ 이제 급여를 받아볼까요?", new Color(1, 0.96f, 0.4f), NotificationIcon.Bell);
            if (partTimeNum == 3)
                NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(3600 * 3), "아르바이트 완료!", "3시간 아르바이트가 끝났어요~ 이제 급여를 받아볼까요?", new Color(1, 0.96f, 0.4f), NotificationIcon.Bell);
            if (partTimeNum == 5)
                NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(3600 * 5), "아르바이트 완료!", "5시간 아르바이트가 끝났어요~ 이제 급여를 받아볼까요?", new Color(1, 0.96f, 0.4f), NotificationIcon.Bell);
            if (partTimeNum == 8)
                NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(3600 * 8), "아르바이트 완료!", "8시간 아르바이트가 끝났어요~ 이제 급여를 받아볼까요?", new Color(1, 0.96f, 0.4f), NotificationIcon.Bell);
        }

        public void SystemMassageNo()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            systemMassage.SetActive(false);
        }

        public void GetMoney()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();

            if (partTimeComple == true)
            {
                partTime = 0;
                PlayerPrefs.SetInt("partTime", partTime);

                sceneBack.SetActive(true);
                TimeSelec.SetActive(true);
                Timer.SetActive(false);

                LastSceneNum = 2;
                PlayerPrefs.SetInt("LastSceneNum", LastSceneNum);

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
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            Massage.SetActive(false);
        }

        public void Back()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            SceneManager.LoadScene(2);
        }

        public void OptionOn()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            option.SetActive(true);
            exit.SetActive(false);
        }
        public void OptionOff()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            PlayerPrefs.SetFloat("BGMVolume", OptionPrograss.Instance().BGM.volume);
            PlayerPrefs.SetFloat("SOUNDVolume", OptionPrograss.Instance().FullSound.volume);
            option.SetActive(false);
        }

        public void EXITOn()
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
            SoundSC.Instance().Sound.Play();
            exit.SetActive(true);
            option.SetActive(false);
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
        }
    }
}