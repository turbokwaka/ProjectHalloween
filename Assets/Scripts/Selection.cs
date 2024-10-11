using UnityEngine;

public class Selection : MonoBehaviour
{
    private GameObject _highlightedObject;
    private Outline _highlightedOutline;

    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public float maxRaycastDistance = 5f; // You can adjust this value in the Inspector

    void Update()
    {
        // Cast a ray from the camera forward
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, maxRaycastDistance))
        {
            HandleHighlight(hit);
            HandleGrab(hit);
            HandeDrop(hit);
        }
        else
        {
            RemoveHighlight();
        }
    }

    private void HandleHighlight(RaycastHit hit)
    {
        // Check if the hit object is selectable
        if (hit.collider.CompareTag("Selectable") && !hit.collider.GetComponent<ObjectGrabbable>()._objectGrabPointTransform)
        {
            GameObject hitObject = hit.collider.gameObject; 

            // If we're pointing at a new object, update the highlight
            if (_highlightedObject != hitObject)
            {
                RemoveHighlight();

                _highlightedObject = hitObject;
                _highlightedOutline = _highlightedObject.GetComponent<Outline>();

                if (_highlightedOutline != null)
                {
                    _highlightedOutline.OutlineWidth = 6f;
                }
            }
        }
        else
        {
            RemoveHighlight();
        }
    }

    private void HandleGrab(RaycastHit hit)
    {
        // Check for the grab input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                objectGrabbable.Grab(objectGrabPointTransform);
            }
        }
    }

    private void HandeDrop(RaycastHit hit)
    {
        // Check for the grab input
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (hit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
            {
                objectGrabbable.Drop();
            }
        }
    }

    private void RemoveHighlight()
    {
        if (_highlightedOutline != null)
        {
            _highlightedOutline.OutlineWidth = 0;
        }

        _highlightedObject = null;
        _highlightedOutline = null;
    }
}
