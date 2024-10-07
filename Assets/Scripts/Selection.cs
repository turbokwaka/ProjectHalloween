using UnityEngine;

public class Selection : MonoBehaviour
{
    private GameObject _highlightedObject;
    private Outline _highlightedOutline;

    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public float maxRaycastDistance; // Adjust this value based on your game requirements

    void FixedUpdate()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,out RaycastHit hit, maxRaycastDistance))
        {
            // HIGHLIGHT OBJECT
            if (hit.collider.CompareTag("Selectable"))
            {
                var selectedObject = hit.collider.gameObject;

                // Only highlight if the hit object is within a reasonable distance and the object isn't already highlighted
                if (_highlightedObject != selectedObject && hit.distance <= maxRaycastDistance)
                {
                    RemoveHighlight(); // Remove the previous highlight if we switch to a new object

                    _highlightedObject = selectedObject;
                    _highlightedOutline = _highlightedObject.GetComponent<Outline>();

                    _highlightedOutline.OutlineWidth = 2f;
                }
            }
            else
            {
                RemoveHighlight(); // Remove highlight when no object is hit
            }
            
            // GRAB OBJECT
            if (hit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable) && Input.GetKeyDown(KeyCode.E))
            {
                objectGrabbable.Grab(objectGrabPointTransform);
                RemoveHighlight();
            }
        }
    }

    private void RemoveHighlight()
    {
        if (_highlightedObject != null && _highlightedOutline != null)
        {
            _highlightedOutline.OutlineWidth = 0; // Disable the outline
            _highlightedObject = null;
            _highlightedOutline = null;
        }
    }
}