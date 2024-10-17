using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinScript : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _objectGrabPointTransform;
    public void Interact()
    {
        GetComponent<ObjectGrabbable>().Grab(_objectGrabPointTransform); 
    }
}
