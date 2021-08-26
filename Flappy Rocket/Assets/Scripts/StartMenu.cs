using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public new AudioPart audio;

    public void Playit()
    {
        audio.Play("ClickSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        audio.Play("ClickSound");
        Application.Quit();
    }
}
