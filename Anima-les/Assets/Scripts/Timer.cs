using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float x;
    public float y;
    public float height;
    public float width;
    public float currentTime;

    // Use this for initialization
    void Start () {
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
