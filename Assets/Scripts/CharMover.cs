using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            Physics.Raycast(r.origin, r.direction, out rh, Mathf.Infinity);
                
            if(rh.collider != null && GetComponent<Rigidbody>().velocity.magnitude < 1f)
            {
                Vector3 collide = rh.point;
                Vector3 dir = rh.point - this.transform.position;
                GetComponent<Rigidbody>().AddForce( 3 * new Vector3(dir.x, 0, dir.z), ForceMode.Impulse);
            }
        }
    }
}
