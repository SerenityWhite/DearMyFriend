using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainSC : MonoBehaviour
{
    public GameObject exit;
    public GameObject option;
    public GameObject systemMassage;
    public GameObject nextDay;
    public UILabel systemTX;
    public GameObject adPhoto;

    public GameObject roomBG;
    public GameObject roomBGTalk;
    public GameObject roomNightBG;
    public GameObject guideArrow;
    public GameObject idle;
    public GameObject charaMenu;
    public GameObject talk;
    public GameObject present;
    public GameObject HappyEnding;
    public GameObject tutorial;

    public GameObject textwall;
    public TypewriterEffect storyEF;
    public UILabel nameTX;
    public UILabel storyTX;
    public int StoryNum;
    public int chooseNum;
    public bool storyFinish = false;
    public bool StoryChoose = false;
    public List<GameObject> chooseBox;
    public List<UILabel> chooseTX;
    public List<GameObject> charaImg;

    public GameObject moneyShop;
    public GameObject giftShop;
    public GameObject outdoor;

    public UILabel day;
    public UILabel money;
    public UILabel hartLevel;
    public UIProgressBar hartPink;
    public UIProgressBar hartBlue;

    bool adsReady = true;

    public int LastSceneNum;

    void Start ()
    {
        LastSceneNum = 2;
        PlayerPrefs.SetInt("LastSceneNum", LastSceneNum);
    }
	
	void Update ()
    {
        if (PlayerState.Instance().tutorialBool == 1)
            guideArrow.SetActive(true);
        if (PlayerState.Instance().tutorialBool02 == 1)
            tutorial.SetActive(true);

        day.text = "" + PlayerState.Instance().day;
        money.text = "" + PlayerState.Instance().money;

        if (PlayerState.Instance().hartLevel == 0)
        {
            hartLevel.text = "";
            hartPink.value = PlayerState.Instance().hart / 1500;
            hartBlue.value = PlayerState.Instance().hart / -100;
        }
        if (PlayerState.Instance().hartLevel == 1)
        {
            hartLevel.text = "♥";
            hartPink.value = PlayerState.Instance().hart / 3500;
            hartBlue.value = PlayerState.Instance().hart / -100;
        }
        if (PlayerState.Instance().hartLevel == 2)
        {
            hartLevel.text = "♥♥";
            hartPink.value = PlayerState.Instance().hart / 5500;
            hartBlue.value = PlayerState.Instance().hart / -100;
        }
        if (PlayerState.Instance().hartLevel == 3)
        {
            hartLevel.text = "♥♥♥";
            hartPink.value = PlayerState.Instance().hart / 8500;
            hartBlue.value = PlayerState.Instance().hart / -100;
        }
        if (PlayerState.Instance().hartLevel == 4)
        {
            hartLevel.text = "♥♥♥♥";
            hartPink.value = PlayerState.Instance().hart / 10000;
            hartBlue.value = PlayerState.Instance().hart / -100;
        }
        if (PlayerState.Instance().hartLevel == 5)
        {
            hartLevel.text = "♥♥♥♥♥";
            hartPink.value = 1;
            hartBlue.value = 0;
        }

        if (PlayerState.Instance().day >= 31)
        {
            PlayerState.Instance().day = 31;
            PlayerPrefs.SetInt("day", PlayerState.Instance().day);

            if (PlayerState.Instance().hartLevel < 3)
                SceneManager.LoadScene(5);

            if (PlayerState.Instance().hartLevel >= 3 && PlayerState.Instance().hartLevel < 5)
                SceneManager.LoadScene(6);

            if (PlayerState.Instance().hartLevel >= 5)
            {
                HappyEnding.SetActive(true);
            }
        } // 엔딩

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit.SetActive(true);
            option.SetActive(false);
            charaMenu.SetActive(false);
            present.SetActive(false);
            moneyShop.SetActive(false);
            giftShop.SetActive(false);
            outdoor.SetActive(false);
        }
    }

    public void TutorialOff()
    {
        tutorial.SetActive(false);
        PlayerState.Instance().tutorialBool02 = 0;
        PlayerPrefs.SetInt("tutorialBool02", PlayerState.Instance().tutorialBool02);
    }
    public void TutorialOn()
    {
        tutorial.SetActive(true);
    }

    public void NextDay()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (PlayerState.Instance().talkChance <= 0)
        {
            roomNightBG.GetComponent<TweenAlpha>().PlayForward();
            roomNightBG.SetActive(true);
            roomBG.SetActive(false);
            nextDay.SetActive(true);
            charaMenu.SetActive(false);
        }
        else
        {
            systemMassage.SetActive(true);
            systemTX.text = "아직 오늘의 대화를 마치지 못했습니다. \n나리와 대화해주세요.";
        }
    }
    public void NextDayYes()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        roomNightBG.SetActive(false);
        roomNightBG.GetComponent<TweenAlpha>().ResetToBeginning();
        roomBG.SetActive(true);
        nextDay.SetActive(false);
        Dream();
        PlayerState.Instance().day += 1;
        PlayerPrefs.SetInt("day", PlayerState.Instance().day);
        PlayerState.Instance().talkChance = 5;
        PlayerPrefs.SetInt("talkChance", PlayerState.Instance().talkChance);
        PlayerState.Instance().outdoorChance = 1;
        PlayerPrefs.SetInt("outdoorChance", PlayerState.Instance().outdoorChance);
    }
    public void NextDayNo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        roomNightBG.SetActive(false);
        roomNightBG.GetComponent<TweenAlpha>().ResetToBeginning();
        roomBG.SetActive(true);
        nextDay.SetActive(false);
    }

    void Dream()
    {
        if (PlayerState.Instance().hartLevel == 0)
        {
            int DreamNum0 = Random.Range(0, 100);
            if (DreamNum0 >= 0 && DreamNum0 < 10)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 기분이 괜찮아 보입니다. \n좋은 꿈이라도 꾼 걸까요?\n(Happy가 50 증가했습니다.)";
                PlayerState.Instance().hart += 50;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }

            if (DreamNum0 >= 90 && DreamNum0 < 100)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 표정이 좋지 않습니다. \n나쁜 꿈이라도 꾼 걸까요?\n(Happy가 10 감소했습니다.)";
                PlayerState.Instance().hart -= 10;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }
        }
        if (PlayerState.Instance().hartLevel == 1)
        {
            int DreamNum0 = Random.Range(0, 100);
            if (DreamNum0 >= 0 && DreamNum0 < 20)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 기분이 괜찮아 보입니다. \n좋은 꿈이라도 꾼 걸까요?\n(Happy가 50 증가했습니다.)";
                PlayerState.Instance().hart += 50;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }

            if (DreamNum0 >= 90 && DreamNum0 < 100)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 표정이 좋지 않습니다. \n나쁜 꿈이라도 꾼 걸까요?\n(Happy가 10 감소했습니다.)";
                PlayerState.Instance().hart -= 10;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }
        }
        if (PlayerState.Instance().hartLevel == 2)
        {
            int DreamNum0 = Random.Range(0, 100);
            if (DreamNum0 >= 0 && DreamNum0 < 30)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 기분이 괜찮아 보입니다. \n좋은 꿈이라도 꾼 걸까요?\n(Happy가 50 증가했습니다.)";
                PlayerState.Instance().hart += 50;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }

            if (DreamNum0 >= 90 && DreamNum0 < 100)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 표정이 좋지 않습니다. \n나쁜 꿈이라도 꾼 걸까요?\n(Happy가 10 감소했습니다.)";
                PlayerState.Instance().hart -= 10;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }
        }
        if (PlayerState.Instance().hartLevel == 3)
        {
            int DreamNum0 = Random.Range(0, 100);
            if (DreamNum0 >= 0 && DreamNum0 < 50)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 기분이 괜찮아 보입니다. \n좋은 꿈이라도 꾼 걸까요?\n(Happy가 50 증가했습니다.)";
                PlayerState.Instance().hart += 50;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }

            if (DreamNum0 >= 90 && DreamNum0 < 100)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 표정이 좋지 않습니다. \n나쁜 꿈이라도 꾼 걸까요?\n(Happy가 10 감소했습니다.)";
                PlayerState.Instance().hart -= 10;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }
        }
        if (PlayerState.Instance().hartLevel == 4)
        {
            int DreamNum0 = Random.Range(0, 100);
            if (DreamNum0 >= 0 && DreamNum0 < 70)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 기분이 괜찮아 보입니다. \n좋은 꿈이라도 꾼 걸까요?\n(Happy가 50 증가했습니다.)";
                PlayerState.Instance().hart += 50;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }

            if (DreamNum0 >= 90 && DreamNum0 < 100)
            {
                systemMassage.SetActive(true);
                systemTX.text = "오늘은 나리의 표정이 좋지 않습니다. \n나쁜 꿈이라도 꾼 걸까요?\n(Happy가 10 감소했습니다.)";
                PlayerState.Instance().hart -= 10;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
            }
        }

        if (PlayerState.Instance().day == 11)
        {
            systemMassage.SetActive(true);
            systemTX.text = "학교에서 월급을 받았습니다. \n월급의 일부를 용돈으로 빼두었습니다.";
            PlayerState.Instance().money += 200000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
        }
        if (PlayerState.Instance().day == 14)
        {
            systemMassage.SetActive(true);
            systemTX.text = "감기에 걸려서 병원 치료를 받았습니다. \n옮기지 말아야 할 텐데 걱정이네요.";
            PlayerState.Instance().money -= 13000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
        }
        if (PlayerState.Instance().day == 18)
        {
            systemMassage.SetActive(true);
            systemTX.text = "길에 떨어진 지갑의 주인을 찾아주고 \n사례금을 받았습니다.";
            PlayerState.Instance().money += 20000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
        }
        if (PlayerState.Instance().day == 24)
        {
            systemMassage.SetActive(true);
            systemTX.text = "같은 학교에서 일하는 선생님이 \n결혼식을 해서 축의금을 냈습니다.";
            PlayerState.Instance().money -= 50000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
        }
        if (PlayerState.Instance().day == 27)
        {
            systemMassage.SetActive(true);
            systemTX.text = "복권을 샀는데 4등에 당첨됐습니다. \n구매처에서 5만원으로 교환했습니다.";
            PlayerState.Instance().money += 50000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
        }
    }

    public void CharaClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        guideArrow.SetActive(false);
        PlayerState.Instance().tutorialBool = 0;
        PlayerPrefs.SetInt("tutorialBool", PlayerState.Instance().tutorialBool);
        charaMenu.SetActive(true);
    }
    public void CharaOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        charaMenu.SetActive(false);
    }

    public void PresentOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        charaMenu.SetActive(false);
        present.SetActive(true);
        exit.SetActive(false);
        option.SetActive(false);
    }
    public void PresentOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        present.SetActive(false);
    }

    public void MoneyShopOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        moneyShop.SetActive(true);
        giftShop.SetActive(false);
        outdoor.SetActive(false);
        exit.SetActive(false);
        option.SetActive(false);
    }
    public void MoneyShopOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        moneyShop.SetActive(false);
    }

    public void GiftShopOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        giftShop.SetActive(true);
        moneyShop.SetActive(false);
        outdoor.SetActive(false);
        exit.SetActive(false);
        option.SetActive(false);
    }
    public void GiftShopOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        giftShop.SetActive(false);
    }

    public void OutDoorOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (PlayerState.Instance().hartLevel >= 3)
        {
            if (PlayerState.Instance().outdoorChance > 0)
            {
                outdoor.SetActive(true);
                moneyShop.SetActive(false);
                giftShop.SetActive(false);
                exit.SetActive(false);
                option.SetActive(false);
            }

            else
            {
                systemTX.text = "오늘은 더 이상 외출이 불가능합니다.";
                systemMassage.SetActive(true);
            }
        }
        else
        {
            systemMassage.SetActive(true);
            systemTX.text = "아직 나리가 밖에 나가고 싶어하지 않습니다. \nHappy를 높여주세요.";
        }
    }
    public void OutdoorPark()
    {
        PlayerState.Instance().outdoorChance -= 1;
        PlayerPrefs.SetInt("outdoorChance", PlayerState.Instance().outdoorChance);
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        PlayerState.Instance().outdoorNum = 0;
        PlayerPrefs.SetInt("OutDoorNum", PlayerState.Instance().outdoorNum);
        SceneManager.LoadScene(3);
    }
    public void OutdoorShop()
    {
        PlayerState.Instance().outdoorChance -= 1;
        PlayerPrefs.SetInt("outdoorChance", PlayerState.Instance().outdoorChance);
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        PlayerState.Instance().outdoorNum = 1;
        PlayerPrefs.SetInt("OutDoorNum", PlayerState.Instance().outdoorNum);
        SceneManager.LoadScene(3);
    }
    public void OutdoorSchool()
    {
        PlayerState.Instance().outdoorChance -= 1;
        PlayerPrefs.SetInt("outdoorChance", PlayerState.Instance().outdoorChance);
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        PlayerState.Instance().outdoorNum = 2;
        PlayerPrefs.SetInt("OutDoorNum", PlayerState.Instance().outdoorNum);
        SceneManager.LoadScene(3);
    }
    public void OutdoorStreet()
    {
        PlayerState.Instance().outdoorChance -= 1;
        PlayerPrefs.SetInt("outdoorChance", PlayerState.Instance().outdoorChance);
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        PlayerState.Instance().outdoorNum = 3;
        PlayerPrefs.SetInt("OutDoorNum", PlayerState.Instance().outdoorNum);
        SceneManager.LoadScene(3);
    }
    public void OutDoorOff()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        outdoor.SetActive(false);
    }

    public void PartTimeGo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        SceneManager.LoadScene(4);
    }

    public void OptionOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        option.SetActive(true);
        exit.SetActive(false);
        charaMenu.SetActive(false);
        present.SetActive(false);
        moneyShop.SetActive(false);
        giftShop.SetActive(false);
        outdoor.SetActive(false);
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
        charaMenu.SetActive(false);
        present.SetActive(false);
        moneyShop.SetActive(false);
        giftShop.SetActive(false);
        outdoor.SetActive(false);
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

    public void SystemOK()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        systemMassage.SetActive(false);
    }

    public void TalkOn()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (PlayerState.Instance().talkChance > 0)
        {
            adPhoto.SetActive(false);
            charaMenu.SetActive(false);
            idle.SetActive(false);
            talk.SetActive(true);
            roomBG.SetActive(false);
            roomBGTalk.SetActive(true);
            PlayerState.Instance().talkChance--;
            PlayerPrefs.SetInt("talkChance", PlayerState.Instance().talkChance);
            if (PlayerState.Instance().hartLevel == 0)
            {
                StoryNum = Random.Range(0, 8);
                StoryLevel0();
            }
            if (PlayerState.Instance().hartLevel == 1)
            {
                StoryNum = Random.Range(0, 8);
                StoryLevel1();
            }
            if (PlayerState.Instance().hartLevel == 2)
            {
                StoryNum = Random.Range(0, 6);
                StoryLevel2();
            }
            if (PlayerState.Instance().hartLevel == 3)
            {
                StoryNum = Random.Range(0, 8);
                StoryLevel3();
            }
            if (PlayerState.Instance().hartLevel == 4)
            {
                StoryNum = Random.Range(0, 8);
                StoryLevel4();
            }
            storyEF.ResetToBeginning();
        }
        else
        {
            charaMenu.SetActive(false);
            systemTX.text = "오늘은 더 이상 대화가 불가능합니다.";
            systemMassage.SetActive(true);
        }
    }

    public void PassStory()
    {
        storyEF.Finish();
        storyFinish = true;
        if (StoryChoose == true)
            textwall.SetActive(false);
        if (StoryChoose == false)
            textwall.SetActive(true);
    }
    public void NextStory()
    {
        if (storyFinish == true && StoryChoose == false)
        {
            storyFinish = false;
            TalkOff();
        }

        if (storyFinish == true && StoryChoose == true)
        {
            storyFinish = false;
        }
    }
    public void TextWallClick()
    {
        NextStory();
        textwall.SetActive(false);
    }

    public void StoryChooseClick1()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        chooseNum = 1;
        ChooseStory();
        storyEF.ResetToBeginning();
    }
    public void StoryChooseClick2()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        chooseNum = 2;
        ChooseStory();
        storyEF.ResetToBeginning();
    }
    public void StoryChooseClick3()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        chooseNum = 3;
        ChooseStory();
        storyEF.ResetToBeginning();
    }

    public void TalkOff()
    {
        adPhoto.SetActive(true);
        talk.SetActive(false);
        idle.SetActive(true);
        roomBG.SetActive(true);
        roomBGTalk.SetActive(false);
        charaImg[0].SetActive(false);
        charaImg[1].SetActive(false);
        charaImg[2].SetActive(false);
        charaImg[3].SetActive(false);
        charaImg[4].SetActive(false);
        charaImg[5].SetActive(false);
        charaImg[6].SetActive(false);
    }

    void StoryLevel0()
    {
        if (StoryNum == 0)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "신경 쓰이니까 돌아가세요.";
        }

        if (StoryNum == 1)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "재미 없어….";
        }

        if (StoryNum == 2)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "……. \n(말하고 싶지 않은 것 같다.)";
        }

        if (StoryNum == 3)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "…….\n(이불을 머리 끝까지 덮어버렸다.)";
        }

        if (StoryNum == 4)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n살고 싶지 않아.";
        }

        if (StoryNum == 5)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "혼자 있고 싶으니까 나가주세요.";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "순순히 돌아간다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "버티고 있는다";
        }

        if (StoryNum == 6)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "할 얘기 없어요.";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "오늘 날씨 참 좋다.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "학교에서 있었던 일을 말해준다";
        }

        if (StoryNum == 7)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "말 걸지 마세요.";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "계속 말을 걸어 본다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "얌전히 입을 다문다";
        }
    }
    void StoryLevel1()
    {
        if (StoryNum == 0)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "…….\n(말하고 싶지 않은 것 같다.)";
        }

        if (StoryNum == 1)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n나 같은 사람도 사랑이란 걸 할 수 있을까? \n사람이 이렇게나 싫은데.";
        }

        if (StoryNum == 2)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n발산하지 못한 부정적인 감정은 나를 병들게 했다.";
        }

        if (StoryNum == 3)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n새처럼 자유롭고 싶다. \n차가운 창살을 넘어서 푸른 하늘로 날아가고 싶어.";
        }

        if (StoryNum == 4)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "왜 살아야 하는 걸까요? \n행복하지도 않은데 왜 살아야 하죠?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "그런 말 함부로 하는 거 아니야.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "글쎄… 왜일까? 나도 잘 모르겠어.";
            chooseBox[2].SetActive(true);
            chooseTX[2].text = "어떻게 항상 행복할 수만 있겠어?";
        }

        if (StoryNum == 5)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 왜 자꾸 찾아오세요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "네가 학교에 다시 와줬으면 해서";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "너에 대해 알고 싶어서";
        }

        if (StoryNum == 6)
        {
            charaImg[6].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(꼬르륵 소리와 함께 나리의 얼굴이 붉어졌다.)\n…….";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "뭔가 먹을 걸 챙겨준다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "못 들은 척 한다";
        }

        if (StoryNum == 7)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(방 한 구석에서 아무렇게나 내팽개친 교복을 발견했다.)";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "주워서 다시 잘 걸어둔다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "그냥 냅둔다";
        }
    }
    void StoryLevel2()
    {
        if (StoryNum == 0)
        {
            charaImg[0].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "……. \n(가만히 창 밖을 바라보고 있다.)";
        }

        if (StoryNum == 1)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "……. \n(mp3를 재생하더니 이어폰을 귀에 꽂았다. 무슨 음악을 듣는 걸까?)";
        }

        if (StoryNum == 2)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n난 정해진 길로 가야만 하는 삶이 싫어. \n그렇다면 결국 도태되어야 하는 걸까?";
        }

        if (StoryNum == 3)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 성공한 삶이 뭐라고 생각하세요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "사람마다 기준이 다른 거 아닐까?";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "잘 살면 되는 거 아닐까?";
        }

        if (StoryNum == 4)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(폰 화면 너머로 요리 방송을 보고 있다.) \n맛있겠다….";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "뭔가 먹을 걸 챙겨준다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "못 들은 척 한다";
        }

        if (StoryNum == 5)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(침대에 가까이 다가가니, 이불 속에서 훌쩍거리는 소리가 들린다.)";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "조용히 토닥거려 준다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "이불을 들춘다";
            chooseBox[2].SetActive(true);
            chooseTX[2].text = "방에서 나간다";
        }
    }
    void StoryLevel3()
    {
        if (StoryNum == 0)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n힘이 들면 쉬어도 돼. 지친 날개 잠시 접어두고.";
        }

        if (StoryNum == 1)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n너무 힘들다면 그냥 이 고통이 하루 빨리 지나가길 바라면서 조금만 더 버텨보자.";
        }

        if (StoryNum == 2)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "날씨가 참 좋네요.";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "그러게.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "어제도 좋았어.";
        }

        if (StoryNum == 3)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 학교가 재밌어요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "솔직히 재미 없어.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "그럼~ 재미있지.";
            chooseBox[2].SetActive(true);
            chooseTX[2].text = "모르겠어. 그냥 먹고 살려고 하는 거라.";
        }

        if (StoryNum == 4)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(폰 화면 너머로 뉴스를 읽고 있다.) \n사람들은 왜 이렇게 서로를 싫어하는 걸까요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "세상이 각박해서 그렇지, 뭐.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "다들 힘들어서 그런 거 아닐까?";
        }

        if (StoryNum == 5)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(폰 화면 너머로 오디션 프로그램을 보고 있다.) \n선택 받지 못한 후보들이 너무 불쌍해요. \n잠깐 실수 했을 뿐인데, 욕도 너무 많이 먹는 것 같아요. ";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "네가 함께 응원해주면 어떨까?";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "경쟁 사회고, 모두가 잘 될 순 없는 거니까….";
        }

        if (StoryNum == 6)
        {
            charaImg[4].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 친구에게 배신 당해본 적 있어요? \n정말 좋아했는데… 제가 뭘 잘못했는지 물어도 대답을 안해줘요. \n제가 뭘 잘못한 걸까요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "그 친구가 너와 잘 맞지 않았을 뿐이야.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "난 그런 적이 없어서 잘 모르겠어.";
        }

        if (StoryNum == 7)
        {
            charaImg[4].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "저에게 상처 줬던 그 애를 다시 만난다면… \n복수하지 않을 수 있을지 모르겠어요. \n용서해야 할까요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "네가 하고 싶은대로 하면 된다고 생각해.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "그 애도 아직 어려서 그랬을 거야.";
        }
    }
    void StoryLevel4()
    {
        if (StoryNum == 0)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(방 한 켠에 걸린 교복을 바라보고 있다.) \n너무 무서워요. 제가 잘 지낼 수 있을까요.";
        }

        if (StoryNum == 1)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n삶이라는 거, 너무 어렵게 생각하지 말자. 우린 이 세계에 잠깐 왔다 가는 것뿐이야. 모두들 여행자지. \n나도, 너도, 우리 모두 똑같아. 예외는 없어. 그 여행엔 비탈길도, 언덕도 있어서 힘들기도 해. \n그렇지만 즐거운 일도 분명히 있었고, 앞으로도 있을 테니까. 그렇게 흘러가는 시간을 다시 한 번만 믿어보면 어떨까?";
        }

        if (StoryNum == 2)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(책상 위에 놓인 노트에 다음과 같이 적혀 있다.) \n사람은 완벽하지 않다. \n그래서 우리가 함께 어울려 살아가야 하는 것인지도 몰라.";
        }

        if (StoryNum == 3)
        {
            charaImg[5].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "산책하고 싶어요. \n…선생님이랑 같이.";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "함께 외출한다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "다음에 가자.";
        }

        if (StoryNum == 4)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 달콤한 거 좋아해요? \n카페베어에 맛있는 게 나왔다던데….";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "같이 먹으러 가자.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "다음에 가자.";
        }

        if (StoryNum == 5)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "지금쯤이면 다들 친해졌겠죠? 학교 말이에요. \n잘 지낼 수 있을까….";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "어렵기는 하겠지만, 시기는 중요하지 않아.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "내가 있잖아.";
        }

        if (StoryNum == 6)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "(폰 화면 너머로 뷰티 방송을 보고 있다.) \n다들 참 예쁜 것 같아요. 나는….";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "너도 충분히 예뻐.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "너도 꾸미면 되지.";
        }

        if (StoryNum == 7)
        {
            charaImg[1].SetActive(true);
            nameTX.text = "나리";
            storyTX.text = "선생님은 공부 잘했어요?";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "나는 그냥 평범했어.";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "응, 좀 잘했었어.";
            chooseBox[2].SetActive(true);
            chooseTX[2].text = "아니… 솔직히 못했어.";
        }
    }

    void ChooseStory()
    {
        if (PlayerState.Instance().hartLevel == 0)
        {
            if (StoryNum == 5)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().talkChance = 0;
                    PlayerPrefs.SetInt("talkChance", PlayerState.Instance().talkChance);
                    charaImg[0].SetActive(false);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(지금은 원하는 대로 해주는 것이 좋겠다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(10, 20);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[3].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "제대로 얘길 한 뒤에 가고 싶어. \n(내 말에 나리는 얼굴을 찌푸렸다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 6)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[1].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "(나리의 눈길이 잠시 창가를 향했다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(50, 70);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[4].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "(내 이야기를 듣던 나리의 기분이 엉망진창으로 망가진 것 같다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 7)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart -= Random.Range(5, 15);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[2].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "그만하시라고요! \n(나리는 화를 내며 불쾌함을 표현했다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    charaImg[0].SetActive(false);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(더는 말하고 싶은 것 같지 않으니, 얌전히 입을 다무는 것이 좋겠다.)";
                    StoryChoose = false;
                }
            }
        }
        if (PlayerState.Instance().hartLevel == 1)
        {
            if (StoryNum == 4)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart -= Random.Range(10, 20);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[2].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "함부로 얘기한 거 아니에요!";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(나리의 기분이 조금 편안해진 것처럼 보인다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 3)
                {
                    PlayerState.Instance().hart -= Random.Range(20, 40);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[0].SetActive(false);
                    charaImg[4].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "그럼 대부분은 행복하지 않은 게 정상이라는 건가요? \n(나리는 그렇게 말하며 눈물을 흘렸다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 5)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().talkChance = 0;
                    PlayerPrefs.SetInt("talkChance", PlayerState.Instance().talkChance);
                    charaImg[1].SetActive(false);
                    charaImg[3].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "(더는 듣기 싫었는지, 나리는 대화를 거부하고 이불 속에 들어가버렸다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(나리는 내 말에 조금 기뻐하는 것처럼 보인다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 6)
            {
                if (chooseNum == 1)
                {
                    if(PlayerState.Instance().money >= 3700)
                    {
                        PlayerState.Instance().money -= 3700;
                        PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                        PlayerState.Instance().hart += 80;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        chooseBox[0].SetActive(false);
                        chooseBox[1].SetActive(false);
                        chooseBox[2].SetActive(false);
                        nameTX.text = "나리";
                        storyTX.text = "(작은 목소리로) ……잘 먹었습니다.";
                        StoryChoose = false;
                    }
                    else
                    {
                        systemMassage.SetActive(true);
                        systemTX.text = "보유한 돈이 적어서 \n챙겨줄 수가 없습니다.";
                    }
                }
                if (chooseNum == 2)
                {
                    charaImg[6].SetActive(false);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(많이 부끄러워하는 것 같으니 모르는 척 해주자.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 7)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "(시간이 조금 흐른 뒤, 가지런히 걸린 교복을 발견한 나리가 미묘한 표정을 지었다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리는 학교가 그렇게도 싫은 걸까…?)";
                    StoryChoose = false;
                }
            }
        }
        if (PlayerState.Instance().hartLevel == 2)
        {
            if (StoryNum == 3)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "맞아요. 모두가 똑같은 부분에서 행복을 느끼는 건 아니라고 생각해요.";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(5, 15);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[0].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "잘 산다는 게 뭔데요? \n학교에서 항상 말했던 것처럼 반드시 좋은 대학에 가고 좋은 직장에 취직하는 게 잘 사는 건가요?";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 4)
            {
                if (chooseNum == 1)
                {
                    if(PlayerState.Instance().money >= 5000)
                    {
                        PlayerState.Instance().money -= 5000;
                        PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        charaImg[1].SetActive(false);
                        charaImg[5].SetActive(true);
                        chooseBox[0].SetActive(false);
                        chooseBox[1].SetActive(false);
                        chooseBox[2].SetActive(false);
                        nameTX.text = "나리";
                        storyTX.text = "잘 먹었습니다.";
                        StoryChoose = false;
                    }
                    else
                    {
                        systemMassage.SetActive(true);
                        systemTX.text = "보유한 돈이 적어서 \n챙겨줄 수가 없습니다.";
                    }
                }

                if (chooseNum == 2)
                {
                    charaImg[1].SetActive(false);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(음… 배가 고프기라도 한 걸까?)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 5)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(이불 속에서 나리가 잠시 움찔거리는 듯한 느낌이 들었다. \n금방 진정한 듯한 나리는 작은 목소리로 고맙다고 말했다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(10, 20);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[2].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(보이기 싫었던 모습을 들킨 건지, 엉망이 된 얼굴로 노려보았다.)";
                    StoryChoose = false;
                }
                if (chooseNum == 3)
                {
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(방에서 조용히 나가주는 것이 좋을 것 같다.)";
                    StoryChoose = false;
                }
            }
        }
        if (PlayerState.Instance().hartLevel == 3)
        {
            if (StoryNum == 2)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(맑은 하늘을 바라보는 얼굴에 살며시 미소가 피어났다.)";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(할 말을 잃은 것 같다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 3)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "선생님도 똑같네요. \n(조금 기분이 좋아보인다.)";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(5, 15);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[0].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "전 싫어요.";
                    StoryChoose = false;
                }

                if (chooseNum == 3)
                {
                    PlayerState.Instance().hart -= Random.Range(10, 30);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[3].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "그럼 선생님은, 꿈 같은 건 존재하지 않는다고 생각하시는 건가요?";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 4)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart -= Random.Range(5, 15);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[3].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "세상은 대체 왜 각박해진 건데요?";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "궁지에 몰린 사람들은 잃을 것도, 눈에 보이는 것도 없어서 더더욱 나쁜 일을 저지를 가능성이 높아진대요. \n요즘은 궁지에 몰린 사람들이 너무 많은 것 같아요.";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 5)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "제 존재도 모를 텐데… 그래도 힘이 날까요?";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(20, 40);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[4].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "공정하고 적당한 수준의 경쟁은 발전을 불러온다고 해요. \n하지만, 우리는 왜 태어나서부터 죽을 때까지 살아남기 위해 경쟁만 해야 하는 거죠? \n모두가 함께 배려하고 도우며 살아간다는 선택지는 정말 없는 걸까요?";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 6)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 40;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……마음이 너무 아파요. 그치만 고마워요. \n제가 잘못된 게 아니라고 말해주셔서.";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(20, 40);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……. \n(할 말을 잃은 것 같다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 7)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "똑같이 상처를 준다면… 저는 똑같은 사람이 되는 걸까요….";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart -= Random.Range(20, 40);
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[4].SetActive(false);
                    charaImg[2].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "선생님도 학교 폭력은 그저 어린애들의 일일뿐이라며 가볍게 생각하는 분이신 건가요? \n피해자는 당장이라도 인생이 무너질 것 같은 고통을 받는데!";
                    StoryChoose = false;
                }
            }
        }
        if (PlayerState.Instance().hartLevel == 4)
        {
            if (StoryNum == 3)
            {
                if (chooseNum == 1)
                {
                    if(PlayerState.Instance().money >= 2000)
                    {
                        PlayerState.Instance().money -= 2000;
                        PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                        PlayerState.Instance().hart += 60;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        chooseBox[0].SetActive(false);
                        chooseBox[1].SetActive(false);
                        chooseBox[2].SetActive(false);
                        nameTX.text = "나리";
                        storyTX.text = "같이 가줘서 기뻤어요. 고마워요.";
                        StoryChoose = false;
                    }
                    else
                    {
                        systemMassage.SetActive(true);
                        systemTX.text = "보유한 돈이 적어서 \n함께 갈 수 없습니다.";
                    }
                }

                if (chooseNum == 2)
                {
                    charaImg[5].SetActive(false);
                    charaImg[1].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "아쉽지만… 어쩔 수 없죠, 뭐.";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 4)
            {
                if (chooseNum == 1)
                {
                    if (PlayerState.Instance().money >= 4000)
                    {
                        PlayerState.Instance().money -= 4000;
                        PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                        PlayerState.Instance().hart += 120;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        charaImg[1].SetActive(false);
                        charaImg[5].SetActive(true);
                        chooseBox[0].SetActive(false);
                        chooseBox[1].SetActive(false);
                        chooseBox[2].SetActive(false);
                        nameTX.text = "나리";
                        storyTX.text = "그 음료랑 디저트 정말 맛있었어요. 그쵸?";
                        StoryChoose = false;
                    }
                    else
                    {
                        systemMassage.SetActive(true);
                        systemTX.text = "보유한 돈이 적어서 \n함께 갈 수 없습니다.";
                    }
                }

                if (chooseNum == 2)
                {
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "아쉽지만… 어쩔 수 없죠, 뭐.";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 5)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 50;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "…그렇겠죠? \n용기를 내서 다가가볼게요.";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    PlayerState.Instance().hart += 30;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "선생님이 있으니까… 용기 내볼게요.";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 6)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[6].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……고마워요.";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……네. \n(뭔가를 굳게 결심한 듯한 표정이다.)";
                    StoryChoose = false;
                }
            }
            if (StoryNum == 7)
            {
                if (chooseNum == 1)
                {
                    PlayerState.Instance().hart += 10;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "그렇구나.";
                    StoryChoose = false;
                }

                if (chooseNum == 2)
                {
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "……역시. \n그러니까 선생님이신거겠죠?";
                    StoryChoose = false;
                }

                if (chooseNum == 3)
                {
                    PlayerState.Instance().hart += 20;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    charaImg[1].SetActive(false);
                    charaImg[5].SetActive(true);
                    chooseBox[0].SetActive(false);
                    chooseBox[1].SetActive(false);
                    chooseBox[2].SetActive(false);
                    nameTX.text = "나리";
                    storyTX.text = "그럼 선생님은 선생님이 되기 위해서 많이 노력하셨겠네요. \n대단해요.";
                    StoryChoose = false;
                }
            }
        }
    }

    // 광고 처리
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                PlayerState.Instance().money += 1000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                adsReady = false;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void PhotoClick()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (adsReady)
        {
            ShowRewardedAd();
        }
        else
        {
            systemMassage.SetActive(true);
            systemTX.text = "볼 수 있는 광고가 없습니다.";
        }
    }
}
