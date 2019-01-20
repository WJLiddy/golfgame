using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI
{
    // returns a normalized vector from origin to target.
    public static Vector3 returnBestPathToTarget(Vector3 origin, Vector3 target)
    {
        Ray r = new Ray(origin, target - origin);
        RaycastHit rh;
        // ignore player and enemy layers
 
        bool hit = Physics.Raycast(r.origin, r.direction, out rh, Mathf.Infinity, ~(1 << LayerMask.NameToLayer("Enemy")));
        if (hit && rh.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            return (target - origin).normalized;
            // Begin by seeing if we can reach the target directly.
        }
        return Vector2.zero;
    }
}
