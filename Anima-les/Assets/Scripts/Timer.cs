using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float x = Screen.width - Screen.width/10;
    private float y = Screen.height/2;
    private float height;
    private float width;
    public float currentTime;

    // Use this for initialization
    void Start () {
        width = Screen.width / 16;
        height = Screen.height / 16;
        x = Screen.width - Screen.width *2/15;
        y = Screen.height / 2 - Screen.height/42;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(x, y, width, height), ""+ currentTime.ToString("0"));
    }
}
