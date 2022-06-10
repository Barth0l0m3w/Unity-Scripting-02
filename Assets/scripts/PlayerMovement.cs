using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float moveSpeed;
    public float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);

    }
}
