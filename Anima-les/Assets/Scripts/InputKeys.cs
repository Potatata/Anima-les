using System;
using UnityEngine;
using System.Collections.Generic;


public class InputKeys
{
    private BodyParts bodyParts;
    private KeyCode keyCode;
    private char letter;

    public InputKeys(int currentBodyPart)
    {
        bodyParts = (BodyParts)currentBodyPart;
        generateLetter();
    }

    public void generateLetter ()
    {
        letter = (char) ('A'  + (int) UnityEngine.Random.Range(0, 27));
        Dictionary<char, KeyCode> hash = new Dictionary<char, KeyCode>();
        hash.Add('A', KeyCode.A);
        hash.Add('B', KeyCode.B);
        hash.Add('C', KeyCode.C);
        hash.Add('D', KeyCode.D);
        hash.Add('E', KeyCode.E);
        hash.Add('F', KeyCode.F);
        hash.Add('G', KeyCode.G);
        hash.Add('H', KeyCode.H);
        hash.Add('I', KeyCode.I);
        hash.Add('J', KeyCode.J);
        hash.Add('K', KeyCode.K);
        hash.Add('L', KeyCode.L);
        hash.Add('M', KeyCode.M);
        hash.Add('N', KeyCode.N);
        // @todo add all
    }

    public KeyCode GetKeyDownCode() { return keyCode; }
    public char getLetter() { return letter; }


}
