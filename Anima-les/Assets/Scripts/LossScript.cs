using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LossScript : MonoBehaviour {
    public AudioClip musicSound;
    public AudioSource musicSource;

    private const int MAINMENUINDEX = 1;
    private const int PLAYINDEX = 2;

    public void Start()
    {
        musicSource.clip = musicSound;
        musicSource.Play();
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(MAINMENUINDEX);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(PLAYINDEX);
    }

}
