using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGameScipt : MonoBehaviour {

    public GameObject Health1, Health2, Health3, Timer, Witch, GameBar, /*Witch,*/ Potion/*, GameOver, Win*/, MagicFraskIconFull, MagicFraskIconHalfFull, MagicFraskIconNotVeryEmpty, MagicFraskIconEmpty;
    public const int HEALTHBYGAME = 3;
    public const int POTIONBYMATCH = 3;
    public const int NUMBEROFTILESTOCOMPLETE = 40;

    public int currentHealth;
    public int potionLevel;

    private int currentNumberOfTiles;
    private int animalForTheTurn;
    private int pointerInArray;

    private InputKeys[] keySettings;
    private VectorPair[] currentTilesToDo;

    void Start ()
    {   
        // set the health
        currentHealth = HEALTHBYGAME;

        //gets which animal we will do
        animalForTheTurn = (int)Random.Range(0, 4);
        //generate which letter is destined to each body part
        keySettings = new InputKeys[4];

        // Check there is no repeated values and if there is, correct it
        Dictionary<char, byte> hash = new Dictionary<char, byte>();
        hash.Add(keySettings[0].getLetter(), 0);
        // Check the rest of the hash map
        for (int index = 1; index < 4; ++index)
        {
            //While it is a key that is in the hash map, get another one
            while (hash.ContainsKey(keySettings[index].getLetter()))
                keySettings[index].generateLetter();
            hash.Add(keySettings[index].getLetter(), 0);
        }

        //Set variables for the beggining of the game
        setGameBeggining();
    }

    // Update is called once per frame
    void Update () {
        //Check if we have the correct key or is it a tab
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //Check if it can check it's potion level
            if(potionLevel!=0)
            {
                --potionLevel;
                //If it can, update one of the potion level stuff 
                switch (potionLevel)
                {
                    case 2:
                        MagicFraskIconFull.SetActive(false);
                        MagicFraskIconHalfFull.SetActive(true);
                        break;
                    case 1:
                        MagicFraskIconHalfFull.SetActive(false);
                        MagicFraskIconNotVeryEmpty.SetActive(true);
                        break;
                    case 0:
                        MagicFraskIconNotVeryEmpty.SetActive(false);
                        MagicFraskIconEmpty.SetActive(true);
                        break;
                }

                //Show the screen while a key is pressed
                
            }
        }
        //Check if we got the correct input
        else
        {
            // If it is an escape, return to the main menu
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                //@TODO GO TO MAIN MENU
            }
            else
            {
                KeyCode currentKey = keySettings[(int)currentTilesToDo[pointerInArray].GetBodyPart()].GetKeyDownCode();

                //If it is the correct key we continue the game without any problem
                if (Input.GetKeyDown(currentKey))
                {
                    ++currentNumberOfTiles;
                    ++pointerInArray;
                    // If you finished the row
                    if (pointerInArray == 4)
                    {
                        getNextFour();
                    }
                    if (NUMBEROFTILESTOCOMPLETE == currentNumberOfTiles)
                    {
                        //GAME END GOOD
                    }
                }
                //If it is the incorrect key, we have to reduce a life and check if we have a gameover
                // Reduce the amount of hearts in the game
                --currentHealth;
                //Update the hearts and check if there was a gameover
                switch (currentHealth)
                {
                    case 2:
                        Health1.SetActive(false);
                        break;
                    case 1:
                        Health2.SetActive(false);
                        break;
                    case 0:
                        Health3.SetActive(false);
                        // Finish the game
                        break;
                }

            }

        }
    }
    private void getNextFour()
    {
        pointerInArray = 0;
        // Generate the body parts
        for (int index = 0; index < 4; ++index, currentTilesToDo[index].SetBodyPart((BodyParts)Random.Range(0, 4))) ;

    }

    private void setGameBeggining()
    {
        //Set all game hearts
        Health1.SetActive(true);
        Health2.SetActive(false);
        Health3.SetActive(false);


        // Set all flasks
        MagicFraskIconFull.SetActive(true);
        MagicFraskIconHalfFull.SetActive(false);
        MagicFraskIconNotVeryEmpty.SetActive(false);
        MagicFraskIconEmpty.SetActive(false);

    }

}
