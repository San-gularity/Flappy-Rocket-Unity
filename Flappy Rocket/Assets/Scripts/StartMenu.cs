using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public new AudioPart audio;

    // Optional: drop the Quit button here in the inspector. Left empty, the
    // scene's "QuitButton" object is found by name instead.
    [SerializeField] private GameObject quitButton;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // Application.Quit() does nothing in a browser, so the button would be
        // a dead end. Hide it rather than leave something that visibly fails.
        GameObject quit = quitButton != null ? quitButton : GameObject.Find("QuitButton");
        if (quit != null) quit.SetActive(false);
#endif
    }

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
