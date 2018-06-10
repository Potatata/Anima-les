using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour {
    public AudioClip musicSound;
    public AudioSource musicSource;

    private const int MAINMENUINDEX = 1;

    // Use this for initialization
    void Start () {

        musicSource.clip = musicSound;
        musicSource.Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(MAINMENUINDEX);
    }
}
