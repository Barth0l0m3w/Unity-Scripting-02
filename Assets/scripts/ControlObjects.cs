using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjects : MonoBehaviour
{
    private AntiClipping[] antiClippings = null;

    public bool isHittingObjects = false;

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 previousPosition;

    private void Start()
    {
        //get the infor for all the raycasts that are in the object
        antiClippings = GetComponentsInChildren<AntiClipping>();
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

        //when dragging the object turn mouselocked off
        Cursor.lockState = CursorLockMode.None;

        //offset of the z is static with how far away the player is from the object
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //updating the position when dragging the mouse
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
            //turn mouselocked on again after beging done dragging objects
            Cursor.lockState = CursorLockMode.Locked;
        }
        isHittingObjects = false;
    }

    private void BlockMovement()
    {
        //make sure the boolians turn false again 
        bool blockForward = false;
        bool blockBackward  = false;
        bool blockUp = false;
        bool blockDown = false;
        bool blockLeft = false;
        bool blockRight = false;

        foreach(AntiClipping clipping in antiClippings)
        {
            if (clipping.blockedForward)
            {
                blockForward = true;
            }
            if (clipping.blockedBack)
            {
                blockBackward = true;
            }
            if (clipping.blockedUp)
            {
                blockUp = true;
            }
            if (clipping.blockedDown)
            {
                blockDown = true;
            }
            if (clipping.blockedLeft)
            {
                blockLeft = true;
            }
            if (clipping.blockedRight)
            {
                blockRight = true;
            }
        }

        //if the ray is hit and you try to drag the object further it will jump back to the previous position so it doesnt clip
        //forwards and backwards
        if (blockForward && (transform.position.z > previousPosition.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, previousPosition.z);
        }
        if (blockBackward && (transform.position.z < previousPosition.z))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, previousPosition.z);
        }

        //up and down
        if (blockUp && (transform.position.y > previousPosition.y))
        {
            transform.position = new Vector3(transform.position.x, previousPosition.y, transform.position.z);
        }
        if (blockDown && (transform.position.y < previousPosition.y))
        {
            transform.position = new Vector3(transform.position.x, previousPosition.y, transform.position.z);
        }

        //right and left
        if (blockLeft && (transform.position.x > previousPosition.x))
        {
            transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
        }
        if (blockRight && (transform.position.x < previousPosition.x))
        {
            transform.position = new Vector3(previousPosition.x, transform.position.y, transform.position.z);
        }
    }
}
