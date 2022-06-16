using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRayCast : MonoBehaviour
{
    public Transform castFrom;

    public RaycastHit TouchingObjects(float distance = 5f)
    {
        if (castFrom == null) return new RaycastHit();

        Vector3 origin = castFrom.position;
        Vector3 direction = castFrom.forward;
        Debug.DrawRay(origin, direction * 1000);
        RaycastHit hitInfo;

        Physics.Raycast(origin, direction, out hitInfo);
        return hitInfo;
    }
}
