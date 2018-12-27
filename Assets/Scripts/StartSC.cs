using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSC : MonoBehaviour
{
    public GameObject schoolBG;
    public GameObject doorBG;
    public TweenAlpha doorAlpha;

    public GameObject textBox;
    public GameObject textwall;
    public TweenAlpha textBoxAlpha;
    public TypewriterEffect storyEF;
    public UILabel nameTX;
    public UILabel storyTX;
    public int StoryNum;
    public int chooseNum;
    public bool storyFinish = false;
    public bool StoryChoose = false;
    public GameObject Exit;

    public List<GameObject> chooseBox;
    public List<UILabel> chooseTX;

	void Start ()
    {
        doorAlpha = doorBG.GetComponent<TweenAlpha>();
        textBoxAlpha = textBox.GetComponent<TweenAlpha>();
        Story();
        schoolBG.SetActive(true);
        textBox.SetActive(true);
    }
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit.SetActive(true);
        }
    }

    public void PassStory()
    {
        storyEF.Finish();
        storyFinish = true;
        if(StoryChoose == true)
            textwall.SetActive(false);
        if(StoryChoose == false)
            textwall.SetActive(true);
    }

    public void NextStory()
    {
        if(storyFinish == true && StoryChoose == false)
        {
            StoryNum += 1;
            storyFinish = false;
            Story();
            storyEF.ResetToBeginning();
        }

        if(storyFinish == true && StoryChoose == true)
        {
            storyFinish = false;
        }
    }

    public void TextWallClick()
    {
        NextStory();
        textwall.SetActive(false);
    }

    void Story()
    {
        if (StoryNum == 0)
        {
            nameTX.text = "선배 교사";
            storyTX.text = PlayerPrefs.GetString("UserName") + "씨, 지금 바쁘지 않으면 저 좀 도와줄래요?";
        }

        if (StoryNum == 1)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "네, 선배.";
        }

        if (StoryNum == 2)
        {
            nameTX.text = "선배 교사";
            storyTX.text = "지금 행정 관련 서류를 처리하느라 바빠서 그런데, \n대신 출석부 체크 좀 해주세요.";
        }

        if (StoryNum == 3)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "알겠습니다.";
        }

        if (StoryNum == 4)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "1번 출석했고, 2번………음? \n(17번 학생은 왜 계속 결석이지?)";
        }

        if (StoryNum == 5)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(17번 학생의 출석 상태를 알아보니, 지난 학년말부터 학교에 나오지 않은 것 같다. \n이럴땐… 학부모님께 연락을 먼저 해보면 되나?)";
        }

        if (StoryNum == 6)
        {
            schoolBG.SetActive(false);
            doorBG.SetActive(true);
            textBox.SetActive(false);
            textBoxAlpha.ResetToBeginning();
            textBox.SetActive(true);
            textBoxAlpha.PlayForward();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(등교 거부… \n학부모님의 이야기를 들어보니, 방 안에서만 지낸지 제법 오랜 시간이 흘렀다는 것 같다.)";
        }

        if (StoryNum == 7)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "……. \n(조금 긴장되네. 조심스럽게 문을 두드려 보자.)";
        }

        if (StoryNum == 8)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Door1;
            SoundSC.Instance().Sound.Play();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "나리야, 안녕? 학교 부담임선생님이야. \n잠깐만 대화할 수 있을까?";
        }

        if (StoryNum == 9)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "……. \n(반응이 없다. 어떻게 하면 좋을까?)";
            StoryChoose = true;
            chooseBox[0].SetActive(true);
            chooseTX[0].text = "다음에 다시 온다";
            chooseBox[1].SetActive(true);
            chooseTX[1].text = "문을 더욱 세게 두드려본다";
        }

        if (StoryNum == 10)
        {
            doorBG.SetActive(false);
            doorAlpha.ResetToBeginning();
            doorBG.SetActive(true);
            doorAlpha.PlayForward();
            textBox.SetActive(false);
            textBoxAlpha.ResetToBeginning();
            textBox.SetActive(true);
            textBoxAlpha.PlayForward();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(다음 날이 됐다. 문을 다시 두드려보자.)";
        }

        if (StoryNum == 11)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Door1;
            SoundSC.Instance().Sound.Play();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "나리야, 안녕? 어제 왔던 부담임선생님이야. \n잠깐만이라도 괜찮으니까 얘기하지 않을래?";
        }

        if (StoryNum == 12)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "……. \n(역시나 반응이 없다.)";
        }

        if (StoryNum == 13)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(이럴땐 대체 어떻게 하면 좋을까? 그냥 포기할까?)";
        }

        if (StoryNum == 14)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "…….";
        }

        if (StoryNum == 15)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "혼자서 외롭겠다.";
        }

        if (StoryNum == 16)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(세상에 홀로 남겨진 듯한 기분을 잘 알고 있다. \n누구도 찾아주지 않는, 아무런 쓸모가 없는 사람이 돼버린듯한 느낌.)";
        }

        if (StoryNum == 17)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(처음 연락했을때, 이제는 힘들다는 듯한 학부모님의 태도가 떠올랐다. \n나름대로 노력해보셨겠지만… 병원 치료도 이 아이의 마음을 열기엔 부족했던 거겠지.)";
        }

        if (StoryNum == 18)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(누군가가 손을 내밀어주길 간절히 바랬던 과거의 나처럼, \n이 아이도 자신을 알아줄 누군가를 기다리고 있을 지 모른다.)";
        }

        if (StoryNum == 19)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(그래, 포기하지 말자.) \n나리야, 내일 다시 올게. 우리 또 만나자!";
        }

        if (StoryNum == 20)
        {
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(네가 마음의 준비를 할 때까지 포기하지 않고 기다려줄게.)";
        }

        if (StoryNum == 21)
        {
            doorBG.SetActive(false);
            doorAlpha.ResetToBeginning();
            doorBG.SetActive(true);
            doorAlpha.PlayForward();
            textBox.SetActive(false);
            textBoxAlpha.ResetToBeginning();
            textBox.SetActive(true);
            textBoxAlpha.PlayForward();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(……내 마음이 문 너머에 있던 이 아이에게 전해진 걸까?)";
        }

        if (StoryNum == 22)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().DoorOpen;
            SoundSC.Instance().Sound.Play();
            nameTX.text = PlayerPrefs.GetString("UserName");
            storyTX.text = "(방문한지 4일째 되던 날, 나리는 굳게 닫혀있던 문을 열어주었다.)";
        }

        if(StoryNum == 23)
        {
            PlayerState.Instance().day = 7;
            PlayerPrefs.SetInt("day", PlayerState.Instance().day);
            PlayerState.Instance().money = 10000;
            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
            PlayerState.Instance().talkChance = 5;
            PlayerPrefs.SetInt("talkChance", PlayerState.Instance().talkChance);
            PlayerState.Instance().tutorialBool = 1;
            PlayerPrefs.SetInt("tutorialBool", PlayerState.Instance().tutorialBool);
            PlayerState.Instance().tutorialBool02 = 1;
            PlayerPrefs.SetInt("tutorialBool02", PlayerState.Instance().tutorialBool02);
            SceneManager.LoadScene(2);
        }
    }

    void ChooseStory()
    {
        if (StoryNum == 9)
        {
            if(chooseNum == 1)
            {
                chooseBox[0].SetActive(false);
                chooseBox[1].SetActive(false);
                chooseBox[2].SetActive(false);
                nameTX.text = PlayerPrefs.GetString("UserName");
                storyTX.text = "(갑자기 낯선 사람이 찾아와서 놀랬을 수도 있겠다. 내일 다시 오도록 하자.)";
                StoryChoose = false;
            }

            if (chooseNum == 2)
            {
                chooseBox[0].SetActive(false);
                chooseBox[1].SetActive(false);
                chooseBox[2].SetActive(false);
                SoundSC.Instance().Sound.clip = SoundSC.Instance().Door2;
                SoundSC.Instance().Sound.Play();
                nameTX.text = PlayerPrefs.GetString("UserName");
                storyTX.text = "나리야! 잠깐만 선생님이랑 얘기하자, 응? \n(문을 더욱 세게 두드려봤지만 여전히 반응이 없다. 그냥 내일 다시 오는 게 좋겠다.";
                StoryChoose = false;
            }
        }
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

    public void ExitNo()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        Exit.SetActive(false);
    }
    public void ExitYes()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        Exit.SetActive(true);
    }
}
