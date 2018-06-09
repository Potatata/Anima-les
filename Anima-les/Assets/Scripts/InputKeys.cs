﻿using System;
using UnityEngine;
using System.Collections.Generic;


public class InputKeys
{
    private BodyParts bodyParts;
    private KeyCode keyCode;
    private char letter;

    public InputKeys()
    {
        generateLetter();
    }

    public void setBodyPart(BodyParts currentBodyPart)
    {
        bodyParts = (BodyParts)currentBodyPart;
    }

    public void generateLetter ()
    {
        letter = (char) ('A'  + (int) UnityEngine.Random.Range(0, 26));
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
         hash.Add('O', KeyCode.O);
         hash.Add('P', KeyCode.P);
         hash.Add('Q', KeyCode.Q);
         hash.Add('R', KeyCode.R);
         hash.Add('S', KeyCode.S);
         hash.Add('T', KeyCode.T);
         hash.Add('U', KeyCode.U);
         hash.Add('V', KeyCode.V);
         hash.Add('W', KeyCode.W);
         hash.Add('X', KeyCode.X);
         hash.Add('Y', KeyCode.Y);
         hash.Add('Z', KeyCode.Z);
         // Set the value
         keyCode = hash[letter];


    }

    public KeyCode GetKeyDownCode() { return keyCode; }
    public char getLetter() { return letter; }


}
