using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    private int animalForTheTurn;
    private InputKeys [] keySettings;

    // Use this for initialization
    private void Start () {
        //gets which animal we will do
        animalForTheTurn = (int) Random.Range(0, 4);
        //generate which letter is destined to each animal
        keySettings = new InputKeys[4];
        // Check there is no repeated values and if there is, correct it
        Dictionary<char, byte> hash = new Dictionary<char, byte>();
        hash.Add(keySettings[0].getLetter(), 0);
        // Check the rest of the hash map
        for (int index = 1 ; index <4  ;  ++index)
        {
            //While it is a key that is in the hash map, get another one
            while (hash.ContainsKey(keySettings[index].getLetter()))
                keySettings[index].generateLetter();
            hash.Add(keySettings[index].getLetter(), 0);
        }

        // Generate the gamebar

    }

    public void ShowGame()
    {

    }

    public void Update()
    {

    }


    private void ShowGameMenu()
    {

    }

    private void RemoveGameMenu()
    {

    }

}
