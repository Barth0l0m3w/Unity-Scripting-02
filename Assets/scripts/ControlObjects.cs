using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjects : MonoBehaviour
{
    public bool isHittingObjects = false;

    private Vector3 mOffset;
    private float mZCoord;
    AntiClipping antiClipping;
    Vector3 previousPosition;

    private void Start()
    {
        antiClipping = GetComponent<AntiClipping>();
    }

    void Update()
    {
        DraggObjects();
        previousPosition = transform.position;
    }

    //getting the information about where the cube is
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        //offset of the z is static with how far away the player is from the object
        mousePoint.z = mZCoord;
        Cursor.lockState = CursorLockMode.None;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //updating the position when dtagging the mouse
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        BlockMovement();
    }

    private void DraggObjects()
    {

        //when the rarcast has hit the object activate this function
        if (isHittingObjects && Input.GetMouseButtonDown(0))
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        isHittingObjects = false;
    }

    private void BlockMovement()
    {
        //if the ray is hit and you try to drag the object further it will jump back to the previous position so it doesnt clip
        //forwards and backwards
        if (antiClipping.blockedForward && (transform.position.z > previousPosition.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, previousPosition.z);
        }
        if (antiClipping.blockedBack && (transform.position.z < previousPosition.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, previousPosition.z);
        }

        //up and down
        if (antiClipping.blockedUp && (transform.position.y > previousPosition.y))
        {
            transform.position = new Vector3(transform.position.x, previousPosition.y, transform.position.z);
        }
        if (antiClipping.blockedDown && (transform.position.y < previousPosition.y))
        {
            transform.position = new Vector3(transform.position.x, previousPosition.y, transform.position.z);
        }

        //right and left
        if (antiClipping.blockedRight && (transform.position.x > previousPosition.x))
        {
            transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
        }
        if (antiClipping.blockedRight && (transform.position.x < previousPosition.x))
        {
            transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
        }
    }
}
