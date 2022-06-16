using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjects : MonoBehaviour
{
    public bool isHittingObjects = false;

    private Vector3 mOffset;
    private float mZCoord;

    void Update()
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
    }
}
