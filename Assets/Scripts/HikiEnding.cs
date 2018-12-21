using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HikiEnding : MonoBehaviour
{
    public GameObject chara;
    public GameObject badEnding;
    public GameObject badEnding02;
    public GameObject gameOver;

	void Start ()
    {
        PlayerPrefs.DeleteAll();
        chara.SetActive(true);
    }

    public void CharaEnd()
    {
        badEnding.SetActive(true);
    }

    public void BadEndingEnd()
    {
        badEnding.SetActive(false);
        badEnding02.SetActive(true);
    }

    public void BadEndingEnd02()
    {
        badEnding02.SetActive(false);
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
