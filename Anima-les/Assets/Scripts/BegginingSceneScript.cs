using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BegginingSceneScript : MonoBehaviour {

    private const int MAINMENUINDEX = 0;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Wait());
        SceneManager.LoadScene(MAINMENUINDEX);

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10.0f);
    }
}
