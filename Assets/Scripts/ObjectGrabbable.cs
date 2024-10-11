using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public Transform _objectGrabPointTransform;
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

    private void FixedUpdate()
    {
        if (_objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 targetPosition = _objectGrabPointTransform.position;

            // Smoothly move the object towards the target position
            _objectRigidbody.MovePosition(Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed));
        }
    }
}
