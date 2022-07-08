using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    MyRayCast raycast;

    [SerializeField]
    private float moveSpeed;
    public float turnSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        raycast = GetComponent<MyRayCast>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        usingRaycast();
    }

    void FixedUpdate()
    {
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        rb.velocity = transform.forward * Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * turnSpeed, 0);
    }

    private void usingRaycast()
    {
        RaycastHit hit = raycast.TouchingObjects(10);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;

            if (obj != null)
            {
                ControlObjects ctrl = obj.GetComponent<ControlObjects>();
                if (ctrl != null)
                {
                    ctrl.isHittingObjects = true;
                }
            }
        }
    }
}
