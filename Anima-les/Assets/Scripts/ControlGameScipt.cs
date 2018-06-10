using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControlGameScipt : MonoBehaviour {
    //Constants
    private const int MAINMENUINDEX = 0;
    private const int WINNINGSCREEN = 3;
    private const int LOSSSCREEN = 4;
    public const int NUMBEROFTILESTOCOMPLETE = 40;

    // Constants place in screen
    private const int PLACESQUARE1 = 30;
    private const int PLACESQUARE2 = 60;
    private const int PLACESQUARE3 = 90;
    private const int PLACESQUARE4 = 120;


    //References
    public GameObject Health1, Health2, Health3, Timer, Witch, GameBar;
    public GameObject MagicFraskIconFull, MagicFraskIconHalfFull, MagicFraskIconNotVeryEmpty, MagicFraskIconEmpty, KeysCanvas, GameCanvas;
    
    //Health in the game
    public int currentHealth;
    public int potionLevel;
    public Text printTextKeys;
    public float timeTextKeysFirstTime;
    public float timeTextKeysOtherTimes;
    public float currentTime;


    //Private variables
    private int currentNumberOfTiles;
    private int animalForTheTurn;
    private int pointerInArray;
    private bool isInKeyCanvas;

    // Data arrays
    private InputKeys[] keySettings;
    private VectorPair[] currentTilesToDo;

    [SerializeField]
    private List<BoxScript> _boxes;

    void Start ()
    {   

        //instance variables and arrays
        keySettings = new InputKeys[4];
        currentTilesToDo = new VectorPair[4];
        pointerInArray = 0;
        isInKeyCanvas = false;
        //generate which letter is destined to each body part

        // Check there is no repeated values and if there is, correct it
        Dictionary<char, byte> hash = new Dictionary<char, byte>();
        // Check the rest of the hash map
        for (int index = 0; index < 4; ++index)
        {
            keySettings[index] = new InputKeys();
            currentTilesToDo[index] = new VectorPair();

            _boxes[index].SetPendingState(true);
            _boxes[index].SetBodyPart(currentTilesToDo[index].GetBodyPart());
            //Set the body part value
            keySettings[index].setBodyPart((BodyParts)(index));
            //While it is a key that is in the hash map, get another one
            while (hash.ContainsKey(keySettings[index].getLetter()))
                keySettings[index].generateLetter();
            hash.Add(keySettings[index].getLetter(), 0);
        }

        //Set variables for the beggining of the game
        setValues();


        // Save the text for the KeysMenu

        string stringText = keySettings[0].getLetter().ToString() + "\t\t\t" + keySettings[1].getLetter().ToString() + "\t\t\t\t" + keySettings[2].getLetter().ToString() + "\t\t\t\t" + keySettings[3].getLetter().ToString();

        printTextKeys.text = stringText;

        //Show key screen for some seconds
        StartCoroutine(ShowSubMenu(timeTextKeysFirstTime));
    }

    IEnumerator ShowSubMenu(float value)
    {
        KeysCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        isInKeyCanvas = true;
        yield return new WaitForSeconds(value);
        KeysCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        isInKeyCanvas = false;
    }

    // Update is called once per frame
    void Update () {
        currentTime -= Time.deltaTime;
        //Check if there still has been no timeout
        if (currentTime < 0.0f)
            SceneManager.LoadScene(LOSSSCREEN);
        //If there was any kind of input
        if (Input.anyKeyDown)
        {
            // If it is in keycanvas, don't do anthing this turn
            if (isInKeyCanvas)
                return;
            //Check if we have the correct key or is it a tab
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                potionSet();
            }
            else
            {
                // If it is an escape, return to the main menu
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    // Go to main menu
                    SceneManager.LoadScene(MAINMENUINDEX);
                }
                else
                {
                    KeyCode currentKey = keySettings[(int)currentTilesToDo[pointerInArray].GetBodyPart()].GetKeyDownCode();
                    //If it is the correct key we continue the game without any problem
                    if (Input.GetKeyDown(currentKey))
                    {
                        _boxes[pointerInArray].SetPendingState(false);
                        ++currentNumberOfTiles;
                        ++pointerInArray;

                        // If you finished the game
                        if (NUMBEROFTILESTOCOMPLETE == currentNumberOfTiles)
                        {
                            SceneManager.LoadScene(WINNINGSCREEN);
                        }
                        // If you finished the row genereta the next four ones
                        if (pointerInArray == 4)
                        {
                            getNextFour();
                        }
                    }
                    // if it isn't the correct key, penalty
                    else
                    {
                        HealthSet();
                    }
                }

            }
        }
    }

    private void getNextFour()
    {
        pointerInArray = 0;
        // Generate the body parts
        for (int index = 0; index < 4; ++index)
        {
            currentTilesToDo[index].SetBodyPart((BodyParts)Random.Range(0, 4));
            //Get the body part that needs to be done
            BodyParts bp = (currentTilesToDo[index].GetBodyPart());
            //Put each in screen
            Debug.Log(keySettings[(int) bp].getLetter());
        }
    }

    private void setValues()
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

    private void potionSet ()
    {
        //Check if it can check it's potion level
        if (potionLevel != 0)
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
            ShowSubMenu(timeTextKeysOtherTimes);
        }
    }

    private void HealthSet()
    {
        Debug.Log("Perdi un punto");
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
                SceneManager.LoadScene(LOSSSCREEN);
                break;
        }
    }

}
