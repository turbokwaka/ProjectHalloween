using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public Transform _objectGrabPointTransform;
    public Transform _objectLookAt;
    private Rigidbody _objectRigidbody;

    public void Grab(Transform objectGrabPointTransform)
    {
        _objectGrabPointTransform = objectGrabPointTransform;
        _objectRigidbody = GetComponent<Rigidbody>();
        
        _objectRigidbody.useGravity = false;
        _objectRigidbody.velocity = Vector3.zero;
    }

    public void Drop()
    {
        _objectRigidbody.useGravity = true;
        _objectGrabPointTransform = null;
    }
    
    private void Update()
    {
        if (_objectGrabPointTransform)
        {
            float moveSpeed = 5f;
            Vector3 targetPosition = _objectGrabPointTransform.position;

            // Smoothly move the object to a crosshair
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            
            // Smoothly rotate the object to face the camera
            var lookPos = _objectLookAt.position - transform.position;
            lookPos.y = 0; // Keep the rotation on the horizontal plane
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * moveSpeed);
        }
    }

}
