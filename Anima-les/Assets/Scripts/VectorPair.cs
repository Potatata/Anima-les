using UnityEngine;

public class VectorPair {


    private BodyParts bodyParts;
    private bool status;

    public VectorPair()
    {
        bodyParts =(BodyParts)Random.Range(0, 4);
        status = false;
    }

    public void SetBodyPart(BodyParts bp)
    {
        bodyParts = bp;
    }

    public void UsedSpot()
    {
        status = true;
    }

    public BodyParts GetBodyPart() { return bodyParts; }

    public bool GetStatus() { return status; }

}

