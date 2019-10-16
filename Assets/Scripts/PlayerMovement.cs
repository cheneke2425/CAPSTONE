using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myRB;
    private CapsuleCollider myCol;

    public LayerMask groundLayers;
    public float moveSpeed = 0f;
    public float jumpForce = 0f;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myCol = GetComponent<CapsuleCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        moveDirection *= moveSpeed;

        transform.position += moveDirection * Time.deltaTime;

    }

    void FixedUpdate()
    {
        if (isGrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Debug.Log("key pressed");
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
       return Physics.CheckCapsule(myCol.bounds.center,
            new Vector3(myCol.bounds.center.x, myCol.bounds.min.y, myCol.bounds.center.z), myCol.radius * 0.9f, groundLayers);
    }

}
