using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    public GameObject chara;
    public GameObject blood;
    public GameObject badEnding;
    public GameObject gameOver;
    
	void Start ()
    {
        PlayerPrefs.DeleteAll();
        chara.SetActive(true);
    }

    public void CharaEnd()
    {
        blood.SetActive(true);
    }

    public void BloodEnd()
    {
        chara.SetActive(false);
        badEnding.SetActive(true);
    }

    public void EndingEnd()
    {
        badEnding.SetActive(false);
        gameOver.SetActive(true);
    }

    public void GameOverEnd()
    {
        StartCoroutine(FadeDelay());
    }

    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
