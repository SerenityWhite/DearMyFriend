using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftShopSC : MonoBehaviour
{
    public GameObject buyChoose;
    public GameObject buyComple;
    public UIGrid itemShopGrid;

    public List<UILabel> Cosmeitem;
    public List<UILabel> Fooditem;
    public List<UILabel> Lifeitem;
    int cosmeItemNum;
    int foodItemNum;
    int lifeItemNum;

    public UILabel BuyChooseTX;
    public UILabel BuyCompleTX;

    public List<int> cosmetic;
    public List<int> food;
    public List<int> life;

    void Start ()
    {

    }
	
	void Update ()
    {
        itemShopGrid.Reposition();
    }

    public void Cosmetic1() //블러셔
    {
        buyChoose.SetActive(true);
        cosmeItemNum = 1;
        BuyChooseTX.text = "[" + Cosmeitem[0].text + "]을 \n정말로 구매하시겠습니까?";
    }
    public void Food1() //코코아&크루아상
    {
        buyChoose.SetActive(true);
        foodItemNum = 1;
        BuyChooseTX.text = "[" + Fooditem[0].text + "]을 \n정말로 구매하시겠습니까?";
    }
    public void Food2() //생일케이크
    {
        buyChoose.SetActive(true);
        foodItemNum = 2;
        BuyChooseTX.text = "[" + Fooditem[1].text + "]을 \n정말로 구매하시겠습니까?";
    }
    public void Life1() //이어폰
    {
        buyChoose.SetActive(true);
        lifeItemNum = 1;
        BuyChooseTX.text = "[" + Lifeitem[0].text + "]을 \n정말로 구매하시겠습니까?";
    }
    public void Life2() //최신가요 음반
    {
        buyChoose.SetActive(true);
        lifeItemNum = 2;
        BuyChooseTX.text = "[" + Lifeitem[1].text + "]을 \n정말로 구매하시겠습니까?";
    }

    public void BuyOK()
    {
        buyChoose.SetActive(false);
        buyComple.SetActive(true);
        if (cosmeItemNum == 1)
        {
            if (PlayerState.Instance().money >= 4500)
            {
                PlayerState.Instance().money -= 4500;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                cosmetic[0] += 1;
                PlayerPrefs.SetInt("cosmetic[0]", cosmetic[0]);
                BuyCompleTX.text = "구매 완료";
            }
            else
            {
                BuyCompleTX.text = "보유한 돈이 부족해서 \n구매할 수 없습니다.";
            }
        }
        if (foodItemNum == 1)
        {
            if (PlayerState.Instance().money >= 7500)
            {
                PlayerState.Instance().money -= 7500;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                food[0] += 1;
                PlayerPrefs.SetInt("food[0]", food[0]);
                BuyCompleTX.text = "구매 완료";
            }
            else
            {
                BuyCompleTX.text = "보유한 돈이 부족해서 \n구매할 수 없습니다.";
            }
        }
        if (foodItemNum == 2)
        {
            if (PlayerState.Instance().money >= 20000)
            {
                PlayerState.Instance().money -= 20000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                food[1] += 1;
                PlayerPrefs.SetInt("food[1]", food[1]);
                BuyCompleTX.text = "구매 완료";
            }
            else
            {
                BuyCompleTX.text = "보유한 돈이 부족해서 \n구매할 수 없습니다.";
            }
        }
        if (lifeItemNum == 1)
        {
            if (PlayerState.Instance().money >= 10000)
            {
                PlayerState.Instance().money -= 10000;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                life[0] += 1;
                PlayerPrefs.SetInt("life[0]", life[0]);
                BuyCompleTX.text = "구매 완료";
            }
            else
            {
                BuyCompleTX.text = "보유한 돈이 부족해서 \n구매할 수 없습니다.";
            }
        }
        if (lifeItemNum == 2)
        {
            if (PlayerState.Instance().money >= 13900)
            {
                PlayerState.Instance().money -= 13900;
                PlayerPrefs.SetInt("money", PlayerState.Instance().money);
                life[1] += 1;
                PlayerPrefs.SetInt("life[1]", life[1]);
                BuyCompleTX.text = "구매 완료";
            }
            else
            {
                BuyCompleTX.text = "보유한 돈이 부족해서 \n구매할 수 없습니다.";
            }
        }
    }

    public void BuyNo()
    {
        buyChoose.SetActive(false);
    }

    public void BuyCompleOK()
    {
        buyComple.SetActive(false);
        cosmeItemNum = 0;
        foodItemNum = 0;
        lifeItemNum = 0;
    }
}