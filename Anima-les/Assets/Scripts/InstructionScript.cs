using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InstructionScript : MonoBehaviour {
    private const int MAINMENUINDEX = 1;
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(MAINMENUINDEX);
    }
}
