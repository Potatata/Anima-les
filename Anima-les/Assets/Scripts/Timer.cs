using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float currentTime;
    public float x;
    public float y;
    public float height;
    public float width;
	// Use this for initialization
	void Start () {
        currentTime = 30.0f;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
        if(!(currentTime > 0) )
        {
            //Show end game screen death
        }
	}

    private void OnGUI()
    {
        GUI.Box(new Rect(x, y, width, height), ""+ currentTime.ToString("0"));
    }
}
