using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGameScipt : MonoBehaviour {

    public GameObject Health1, Health2, Health3, Timer, Witch, GameBar, /*Witch,*/ Potion/*, GameOver, Win*/;
    public static int healthByGame = 3;
    public static int potionTriesPerGame = 3;
    public static int numberOfTilesToComplete = 40;
    public int currentHealth = 3;
    public float timeToDestroy;
	// Use this for initialization
	void Start ()
    {
        currentHealth = healthByGame;
        Health1.SetActive(true);
        Health2.SetActive(true);
        Health3.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
        if()
        // Reduce the amount of hearts in the game
        --currentHealth;
        //Update the hearts and check if there was a gameover
        switch (currentHealth)
        {
            case 2:
                Destroy(Health1, timeToDestroy);
                break;
            case 1:
                Destroy(Health2, timeToDestroy);
                break;
            case 0:
                Destroy(Health3, timeToDestroy);

                break;
        }

    }
}
