using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMover : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Common.inst.player.GetComponent<Player>().targVec = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            Physics.Raycast(r.origin, r.direction, out rh, Mathf.Infinity);

            if (rh.collider != null)
            {
                Vector3 collide = rh.point;
                Vector3 dir = rh.point - this.transform.position;
                Common.inst.player.GetComponent<Player>().targVec = dir.normalized; // allow fine control
            }
        }
    }
}
