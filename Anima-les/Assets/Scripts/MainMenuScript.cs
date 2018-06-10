using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public AudioClip musicSound;
    public AudioSource musicSource;
    private const int MAINMENUINDEX = 1;
    private const int INSTRUCTIONINDEX = 5;
    private const int PLAYINDEX = 2;

    public void Start()
    {
        musicSource.clip = musicSound;
        musicSource.Play();
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(PLAYINDEX);
    }

    public void InstructionsGame()
    {
        SceneManager.LoadScene(INSTRUCTIONINDEX);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
