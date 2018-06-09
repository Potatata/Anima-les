public class VectorPair {


    private BodyParts bodyParts;
    private bool status;

    public VectorPair(BodyParts bp)
    {
        bodyParts = bp;
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

