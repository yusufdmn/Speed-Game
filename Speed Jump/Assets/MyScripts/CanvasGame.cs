using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGame : MonoBehaviour
{

    public static bool isStarted;
    public static bool isFailed;
    public static bool isEnded;


    public Text textLevelEnd;
    public Text textScoreEnd;
    public Text textBestEnd;

    public Text textLevelGame;
    public Text textScoreGame;
    public GameObject textSwipeGame;
    public GameObject HandLine;

    public GameObject panelFail;
    public GameObject panelEnd;
    public GameObject panelFirst;

    int ads;

    float timer;
    public static int score;
    int bestScore;
    int level;
    int firstScore;

    public AdmobScriptt admobScript;

    private void Awake()
    {
        isStarted = false;
        isFailed = false;
        isEnded = false;
    }

    void Start()
    {

        ads = PlayerPrefs.GetInt("ads");

        textLevelEnd.text = "Level " + level.ToString();
        panelFail.SetActive(false);
        panelEnd.SetActive(false);


        level = PlayerPrefs.GetInt("level", 1);
        bestScore = PlayerPrefs.GetInt("best");
        firstScore = PlayerPrefs.GetInt("score");

        textScoreGame.text = firstScore.ToString();
        textLevelGame.text = "Level " + level.ToString();

        // SetTimeScale();

        Time.timeScale = 1.6f + firstScore * 0.001f;
        Debug.Log("scle: " + Time.timeScale);

    }


    void Update()
    {
        if (isStarted & !isFailed & !isEnded)
        {
            timer += Time.deltaTime * Time.timeScale * 10;
            score = firstScore + (int)timer;
            textScoreGame.text = score.ToString();

            if(score % 10 == 0)
            {
                Time.timeScale = 1.6f + score * 0.001f;
                Debug.Log("Scale: " + Time.timeScale);
            }
        }
    }

    public void RemoveSwipe()
    {
        HandLine.SetActive(false);
    }

    public void PopUpPanelFail()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("best", bestScore);
        }
        score = 0;
        PlayerPrefs.SetInt("score", score);
        panelFail.SetActive(true);
    }



    public void PopUpPanelEnd()
    {
        PlayerPrefs.SetInt("score", score);
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("best", bestScore);
        }

        textLevelEnd.text = "Level " + level.ToString();
        textScoreEnd.text = "Score:" + score.ToString();
        textBestEnd.text = "Best:" + bestScore.ToString();

        level++;
        PlayerPrefs.SetInt("level", level);

        panelEnd.SetActive(true);
        panelFirst.SetActive(false);
    }

    public void NextButton()
    {
        ads++;
        PlayerPrefs.SetInt("ads", ads);

        if (ads > 2)
        {
            ads = 0;
            PlayerPrefs.SetInt("ads", ads);
            admobScript.ShowAds();

        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    public void retryButton()
    {
        ads++;
        PlayerPrefs.SetInt("ads", ads);

        if (ads > 2)
        {
            ads = 0;
            PlayerPrefs.SetInt("ads", ads);
            admobScript.ShowAds();
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }

    void SetTimeScale()
    {
        if (firstScore < 200)
        {
            Time.timeScale = 1.5f;
        }
        else if (firstScore < 400)
        {
            Time.timeScale = 1.3f;
        }
        else if (firstScore < 600)
        {
            Time.timeScale = 1.4f;
        }
        else if (firstScore < 800)
        {
            Time.timeScale = 1.5f;
        }
        else if (firstScore < 1000)
        {
            Time.timeScale = 1.6f;
        }
        else if (firstScore < 1200)
        {
            Time.timeScale = 1.7f;
        }
        else if (firstScore < 1400)
        {
            Time.timeScale = 1.8f;
        }
        else if (firstScore < 1600)
        {
            Time.timeScale = 1.9f;
        }
        else if (firstScore < 1800)
        {
            Time.timeScale = 2f;
        }
        else if (firstScore < 2000)
        {
            Time.timeScale = 2.1f;
        }
        else if (firstScore < 2200)
        {
            Time.timeScale = 2.2f;
        }
        else
        {
            Time.timeScale = 2.5f;
        }
    }

}
