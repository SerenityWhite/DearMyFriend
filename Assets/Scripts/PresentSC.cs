using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentSC : MonoBehaviour
{
    public UIGrid itemBagGrid;
    public List<GameObject> cosmeticItem;
    public List<GameObject> foodItem;
    public List<GameObject> lifeItem;

    public List<UILabel> CosmeitemTX;
    public List<UILabel> FooditemTX;
    public List<UILabel> LifeitemTX;

    public GameObject systemMassage;
    public UILabel systemMassageTX;
    public GameObject presentOK;
    public UILabel presentOKTX;

    public List<int> cosmetic;
    public List<int> food;
    public List<int> life;
    public List<UILabel> cosmeticTX;
    public List<UILabel> foodTX;
    public List<UILabel> lifeTX;
    int cosmeItemNum;
    int foodItemNum;
    int lifeItemNum;

    void Start ()
    {

    }
	
	void Update ()
    {
        itemBagGrid.Reposition();

        cosmetic[0] = PlayerPrefs.GetInt("cosmetic[0]");
        food[0] = PlayerPrefs.GetInt("food[0]");
        food[1] = PlayerPrefs.GetInt("food[1]");
        life[0] = PlayerPrefs.GetInt("life[0]");
        life[1] = PlayerPrefs.GetInt("life[1]");

        cosmeticTX[0].text = "" + cosmetic[0];
        foodTX[0].text = "" + food[0];
        foodTX[1].text = "" + food[1];
        lifeTX[0].text = "" + life[0];
        lifeTX[1].text = "" + life[1];
    }

    public void PresentOK()
    {
        systemMassage.SetActive(false);
        presentOK.SetActive(true);
        if (cosmeItemNum == 1)
        {
            if(cosmetic[0] > 0)
            {
                cosmetic[0] -= 1;
                PlayerPrefs.SetInt("cosmetic[0]", cosmetic[0]);
                PlayerState.Instance().hart += 45;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                PlayerState.Instance().accumhart += 45;
                PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                presentOKTX.text = "감사합니다.\n(Happy가 45 증가하였습니다.)";
            }
            else
            {
                presentOKTX.text = "줄 수 있는 선물이 없네요.";
            }
        }
        if (foodItemNum == 1)
        {
            if (food[0] > 0)
            {
                food[0] -= 1;
                PlayerPrefs.SetInt("food[0]", food[0]);
                PlayerState.Instance().hart += 75;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                PlayerState.Instance().accumhart += 75;
                PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                presentOKTX.text = "잘 먹겠습니다.\n(Happy가 75 증가하였습니다.)";
            }
            else
            {
                presentOKTX.text = "줄 수 있는 선물이 없네요.";
            }
        }
        if (foodItemNum == 2)
        {
            if (food[1] > 0)
            {
                food[1] -= 1;
                PlayerPrefs.SetInt("food[1]", food[1]);
                PlayerState.Instance().hart += 200;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                PlayerState.Instance().accumhart += 200;
                PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                presentOKTX.text = "전혀 생각지도 못했어요.\n(Happy가 200 증가하였습니다.)";
            }
            else
            {
                presentOKTX.text = "줄 수 있는 선물이 없네요.";
            }
        }
        if (lifeItemNum == 1)
        {
            if(life[0] > 0)
            {
                life[0] -= 1;
                PlayerPrefs.SetInt("life[0]", life[0]);
                PlayerState.Instance().hart += 100;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                PlayerState.Instance().accumhart += 100;
                PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                presentOKTX.text = "잘 쓸게요.\n(Happy가 100 증가하였습니다.)";
            }
            else
            {
                presentOKTX.text = "줄 수 있는 선물이 없네요.";
            }
        }
        if (lifeItemNum == 2)
        {
            if(life[1] > 0)
            {
                life[1] -= 1;
                PlayerPrefs.SetInt("life[1]", life[1]);
                PlayerState.Instance().hart += 139;
                PlayerPrefs.SetFloat("hart", PlayerState.Instance().hart);
                PlayerState.Instance().accumhart += 139;
                PlayerPrefs.SetFloat("accumhart", PlayerState.Instance().accumhart);
                presentOKTX.text = "좋아하는 곡이에요. 잘 들을게요.\n(Happy가 139 증가하였습니다.)";
            }
            else
            {
                presentOKTX.text = "줄 수 있는 선물이 없네요.";
            }
        }
    }

    public void PresentNo()
    {
        systemMassage.SetActive(false);
    }

    public void PresentComple()
    {
        cosmeItemNum = 0;
        foodItemNum = 0;
        lifeItemNum = 0;
        presentOK.SetActive(false);
    }

    public void Cosmetic1() //블러셔
    {
        systemMassage.SetActive(true);
        cosmeItemNum = 1;
        systemMassageTX.text = "선택하신 [" + CosmeitemTX[0].text + "]을 \n정말로 선물하시겠습니까?";
    }
    public void Food1() //코코아&크루아상
    {
        systemMassage.SetActive(true);
        foodItemNum = 1;
        systemMassageTX.text = "선택하신 [" + FooditemTX[0].text + "]을 \n정말로 선물하시겠습니까?";
    }
    public void Food2() //생일케이크
    {
        systemMassage.SetActive(true);
        foodItemNum = 2;
        systemMassageTX.text = "선택하신 [" + FooditemTX[1].text + "]을 \n정말로 선물하시겠습니까?";
    }
    public void Life1() //이어폰
    {
        systemMassage.SetActive(true);
        lifeItemNum = 1;
        systemMassageTX.text = "선택하신 [" + LifeitemTX[0].text + "]을 \n정말로 선물하시겠습니까?";
    }
    public void Life2() //최신가요 음반
    {
        systemMassage.SetActive(true);
        lifeItemNum = 2;
        systemMassageTX.text = "선택하신 [" + LifeitemTX[1].text + "]을 \n정말로 선물하시겠습니까?";
    }
}
