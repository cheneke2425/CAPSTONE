using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform;
    //public Transform lookAtTarget;
    public float speed = 0f;
    public Vector3 moveOffset;
    public Vector3 lookOffset;

    private bool hitBoundary = false;
    private Rigidbody camRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        camRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (hitBoundary == true)
        {
            StayInBoundary();
        } else
        {
            CamFollow();
        }

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            hitBoundary = true;
        }

    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            hitBoundary = false;
        }
    }

    private void CamFollow()
    {
        Vector3 desiredPosition = playerTransform.position + moveOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);

        transform.position = smoothedPosition;

        Vector3 lookAtTarget = playerTransform.position + lookOffset;

        transform.LookAt(lookAtTarget);
    }

    private void StayInBoundary()
    {
        Vector3 desiredPosition = playerTransform.position + moveOffset;
        Vector3 lookAtTarget = playerTransform.position + lookOffset;

        if (desiredPosition.x >= transform.position.x)
        {
            desiredPosition -= moveOffset;
            lookAtTarget -= lookOffset;
        }
        else
        {

        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);

        transform.position = smoothedPosition;

        transform.LookAt(lookAtTarget);
    }
}
