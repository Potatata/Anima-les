using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public int startingHealth = 3;                           
    public int currentHealth;

    void Start()
    {
        // Set the initial health of the player.
        currentHealth = startingHealth;
    }



    void reduceHeart()
    {
        --currentHealth;
    }
}
