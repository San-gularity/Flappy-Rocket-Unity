using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    //public static bool GameIsOver = false;
    public new AudioPart audio;

    public GameObject GameOverMenuUI;
    public GameObject pointsTally;
    public GameObject Highscore;
    public GameObject HighscoreText;

    [SerializeField] private TextMeshProUGUI highText;

    private CreatingObjects pointss;


    public float highScore = 0;

    private void Start()
    {
        highText.text = PlayerPrefs.GetFloat("Highboi").ToString();
    }

    public void GameOverPart()
    {
        GameOverMenuUI.SetActive(true);
        pointss = GameObject.FindObjectOfType(typeof(CreatingObjects)) as CreatingObjects;
        if (pointss.GetHighscore() > PlayerPrefs.GetFloat("Highboi", 0))
        {
            highScore = pointss.GetHighscore();
            PlayerPrefs.SetFloat("Highboi", highScore);
            highText.text = highScore.ToString();
            //SaveData();
        }
        Highscore.SetActive(true);
        HighscoreText.SetActive(true);
        //pointsTally.SetActive(false);
        Invoke("StopTime", 0.6f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    public void PlayAgain()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
    }
    private void StopTime()
    {
        Time.timeScale = 0f;
        audio.Play("GameOverSound");
    }

    /*public void SaveData()
    {
        SaveSystem.SaveHighScore(this);
    }

    public void LoadData()
    {
        ScoreData data = SaveSystem.LoadScore();

        highScore = data.maxScore;
    }*/
}
