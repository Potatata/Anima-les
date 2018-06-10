using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LossScript : MonoBehaviour {
    private const int MAINMENUINDEX = 1;
    private const int PLAYINDEX = 2;


    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(MAINMENUINDEX);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(PLAYINDEX);
    }

}
