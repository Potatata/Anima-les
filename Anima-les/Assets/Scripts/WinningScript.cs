using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour {

    private const int MAINMENUINDEX = 1;

    // Use this for initialization
    void Start () {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene(MAINMENUINDEX);
    }
}
