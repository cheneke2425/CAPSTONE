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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + moveOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);

        transform.position = smoothedPosition;

        Vector3 lookAtTarget = playerTransform.position + lookOffset;

        transform.LookAt(lookAtTarget);

    }
}
