using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookInCamera : MonoBehaviour
{
    public Transform objectLookAt; 
    void Update()
    {
        // Smoothly rotate the object to face the camera
        var lookPos = objectLookAt.position - transform.position;
        lookPos.y = 0; // Keep the rotation on the horizontal plane
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * 10);
    }
}
