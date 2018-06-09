using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    private const int MAINMENUINDEX = 0;
    private const int CREDITINDEX = 1;
    private const int PLAYINDEX = 2;

    public void PlayGame()
    {
        SceneManager.LoadScene(PLAYINDEX);
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene(CREDITINDEX);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
