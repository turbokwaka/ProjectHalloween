using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Transform _objectGrabPointTransform;
    private Rigidbody _objectRigidbody;

    public void Grab(Transform objectGrabPointTransform)
    {
        _objectGrabPointTransform = objectGrabPointTransform;
        _objectRigidbody = GetComponent<Rigidbody>();
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
