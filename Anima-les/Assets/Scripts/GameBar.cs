using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameBar : MonoBehaviour {
    private const int TILESNEEDEDTOFINISH = 40;


    private int currentLetters;
    private int pointerInArray;
    private VectorPair[] currentTilesToDo;
    private InputKeys[] keySettings;

    // Use this for initialization
    public void Start ()
    {
        currentTilesToDo = new VectorPair[4];
    }

    public void passParameters(InputKeys[] keyPassSettings)
    {
        keySettings = keyPassSettings;
    }

    public void getNextFour()
    {
        pointerInArray = 0;
        // Generate the body parts
        for (int index = 0; index < 4; ++index, currentTilesToDo[index].SetBodyPart((BodyParts)Random.Range(0, 4))) ;

    }

    // Update is called once per frame
    public void Update ()
    {
        KeyCode currentKey = keySettings[(int) currentTilesToDo[pointerInArray].GetBodyPart()].getKeyCode();
        ///Check if the correct key was pressed
		if (Input.GetKey(currentKey))
        {
            ++currentLetters;
            //If it was the key, that means we are good
            ++pointerInArray;
            // If you are better the next
            if(pointerInArray ==4)
            {
                getNextFour();
            }
            if(TILESNEEDEDTOFINISH == currentLetters)
            {
                //GAME END GOOD
            }
        }
        else
        {
            //REDUCE ONE HEALTH BAR

        }
	}
}
