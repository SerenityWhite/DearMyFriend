using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutDoorSC : MonoBehaviour
{
    public GameObject park;
    public GameObject shop;
    public GameObject school;
    public GameObject street;

    public List<GameObject> chara;
    public GameObject talk;
    public TypewriterEffect storyEF;
    public UILabel nameTX;
    public UILabel storyTX;
    public int StoryNum;
    public int StorySubNum;
    public int chooseNum;
    public bool storyFinish = false;
    public bool StoryChoose = false;
    public List<GameObject> chooseBox;
    public List<UILabel> chooseTX;
    public GameObject systemMassage;
    public UILabel systemMassageTX;
    public GameObject Warning;
    public UILabel WarningTX;

    public GameObject exit;
    public GameObject option;

    public List<int> firstBool;
    int schoolSpecial;

    void Start ()
    {
        if (PlayerState.Instance().outdoorNum == 0)
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().Park;
            BGMSC.Instance().BGMSource.Play();

            park.SetActive(true);
            talk.SetActive(true);

            if (PlayerState.Instance().hartLevel == 3)
            {
                if (firstBool[0] == 0)
                    ParkStory();

                if (firstBool[0] == 1)
                {
                    StoryNum = Random.Range(0, 3);
                    ParkStory();
                }
            }
            else
            {
                StoryNum = Random.Range(0, 3);
                ParkStory();
            }
            storyEF.ResetToBeginning();
        }
        if (PlayerState.Instance().outdoorNum == 1)
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().Shop;
            BGMSC.Instance().BGMSource.Play();

            shop.SetActive(true);
            talk.SetActive(true);

            if (PlayerState.Instance().hartLevel == 3)
            {
                if (firstBool[1] == 0)
                    ShopStory();

                if (firstBool[1] == 1)
                {
                    StoryNum = Random.Range(0, 3);
                    ShopStory();
                }
            }
            else
            {
                StoryNum = Random.Range(0, 3);
                ShopStory();
            }
            storyEF.ResetToBeginning();
        }
        if (PlayerState.Instance().outdoorNum == 2)
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().School;
            BGMSC.Instance().BGMSource.Play();

            school.SetActive(true);
            talk.SetActive(true);

            if (PlayerState.Instance().hartLevel == 3)
            {
                if (firstBool[2] == 0)
                {
                    BGMSC.Instance().BGMSource.clip = BGMSC.Instance().SchoolFirst;
                    BGMSC.Instance().BGMSource.Play();
                    ShopStory();
                }

                if (firstBool[2] == 1)
                    ShopStory();
            }
            else
            {
                if (schoolSpecial == 0)
                    ShopStory();
                if (schoolSpecial == 1)
                {
                    StoryNum = Random.Range(0, 3);
                    ShopStory();
                }
            }
            storyEF.ResetToBeginning();
        }
        if (PlayerState.Instance().outdoorNum == 3)
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().Street;
            BGMSC.Instance().BGMSource.Play();

            street.SetActive(true);
            talk.SetActive(true);

            if (PlayerState.Instance().hartLevel == 3)
            {
                if (firstBool[3] == 0)
                    StreetStory();

                if (firstBool[3] == 1)
                {
                    StoryNum = Random.Range(0, 3);
                    StreetStory();
                }
            }
            else
            {
                StoryNum = Random.Range(0, 3);
                StreetStory();
            }
            storyEF.ResetToBeginning();
        }
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit.SetActive(true);
            option.SetActive(false);
        }

        schoolSpecial = PlayerPrefs.GetInt("OutDoorSchool");
        firstBool[0] = PlayerPrefs.GetInt("OutDoorFirstPark");
        firstBool[1] = PlayerPrefs.GetInt("OutDoorFirstStore");
        firstBool[2] = PlayerPrefs.GetInt("OutDoorFirstSchool");
        firstBool[3] = PlayerPrefs.GetInt("OutDoorFirstStreet");
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

    public void WarningOK()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        Warning.SetActive(false);
    }

    public void PassStory()
    {
        storyEF.Finish();
        storyFinish = true;
    }
    public void NextStory()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();

        if (storyFinish == true && StoryChoose == false)
        {
            StorySubNum += 1;

            if (PlayerState.Instance().outdoorNum == 0)
                ParkStory();
            if (PlayerState.Instance().outdoorNum == 1)
                ShopStory();
            if (PlayerState.Instance().outdoorNum == 2)
                SchoolStory();
            if (PlayerState.Instance().outdoorNum == 3)
                StreetStory();

            storyFinish = false;
            storyEF.ResetToBeginning();
        }

        if (storyFinish == true && StoryChoose == true)
        {
            storyFinish = false;
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

    public void OutDoorComple()
    {
        SoundSC.Instance().Sound.clip = SoundSC.Instance().ButtonClick;
        SoundSC.Instance().Sound.Play();
        StorySubNum = 0;
        systemMassage.SetActive(false);
        SceneManager.LoadScene(2);
    }

    void TalkOff()
    {
        talk.SetActive(false);
        chara[0].SetActive(false);
        chara[1].SetActive(false);
        chara[2].SetActive(false);
        chara[3].SetActive(false);
        chara[4].SetActive(false);
        chara[5].SetActive(false);
    }
    void ChooseExit()
    {
        chooseBox[0].SetActive(false);
        chooseBox[1].SetActive(false);
        chooseBox[2].SetActive(false);
        StoryChoose = false;
    }

    void ParkStory()
    {
        if (PlayerState.Instance().hartLevel == 3)
        {
            if (firstBool[0] == 0)
            {
                if (StorySubNum == 0)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "날씨가 참 좋다~";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(하늘을 올려다 보며) …이렇게 맑은 하늘을 본 건 정말 오랜만인 것 같아요.";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "오랜만에 나와본 소감이 어때?";
                }
                if (StorySubNum == 3)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "……좋아요.";
                }
                if (StorySubNum == 4)
                {
                    chara[4].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "역시 나오길 잘한 것 같지?";
                }
                if (StorySubNum == 5)
                {
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "네.";
                }
                if (StorySubNum == 6)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 100;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 100;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "오늘 즐거웠어요.";
                    firstBool[0] = 1;
                    PlayerPrefs.SetInt("OutDoorFirstPark", firstBool[0]);
                } // 스토리 종료
            } // 첫 방문
            if (firstBool[0] == 1)
            {
                if (StoryNum == 0)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(공 놀이에 빠진 어린 아이들을 보며) 즐거워 보이네요.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "어릴때 공 놀이 해본 적 있어? 농구라던가, 피구라던가.";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "선생님은요?";
                        StoryChoose = true;
                        chooseBox[0].SetActive(true);
                        chooseTX[0].text = "많이 하고 놀았지.";
                        chooseBox[1].SetActive(true);
                        chooseTX[1].text = "해본 적은 별로 없어.";
                        chooseBox[2].SetActive(true);
                        chooseTX[2].text = "해본 적이 전혀 없네.";
                    }
                    if (StorySubNum == 3)
                    {
                        TalkOff();
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "또 같이 놀러와요.";
                    } // 스토리 종료
                }
                if (StoryNum == 1)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(피크닉을 즐기는 가족들을 바라보며) 배고프다….";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "(근처에 핫도그를 판매하는 푸드트럭이 있다. 어떻게 할까?)";
                        StoryChoose = true;
                        chooseBox[0].SetActive(true);
                        chooseTX[0].text = "먹을 것을 사온다";
                        chooseBox[1].SetActive(true);
                        chooseTX[1].text = "외면한다";
                    }
                    if (StorySubNum == 2)
                    {
                        TalkOff();
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "바람도 시원하고 배도 든든하네요.";
                    } // 스토리 종료
                }
                if (StoryNum == 2)
                {
                    if (StorySubNum == 0)
                    {
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(햇빛이 내리쬐는 나무를 올려다보며) 좋네요, 이런 느낌.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[5].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "응?";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "따뜻하고 기분 좋아….";
                    }
                    if (StorySubNum == 3)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "(눈을 감았다 뜨며) 그거 아세요? \n따스한 햇살은 우울증 완화에 큰 도움이 된대요. \n햇살이 저를 포근하게 감싸주는 느낌이에요.";
                    }
                    if (StorySubNum == 4)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "(한동안 햇빛을 쬐다가 돌아보며) 이제 집에 돌아가요.";
                    }
                    if (StorySubNum == 5)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "기분 좋은 하루였어요.";
                    } // 스토리 종료
                }
            }
        }
        else
        {
            if (StoryNum == 0)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(길가에 버려진 쓰레기를 주우며 한숨을 내쉬었다.) …….";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "쓰레기통은 저쪽에 있어. \n아직도 길가에 쓰레기를 버리는 사람이 있다니.";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(내 얼굴을 빤히 쳐다보며) 선생님은 길가에 쓰레기 버려본 적 있어요?";
                    StoryChoose = true;
                    chooseBox[0].SetActive(true);
                    chooseTX[0].text = "전혀 없어.";
                    chooseBox[1].SetActive(true);
                    chooseTX[1].text = "부끄럽지만 있긴 있었어.";
                }
                if (StorySubNum == 3)
                {
                    TalkOff();
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "쓰레기의 자리는 쓰레기통. \n제 자리를 찾아주니 뿌듯하네요.";
                } // 스토리 종료
            }
            if (StoryNum == 1)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(물방울이 떨어지는 나뭇잎을 바라보며) 비가 내렸었나봐요.";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "그러게. 우리가 나올땐 비가 그쳐서 다행이야.";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(잎을 손으로 톡하고 건드리더니) 앗, 차가워.";
                }
                if (StorySubNum == 3)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "괜찮아? (가지고 있던 손수건을 건네주었다.)";
                }
                if (StorySubNum == 4)
                {
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "네, 괜찮아요. (손수건을 받아들며) 고맙습니다. \n역시 비가 온 뒤엔 맑고 깨끗한 느낌이 들어서 좋네요.";
                }
                if (StorySubNum == 5)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 125;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 125;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "비 온 뒤의 공원도 기분 좋네요.";
                } // 스토리 종료
            }
            if (StoryNum == 2)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리는 집에서 가져온 작은 가방을 꺼내더니 그 안에서 귀여운 도시락통을 꺼냈다. \n노릇하게 구워진 토스트 사이에 끼워진 햄과 야채가 보인다.)";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(샌드위치 하나를 집어서 건네며) 선생님, 같이 먹어요.";
                }
                if (StorySubNum == 2)
                {
                    chara[5].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "언제 준비한 거야?";
                }
                if (StorySubNum == 3)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "냉장고에 재료가 있길래 만들어봤어요. \n예전에 여기서 피크닉하던 가족들을 봤잖아요. \n…별 거 없지만 해보고 싶었어요.";
                }
                if (StorySubNum == 4)
                {
                    chara[4].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "고마워, 잘 먹을게.";
                }
                if (StorySubNum == 5)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "네.";
                }
                if (StorySubNum == 5)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 150;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 150;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "나중에 또 같이 피크닉해요.";
                } // 스토리 종료
            }
        }
    }
    void ShopStory()
    {
        if (PlayerState.Instance().hartLevel == 3)
        {
            if (firstBool[1] == 0)
            {
                if (StorySubNum == 0)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "여긴 내가 가끔씩 돈이 부족하면 아르바이트를 하는 곳이야.";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "…선생님이 여기서 아르바이트를 하신다고요?";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "가끔. 월급만으로는 용돈이 부족할 때가 있어.";
                }
                if (StorySubNum == 3)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "선생님은 돈 걱정 없이 사실 줄 알았는데.";
                }
                if (StorySubNum == 4)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "아직은 학교에서 일을 많이 하고 있는 것도 아니라서. \n뭐 먹을래?";
                }
                if (StorySubNum == 5)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "여러가지 먹을 게 많네요.";
                }
                if (StorySubNum == 6)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "맛있는 거 꽤 많아. 요즘 편의점엔 없는 게 없다니까.";
                }
                if (StorySubNum == 7)
                {
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "…….";
                }
                if (StorySubNum == 8)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 100;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 100;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "잘 먹었어요, 고맙습니다.";
                    firstBool[1] = 1;
                    PlayerPrefs.SetInt("OutDoorFirstStore", firstBool[1]);
                } // 스토리 종료
            } // 첫 방문
            if (firstBool[1] == 1)
            {
                if (StoryNum == 0)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(컵라면을 집어들며) 오늘 저녁.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "그것만 먹어?";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "네, 충분해요.";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "라면 너무 자주 먹으면 안 좋은데. \n맛있기는 하지만. ";
                        StoryChoose = true;
                        chooseBox[0].SetActive(true);
                        chooseTX[0].text = "삼각김밥을 사준다";
                        chooseBox[1].SetActive(true);
                        chooseTX[1].text = "걱정으로 끝낸다";
                    }
                    if (StorySubNum == 4)
                    {
                        TalkOff();
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "편의점에서 끼니를 해결한 건 꽤 오랜만이네요.";
                    } // 스토리 종료
                }
                if (StoryNum == 1)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(편의점에서 다급히 먹거리를 사서 나가는 사람을 바라보며) \n세상은 참 바쁘게 돌아가는 것 같아요.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "왜?";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "잠깐 식사할 여유조차 부족한 모습을 보면 마음이 안 좋아요.";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[0].SetActive(false);
                        chara[3].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "그렇게까지 열심히 살아야 할 이유가 대체 뭘까….";
                    }
                    if (StorySubNum == 4)
                    {
                        chara[3].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "각자 자신이 원하는 행복이 있을 거야. \n그 목표를 위해서 힘내고 있는 거 아닐까?";
                    }
                    if (StorySubNum == 5)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "저도 제가 원하는 행복을 찾을 수 있을까요?";
                    } // 스토리 종료
                }
                if (StoryNum == 2)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(과자가 진열된 매대를 바라보며) …….";
                    }
                    if (StorySubNum == 1)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "(꽤 오래 고민하는 듯 하더니 하나를 집으며) 전 이걸로 할래요.";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "초코칩쿠키?";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "우유랑 같이 먹으면 맛있어요.";
                    }
                    if (StorySubNum == 4)
                    {
                        chara[5].SetActive(false);
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(매대에 있는 다른 과자들을 바라보며) 선택지가 너무 많으면 결정 장애를 불러오는 것 같아요.하나를 결정하기가 힘드네요.";
                    }
                    if (StorySubNum == 5)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "그렇네.";
                    }
                    if (StorySubNum == 6)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "오늘도 맛있는 과자가 참 많네요.";
                    } // 스토리 종료
                }
            }
        }
        else
        {
            if (StoryNum == 0)
            {
                if (StorySubNum == 0)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(이번 달 용돈은 조금 위험해서 급하게 아르바이트를 시작했다.)";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(초콜릿과 파이를 계산대에 내려놓으며) 계산해 주세요.";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(false);
                    chara[5].SetActive(true);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "어서오세요, 손님. \n(내 인사에 나리가 어색하게 웃는다.)";
                }
                if (StorySubNum == 3)
                {
                    chara[5].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "달콤한 걸 좋아하는구나. \n저녁 안 먹었어? 파이도 있네.";
                }
                if (StorySubNum == 4)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(계산을 마친 파이를 집어들며) 이건 선생님거에요.";
                }
                if (StorySubNum == 5)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "응?";
                }
                if (StorySubNum == 6)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리는 당황한 나를 보며 장난스럽게 웃었다.)";
                }
                if (StorySubNum == 7)
                {
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "아르바이트 힘내세요, " + PlayerPrefs.GetString("UserName") + " 선생님.";
                }
                if (StorySubNum == 8)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 150;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 150;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "그 파이 맛있죠? \n제가 좋아하는 거에요.";
                } // 스토리 종료
            }
            if (StoryNum == 1)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(노릇노릇 익은 새우튀김을 바라보며) 선생님은 튀김 좋아하세요?";
                    StoryChoose = true;
                    chooseBox[0].SetActive(true);
                    chooseTX[0].text = "좋아해.";
                    chooseBox[1].SetActive(true);
                    chooseTX[1].text = "안 좋아해.";
                }
                if (StorySubNum == 1)
                {
                    TalkOff();
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "다음엔 치킨도 먹어보고 싶어요.";
                } // 스토리 종료
            }
            if (StoryNum == 2)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(매대 위에 놓인 비슷한 물건들을 바라보며) 어떻게 보면… \n이 물건들도 누군가의 선택을 받기 위해 서로 경쟁을 하고 있네요.";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "모두가 각자 다른 매력을 가지고 있어. \n선택하는 사람의 취향에 따라 제대로 된 가격이 치뤄지기도 하고 방치되기도 하지만.";
                }
                if (StorySubNum == 2)
                {
                    chara[3].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "선택 받지 못해서… 방치된 물건들은 불행할까요?";
                }
                if (StorySubNum == 3)
                {
                    chara[3].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "그 물건들을 필요로 하는 누군가가 또 세상에 있으니까 \n사라지지 않고 이렇게 존재할 수 있는 거 아닐까?";
                }
                if (StorySubNum == 4)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "……경쟁이 나쁜 것만은 아니라고 생각해요. \n모두가 각자 다른 매력이 있다는 그 사실을 잊지만 않는다면요.";
                }
                if (StorySubNum == 5)
                {
                    chara[4].SetActive(false);
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "틀린게 아니라 다른 것뿐이라고, 그렇게 인정할 수 있으면 좋겠어요.";
                }
                if (StorySubNum == 6)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 150;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 150;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "세상에 하나뿐인 사람이 되고 싶어요.";
                } // 스토리 종료
            }
        }
    }
    void SchoolStory()
    {
        if (PlayerState.Instance().hartLevel == 3)
        {
            if (firstBool[2] == 0)
            {
                if (StorySubNum == 0)
                {
                    chara[2].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "왜……. \n왜 하필 여기에요? 많고 많은 곳 중에 왜….";
                }
                if (StorySubNum == 1)
                {
                    chara[2].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리의 동공이 격하게 흔들리고 있었지만 물러설 수는 없다.)";
                }
                if (StorySubNum == 2)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "언제까지고 외면할 수는 없다고 생각해.";
                }
                if (StorySubNum == 3)
                {
                    chara[1].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "싫어요! 저는 여기가 세상에서 제일 싫다고요! \n왜 다들…!!";
                }
                if (StorySubNum == 4)
                {
                    chara[1].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "왜 그렇게 학교가 싫어진 건지 짐작 가는 게 없는 건 아니야. \n하지만….";
                }
                if (StorySubNum == 5)
                {
                    chara[1].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "듣기 싫어!! \n전 여기에 있기 싫어요! 집에 갈래요.";
                }
                if (StorySubNum == 6)
                {
                    chara[1].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(도망치는 나리의 등에 대고) 싫다고 외면만 해서는 아무것도 변하지 않아!";
                }
                if (StorySubNum == 7)
                {
                    chara[3].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(걸음을 멈추고) …….";
                }
                if (StorySubNum == 8)
                {
                    chara[3].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "도망치는 건 쉽겠지. \n두 번 다시 상처를 마주하지도 않고 살아가면 편하겠지.";
                }
                if (StorySubNum == 9)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "학교에 반드시 다녀야 한다고 강요하는 건 아니야. \n하지만 너도 알고 있잖아. 언젠가는…!";
                }
                if (StorySubNum == 10)
                {
                    chara[3].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "…….";
                }
                if (StorySubNum == 11)
                {
                    //쓰러지는 효과음
                    chara[3].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나는 하고 싶었던 말을 끝내지 못했다. \n내 말이 끝나기 전에 나리가 그 자리에서 쓰러지고 말았기 때문이다.)";
                }
                if (StorySubNum == 12)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(아직 나리를 학교에 데려오기엔 너무 일렀던 걸지도 모르겠다.)";
                }
                if (StorySubNum == 13)
                {
                    TalkOff();
                    PlayerState.Instance().hart -= 70;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart -= 70;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "(나리를 집에 데려다주자)";
                    firstBool[2] = 1;
                    PlayerPrefs.SetInt("OutDoorFirstSchool", firstBool[2]);
                } // 스토리 종료
            } // 첫 방문
            if (firstBool[2] == 1)
            {
                if (StorySubNum == 0)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(지난 번, 학교에 데려왔다가 쓰러졌었지…. \n아직은 나리가 마음의 준비를 할 수 있도록 기다려 주는 게 좋을 것 같다.)";
                }
                if (StorySubNum == 1)
                {
                    TalkOff();
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "(나리가 준비되면 그때 다시 오자.)";
                } // 스토리 종료
            }
        }
        else
        {
            if (schoolSpecial == 0)
            {
                if (StorySubNum == 0)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "정말 괜찮겠어?";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(true);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(내 말에 나리가 고개를 끄덕거렸다.)";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "…고마워.";
                }
                if (StorySubNum == 3)
                {
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리는 그저 진심으로 손을 내밀어줄 누군가와 \n상처를 다스릴 시간이 필요했던 걸지도 모르겠다.)";
                }
                if (StorySubNum == 4)
                {
                    chara[0].SetActive(true);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(우리는 학교 정문 앞에 서있었다. \n나리를 바라보자, 눈빛이 미세하게 흔들리고 있었다.)";
                }
                if (StorySubNum == 5)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "아직 힘들면 무리하지 않아도 돼.";
                }
                if (StorySubNum == 6)
                {
                    chara[0].SetActive(true);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(내 말에 나리가 고개를 천천히 내저었다. \n그러고는 용기를 내서 정문 안으로 한발자국 내딛었다.)";
                }
                if (StorySubNum == 7)
                {
                    nameTX.text = "나리";
                    storyTX.text = "(학교 운동장에서 달리는 학생들을 바라보며) \n아직 교실까지는 힘들 것 같아요.";
                }
                if (StorySubNum == 8)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "그래, 고생했어. \n(나리의 뒤를 따라 함께 학교 건물 주변을 산책했다.)";
                }
                if (StorySubNum == 9)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "이제 집에 돌아가요.";
                }
                if (StorySubNum == 10)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 140;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 140;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "여기까진 괜찮은 것 같아요.";
                    schoolSpecial = 1;
                    PlayerPrefs.SetInt("OutDoorSchool", schoolSpecial);
                } // 스토리 종료
            }
            if (schoolSpecial == 1)
            {
                if (StoryNum == 0)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(한 입 베어먹은 샌드위치를 들고서) \n매점표 샌드위치 세트는 정말 오랜만인 것 같아요.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "이 학교 매점은 특제 딸기 주스가 제일 맛있었어. \n내가 학생일땐 이런 거 없었는데, 세상 참 좋아졌네.";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "1학년때 오렌지주스랑 같이 먹었던 그 맛이 그리웠어요. \n비록 그때의 좋았던 추억은 이제 없지만….";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "오늘은 나랑 같이 먹었네. \n이 추억은 기억에 남기 어려울까?";
                    }
                    if (StorySubNum == 4)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(고개를 저으며) 아니요. \n기억에 많이 남을 것 같아요.";
                    }
                    if (StorySubNum == 5)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "상처가 된 추억은 얼마든지 잊어도 돼. \n사람에겐 망각이라는 편리한 기능이 있잖아.";
                    }
                    if (StorySubNum == 6)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "…….";
                    }
                    if (StorySubNum == 7)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "물론… 말처럼 쉽지 않겠지만. \n나쁜 일이 있으면 반드시 언젠가 좋은 일도 있기 마련이래. \n난 그 말을 믿거든.";
                    }
                    if (StorySubNum == 8)
                    {
                        chara[3].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "……네.";
                    }
                    if (StorySubNum == 9)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 150;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 150;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "오랜만에 맛있었어요. \n오늘도 고마워요.";
                    } // 스토리 종료
                }
                if (StoryNum == 1)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(학교 운동장에서 달리는 학생들을 바라보며) \n선생님은 달리기 잘했어요?";
                        StoryChoose = true;
                        chooseBox[0].SetActive(true);
                        chooseTX[0].text = "잘했어.";
                        chooseBox[1].SetActive(true);
                        chooseTX[1].text = "그럭저럭?";
                        chooseBox[2].SetActive(true);
                        chooseTX[2].text = "아니, 전혀.";
                    }
                    if (StorySubNum == 1)
                    {
                        TalkOff();
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "달리기 좀 못하면 어때요. 그렇죠?";
                    } // 스토리 종료
                }
                if (StoryNum == 2)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(교복을 입고 즐거운 듯 웃으며 지나가는 여학생 무리를 바라보며) \n…….";
                    }
                    if (StorySubNum == 1)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "저 무리 속에 있으면 언제까지고 즐거울 거라고 믿었어요. \n실제로도 즐거웠고… 어쩔땐 학교에 가는 걸 기대한 적도 있어요.";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(false);
                        chara[3].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "그런데 왜 이렇게 되어버렸을까요?";
                    }
                    if (StorySubNum == 3)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "(교실을 올려다보며) 전 친구와 경쟁하고 싶지 않아요. \n싸우고 싶지 않아요.";
                    }
                    if (StorySubNum == 4)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "성적표에 적힌 수치로, 보여지는 모습으로, 누군가를 질투하고 미움 받는 \n그런 생활은 하고 싶지 않았어요.";
                    }
                    if (StorySubNum == 5)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "약하면 언제든지 쉽게 물어뜯기는 정글 같은 교실이 싫었어요.";
                    }
                    if (StorySubNum == 6)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "누군가가 나쁜 행동을 해도, 내 일이 아니라는 이유로 방치하는… \n비겁한 모습들이 더는 싫어요.";
                    }
                    if (StorySubNum == 7)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 200;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 200;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "그럼에도 이 곳에 희망이 있을까요?";
                    } // 스토리 종료
                }
            }
        }
    }
    void StreetStory()
    {
        if (PlayerState.Instance().hartLevel == 3)
        {
            if (firstBool[3] == 0)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "여긴…. (주변을 두리번거리며)";
                }
                if (StorySubNum == 1)
                {
                    nameTX.text = "나리";
                    storyTX.text = "항상 다른 애들이 가는 모습만 보고 실제로 와본 건 처음이에요. \n여기 케이크가 그렇게 맛있다던데.";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "집에서도 가깝고 학교에서도 가까워서 자주 오는 편이야. \n뭐 마실래?";
                }
                if (StorySubNum == 3)
                {
                    chara[5].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "전 단 게 좋아요. 초콜릿 들어간 거.";
                }
                if (StorySubNum == 4)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 100;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 100;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "카페베어라고 했죠? 또 오고 싶어요.";
                    firstBool[3] = 1;
                    PlayerPrefs.SetInt("OutDoorFirstStreet", firstBool[3]);
                } // 스토리 종료
            } // 첫 방문
            if (firstBool[3] == 1)
            {
                if (StoryNum == 0)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(카페 앞을 지나가다가) 맛있겠다….";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "(나리의 시선을 따라가니, 카페 유리벽에 특제 초콜릿 케이크 광고지가 붙어있다.)";
                        StoryChoose = true;
                        chooseBox[0].SetActive(true);
                        chooseTX[0].text = "같이 먹으러 갈래?";
                        chooseBox[1].SetActive(true);
                        chooseTX[1].text = "너무 달아 보인다.";
                    }
                    if (StorySubNum == 2)
                    {
                        TalkOff();
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "예상보다 훨씬 맛있었어요.";
                    } // 스토리 종료
                }
                if (StoryNum == 1)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(주변을 두리번거리며) 사람 정말 많다….";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "사람 많은 거 싫어해?";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "네, 저는 조용한 장소가 좋아요.";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "그치만… 혼자가 아니라면 나쁘지 않은 것 같기도 해요.";
                    }
                    if (StorySubNum == 4)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "다음에 또 같이 올 수 있을까요?";
                    } // 스토리 종료
                }
                if (StoryNum == 2)
                {
                    if (StorySubNum == 0)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "(지나가는 사람들을 바라보며) …신기해요.";
                    }
                    if (StorySubNum == 1)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "뭐가?";
                    }
                    if (StorySubNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "매일 똑같은 일상이 반복되는데도 항상 즐거워하는 사람들을 보고 있으면 신기해요. \n저는 너무 지겹거든요.";
                    }
                    if (StorySubNum == 3)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "일상이 항상 다를 수는 없지. \n지루한 날들도 있어야 가끔씩 있는 즐거운 날이 의미를 갖는 거 아닐까?";
                    }
                    if (StorySubNum == 4)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "그럼 사람들은 가끔씩 찾는 그 의미 속에서 즐거움을 찾는 걸까요?";
                    }
                    if (StorySubNum == 5)
                    {
                        chara[0].SetActive(false);
                        nameTX.text = PlayerPrefs.GetString("UserName");
                        storyTX.text = "적어도 나는 그래.";
                    }
                    if (StorySubNum == 6)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "그렇구나….";
                    }
                    if (StorySubNum == 7)
                    {
                        TalkOff();
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        systemMassage.SetActive(true);
                        systemMassageTX.text = "세잎 클로버 속에서 네잎 클로버를 찾는 것 같아요.";
                    } // 스토리 종료
                }
            }
        }
        else
        {
            if (StoryNum == 0)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(카페 바깥에 있는 테이블에 앉아 핫초코를 홀짝이며) \n달다….";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(달그락거리는 소리와 함께 잔을 내려놓자, 나리가 말을 걸었다.)";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "선생님은 단 거 좋아하세요?";
                    StoryChoose = true;
                    chooseBox[0].SetActive(true);
                    chooseTX[0].text = "좋아해.";
                    chooseBox[1].SetActive(true);
                    chooseTX[1].text = "아니.";
                }
                if (StorySubNum == 3)
                {
                    TalkOff();
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "저는 행복해지고 싶어요.";
                } // 스토리 종료
            }
            if (StoryNum == 1)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(영화관에 걸린 포스터들을 보며) 전 이게 제일 재미 있어 보여요.";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "(나리가 가리킨 곳을 바라보자, 벚꽃이 휘날리는 배경에 \n남녀배우가 서로를 바라보며 서있다.) 로맨스 영화?";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "네, 얼마 전에 포털 사이트 실시간 검색어에 올라왔었는데 평이 좋았어요.";
                }
                if (StorySubNum == 3)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "그래? 그럼 한 번 볼까?";
                }
                if (StorySubNum == 4)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "……. (영화에 집중하느라 팝콘이 줄어들지 않고 있다.)";
                }
                if (StorySubNum == 1)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 125;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 125;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "주인공의 사랑이 감동적이었어요.";
                } // 스토리 종료
            }
            if (StoryNum == 2)
            {
                if (StorySubNum == 0)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "……. (포크를 든 채로 디저트 공략에 열중하고 있다.)";
                }
                if (StorySubNum == 1)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "맛있어?";
                }
                if (StorySubNum == 2)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(고개를 열심히 끄덕거리며) 네. \n그런데 정말 저만 먹어도 괜찮아요?";
                }
                if (StorySubNum == 3)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "난 충분해. 많이 먹어.";
                }
                if (StorySubNum == 4)
                {
                    chara[0].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(포크를 멈추며) 으음….";
                }
                if (StorySubNum == 5)
                {
                    chara[0].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "왜 그래?";
                }
                if (StorySubNum == 6)
                {
                    chara[4].SetActive(true);
                    nameTX.text = "나리";
                    storyTX.text = "(자신의 배를 내려다보더니) 저… 살찌면 어떡하죠?";
                }
                if (StorySubNum == 7)
                {
                    chara[4].SetActive(false);
                    nameTX.text = PlayerPrefs.GetString("UserName");
                    storyTX.text = "이제서야 고민하는 거야?";
                }
                if (StorySubNum == 8)
                {
                    TalkOff();
                    PlayerState.Instance().hart += 150;
                    PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                    PlayerState.Instance().accumhart += 150;
                    PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                    systemMassage.SetActive(true);
                    systemMassageTX.text = "옷이 안 맞는 상황을 생각하니 끔찍해요.";
                } // 스토리 종료
            }
        }
    }

    void ChooseStory()
    {
        if (PlayerState.Instance().outdoorNum == 0)
        {
            if (PlayerState.Instance().hartLevel == 3)
            {
                if (StoryNum == 0)
                {
                    if (chooseNum == 1)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "그렇다면 선생님도 저 애들처럼 저렇게 뛰어 놀았겠네요.";
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 2)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "저도 많이 해보진 않았어요. 그땐 소꿉장난이 더 재미있었고.";
                        PlayerState.Instance().hart += 120;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 120;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 3)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "공을 별로 안 좋아하시나보다. 그럴 수 있죠.";
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
                if (StoryNum == 1)
                {
                    if (chooseNum == 1)
                    {
                        if (PlayerState.Instance().money >= 2000)
                        {
                            chara[5].SetActive(true);
                            nameTX.text = "나리";
                            storyTX.text = "감사합니다. 잘 먹을게요.";
                            PlayerState.Instance().money -= 2000;
                            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                            PlayerState.Instance().hart += 300;
                            PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                            PlayerState.Instance().accumhart += 300;
                            PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                            ChooseExit();
                        }
                        else
                        {
                            Warning.SetActive(true);
                            WarningTX.text = "보유한 돈이 적어서 \n사줄 수가 없습니다.";
                        }
                    }
                    if (chooseNum == 2)
                    {
                        chara[0].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "저쪽에서 핫도그 팔고 있네요. 잠깐 다녀올게요.";
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
            else
            {
                if (StoryNum == 0)
                {
                    if (chooseNum == 1)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "역시 선생님은 모범적인 분이시네요. \n부끄럽지만 저는 어릴 때 쓰레기통을 못 찾아서 길가에 그냥 버려본 적이 있어요. \n다시 생각해도 부끄럽네요.";
                        PlayerState.Instance().hart += 125;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 125;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 2)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "저도 많이 해보진 않았어요. 그땐 소꿉장난이 더 재미있었고.";
                        PlayerState.Instance().hart += 150;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 150;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
        }
        if (PlayerState.Instance().outdoorNum == 1)
        {
            if (PlayerState.Instance().hartLevel == 3)
            {
                if (StoryNum == 0)
                {
                    if (chooseNum == 1)
                    {
                        if (PlayerState.Instance().money >= 800)
                        {
                            chara[5].SetActive(true);
                            nameTX.text = "나리";
                            storyTX.text = "잘 먹을게요. 고맙습니다.";
                            PlayerState.Instance().money -= 800;
                            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                            PlayerState.Instance().hart += 180;
                            PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                            PlayerState.Instance().accumhart += 180;
                            PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                            ChooseExit();
                        }
                        else
                        {
                            Warning.SetActive(true);
                            WarningTX.text = "보유한 돈이 적어서 \n사줄 수가 없습니다.";
                        }
                    }
                    if (chooseNum == 2)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "걱정해주셔서 고마워요. 그치만 정말 괜찮아요.";
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
            else
            {
                if (StoryNum == 1)
                {
                    if (chooseNum == 1)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "튀김은 맛 없는 게 거의 없는 것 같아요. \n만두나 감자를 튀겨도 맛있고….";
                        PlayerState.Instance().hart += 130;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 130;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 2)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "기름기가 많아서 다이어트엔 가장 큰 적인 것 같아요. \n그래도 저는 맛있어서 좋아해요.";
                        PlayerState.Instance().hart += 125;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 125;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
        }
        if (PlayerState.Instance().outdoorNum == 2)
        {
            if (PlayerState.Instance().hartLevel == 3) {}
            else
            {
                if (schoolSpecial == 1 && StoryNum == 1)
                {
                    if (chooseNum == 1)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "저는 달리기 잘 못해요. \n그래서 달리기 잘하는 애들을 볼 때마다 신기했어요.";
                        PlayerState.Instance().hart += 130;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 130;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 2)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "달리기는 잘하는 것보다 꾸준히 하는 편이 다이어트에도 더 좋다고 하던데. \n물론 대회에 나갈땐 얘기가 달라지지만요.";
                        PlayerState.Instance().hart += 125;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 125;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 3)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "저도 잘 못하는데. 똑같네요, 우리.";
                        PlayerState.Instance().hart += 140;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 140;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
        }
        if (PlayerState.Instance().outdoorNum == 3)
        {
            if (PlayerState.Instance().hartLevel == 3)
            {
                if (StoryNum == 0)
                {
                    if (chooseNum == 1)
                    {
                        if (PlayerState.Instance().money >= 5000)
                        {
                            chara[4].SetActive(true);
                            nameTX.text = "나리";
                            storyTX.text = "정말 괜찮아요? 고맙습니다.";
                            PlayerState.Instance().money -= 5000;
                            PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                            PlayerState.Instance().hart += 600;
                            PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                            PlayerState.Instance().accumhart += 600;
                            PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                            ChooseExit();
                        }
                        else
                        {
                            Warning.SetActive(true);
                            WarningTX.text = "보유한 돈이 적어서 \n사먹을 수 없습니다.";
                        }
                    }
                    if (chooseNum == 2)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "먹어보고 싶은데… 잠깐 들르면 안될까요?";
                        PlayerState.Instance().hart += 100;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 100;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
            else
            {
                if (StoryNum == 0)
                {
                    if (chooseNum == 1)
                    {
                        chara[0].SetActive(false);
                        chara[5].SetActive(true);
                        nameTX.text = "나리";
                        storyTX.text = "저도 정말 좋아해요. 단 걸 좋아하는 사람은 마음이 따뜻한 사람이 많대요.";
                        PlayerState.Instance().hart += 150;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 150;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                    if (chooseNum == 2)
                    {
                        nameTX.text = "나리";
                        storyTX.text = "저는 좋아해요. 단 걸 먹으면 행복해지는 호르몬이 나오는데, \n단 걸 좋아하는 사람은 행복해지고 싶어서 좋아한다는 말도 있었어요. \n정말로 그런 걸까요?";
                        PlayerState.Instance().hart += 130;
                        PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                        PlayerState.Instance().accumhart += 130;
                        PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                        ChooseExit();
                    }
                }
            }
        }
    }
}
