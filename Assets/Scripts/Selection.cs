using UnityEngine;

public class Selection : MonoBehaviour
{
    private GameObject _highlightedObject;
    private Outline _highlightedOutline;

    public Transform playerCameraTransform;
    public float maxRaycastDistance = 5f;

    void Update()
    {
        // Cast a ray from the camera forward
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, maxRaycastDistance))
        {
            HandleHighlight(hit);
            HandleInteraction(hit);
        }
        else
        {
            RemoveHighlight();
        }
    }

    private void HandleHighlight(RaycastHit hit)
    {
        GameObject hitObject = hit.collider.gameObject;

        // Перевірка на наявність тега "Selectable"
        if (!hit.collider.CompareTag("Interactable"))
        {
            RemoveHighlight();
            return;
        }

        // Перевірка, чи об'єкт захоплений
        if (hit.collider.TryGetComponent(out ObjectGrabbable objectGrabbable) && objectGrabbable.IsGrabbed)
        {
            RemoveHighlight();
            return;
        }

        // Якщо це новий об'єкт для підсвічування
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


    private void HandleInteraction(RaycastHit hit)
    {
        // Check for the interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.TryGetComponent(out IInteractable objectInteractable))
            {
                objectInteractable.Interact();
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
