using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HappyEnding : MonoBehaviour
{
    public GameObject textBox;
    public GameObject textwall;
    public TypewriterEffect storyEF;
    public UILabel nameTX;
    public UILabel storyTX;
    public int StoryNum;
    public bool storyFinish = false;
    public List<GameObject> charaImg;
    public int StartEnd;
    public GameObject happyendingArt;
    public UILabel endingTX;

    void Start ()
    {
        BGMSC.Instance().BGMSource.clip = BGMSC.Instance().HappyEnd;
        BGMSC.Instance().BGMSource.Play();
        StartEnd = PlayerPrefs.GetInt("HappyEnd");
        if (StartEnd == 1)
        {
            BGMSC.Instance().BGMSource.clip = BGMSC.Instance().HappyEndLast;
            BGMSC.Instance().BGMSource.Play();
            StoryNum = Random.Range(0, 5);
        }
        Story();
    }

    public void PassStory()
    {
        storyEF.Finish();
        storyFinish = true;
        textwall.SetActive(true);
    }
    public void NextStory()
    {
        if (storyFinish == true)
        {
            if (StartEnd == 0)
            {
                StoryNum += 1;
                Story();
                storyFinish = false;
                storyEF.ResetToBeginning();
            }
            if (StartEnd == 1)
            {
                StoryNum = Random.Range(0, 5);
                Story();
                storyFinish = false;
                storyEF.ResetToBeginning();
            }
        }
    }
    public void TextWallClick()
    {
        NextStory();
        textwall.SetActive(false);
    }

    void Story()
    {
        if (StartEnd == 0)
        {
            if (StoryNum == 0)
            {
                textBox.SetActive(true);
                charaImg[0].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "으음… 저 이상하진 않아요? \n교복을 너무 오랜만에 입어서….";
            }
            if (StoryNum == 1)
            {
                charaImg[0].SetActive(false);
                nameTX.text = PlayerPrefs.GetString("UserName");
                storyTX.text = "괜찮아, 잘 어울려. 머리도 예쁘게 했네.";
            }
            if (StoryNum == 2)
            {
                charaImg[0].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "솔직히 아직 조금 무서워요. \n또 이 방에 숨고 싶어질 지도 몰라요.";
            }
            if (StoryNum == 3)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "……하지만, 세상엔 제 생각보다 좋은 사람도 많았던 것 같아요.";
            }
            if (StoryNum == 4)
            {
                charaImg[1].SetActive(false);
                nameTX.text = PlayerPrefs.GetString("UserName");
                storyTX.text = "안타깝게도 모두가 잘 맞는 건 아니야. \n직접 부딪혀보지 않는 이상은 나와 맞는 사람을 알아보기도 쉽지 않고.";
            }
            if (StoryNum == 5)
            {
                charaImg[0].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "맞아요… 그래서 상처 받을 때도 많겠지만 희망을 가져 보려고 해요. \n나와 잘 맞는 사람을 만난다면 얼마나 행복해질 수 있는지 \n" + PlayerPrefs.GetString("UserName") + " 선생님을 만나고서 알게 됐으니까요.";
            }
            if (StoryNum == 6)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "기쁨도, 슬픔도, 함께 나눌 수 있는 누군가가 있다는 게 얼마나 행복한 일인지.";
            }
            if (StoryNum == 7)
            {
                charaImg[1].SetActive(false);
                charaImg[2].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = PlayerPrefs.GetString("UserName") + " 선생님, 절 위해 이렇게까지 애써주셔서 고마워요.";
            }
            if (StoryNum == 8)
            {
                nameTX.text = "나리";
                storyTX.text = "저 힘낼 테니까, 계속 지켜봐주세요.";
            }
            if (StoryNum == 9)
            {
                endingTX.text = PlayerPrefs.GetString("UserName");
                happyendingArt.SetActive(true); //해피엔딩 일러
                textBox.SetActive(false);
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(false);
                charaImg[2].SetActive(false);
                StartCoroutine(FadeDelay());
            }
        }
        if (StartEnd == 1)
        {
            textBox.SetActive(true);

            if (StoryNum == 0)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(true);
                charaImg[2].SetActive(false);
                nameTX.text = "나리";
                storyTX.text = PlayerPrefs.GetString("UserName") + " 선생님을 만나서 정말 다행이에요.";
            }
            if (StoryNum == 1)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(false);
                charaImg[2].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "이번에 같은 반 친구들이랑 카페베어에 갔는데, \n새로 나온 케이크가 정말 맛있었어요.";
            }
            if (StoryNum == 2)
            {
                charaImg[0].SetActive(true);
                charaImg[1].SetActive(false);
                charaImg[2].SetActive(false);
                nameTX.text = "나리";
                storyTX.text = "교복을 너무 오랜만에 입었더니 사이즈가…… \n역시 운동을 좀 해야겠죠? 건강을 위해서라도.";
            }
            if (StoryNum == 3)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(true);
                charaImg[2].SetActive(false);
                nameTX.text = "나리";
                storyTX.text = "맛있게 먹으면 0칼로리래요~ \n행복할때 나오는 호르몬이 살을 덜 찌게 만들어준대요. \n그러니까 " + PlayerPrefs.GetString("UserName") + " 선생님, 같이 디저트 먹으러 가실래요?";
            }
            if (StoryNum == 4)
            {
                charaImg[0].SetActive(false);
                charaImg[1].SetActive(false);
                charaImg[2].SetActive(true);
                nameTX.text = "나리";
                storyTX.text = "학교 끝나고 친구들이랑 시내에 가서 쇼핑했어요. \n너무 오랜만이라 설레기도 했고… 엄청 즐거웠어요.";
            }
        }
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(5f);
        StartEnd = 1;
        PlayerPrefs.SetInt("HappyEnd", StartEnd);
        SceneManager.LoadScene(0);
    }
}
