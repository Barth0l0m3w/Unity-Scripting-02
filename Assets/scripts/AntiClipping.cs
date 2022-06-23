using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiClipping : MonoBehaviour
{
    public LayerMask collidable;
    public new Collider collider;
    public float maxOffser = 0.05f;

    [HideInInspector] public bool blockedForward = false;
    [HideInInspector] public bool blockedUp = false;
    [HideInInspector] public bool blockedDown = false;
    [HideInInspector] public bool blockedBack = false;
    [HideInInspector] public bool blockedLeft = false;
    [HideInInspector] public bool blockedRight = false;

    // Update is called once per frame
    void Update()
    {

        blockedForward = StopMoving(Vector3.forward).collider != null;
        blockedUp = StopMoving(Vector3.up).collider != null;
        blockedDown = StopMoving(Vector3.down).collider != null;
        blockedBack = StopMoving(Vector3.back).collider != null;
        blockedLeft = StopMoving(Vector3.left).collider != null;
        blockedRight = StopMoving(Vector3.right).collider != null;
    }

    public RaycastHit StopMoving(Vector3 direction)
    {
        if (transform == null) return new RaycastHit();

        Vector3 origin = transform.position;
        RaycastHit hit;
        Physics.Raycast(origin, direction, out hit, collider.bounds.extents.x + maxOffser);
        

        return hit;
    }

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        
        Gizmos.DrawRay(origin, Vector3.up * (collider.bounds.extents.x + maxOffser));
        Gizmos.DrawRay(origin, Vector3.down * (collider.bounds.extents.x + maxOffser));
        Gizmos.DrawRay(origin, Vector3.left * (collider.bounds.extents.x + maxOffser));
        Gizmos.DrawRay(origin, Vector3.right * (collider.bounds.extents.x + maxOffser));
        Gizmos.DrawRay(origin, Vector3.forward * (collider.bounds.extents.x + maxOffser));
        Gizmos.DrawRay(origin, Vector3.back * (collider.bounds.extents.x + maxOffser));
    }
}
