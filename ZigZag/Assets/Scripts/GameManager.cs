using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject ScoreTextGo;
    [SerializeField] GameObject retry;
    [SerializeField] GameObject quit;
    public TextMeshProUGUI scoreGameOver;
    public TextMeshProUGUI bestScore;
    private static GameManager instance;

    [HideInInspector]
    public bool isactive = false;

    int scoreInt;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    void Start()
    {

    }


    void Update()
    {

        score.text = score.text;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        if (isactive)
        {
            gameOver.SetActive(true);

            retry.SetActive(true);
            quit.SetActive(true);
            ScoreTextGo.SetActive(false);
            if (PlayerPrefs.GetInt("BestScore") < int.Parse(score.text))
            {

                PlayerPrefs.SetInt("BestScore", int.Parse(score.text));
            }
            scoreGameOver.text = "Score : " + score.text;
            bestScore.text = "Best : " + PlayerPrefs.GetInt("BestScore");

        }
        else
        {
            gameOver.SetActive(false);
            retry.SetActive(false);
            quit.SetActive(false);
            scoreGameOver.text = "";
            bestScore.text = "";
        }

    }

    public void OnClickRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
          Application.Quit();
#endif
    }
}
