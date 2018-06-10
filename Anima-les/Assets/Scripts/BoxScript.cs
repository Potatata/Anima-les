using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    [SerializeField]
    private GameObject _pendingBackgroundObject;

    [SerializeField]
    private GameObject _finishedBackgroundObject;

    [SerializeField]
    private List<GameObject> _bodyPartsObjects;

    public void SetPendingState(bool pPending)
    {
        if(pPending)
        {
            _pendingBackgroundObject.SetActive(true);
            _finishedBackgroundObject.SetActive(false);
        }
        else
        {
            _pendingBackgroundObject.SetActive(false);
            _finishedBackgroundObject.SetActive(true);
        }
    }

    public void SetBodyPart(BodyParts pBodyPart)
    {
        for (int i = 0; i < _bodyPartsObjects.Count; i++)
        {
            _bodyPartsObjects[i].SetActive(false);
        }

        _bodyPartsObjects[(int)pBodyPart].SetActive(true);
    }
}
