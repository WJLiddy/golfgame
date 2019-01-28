using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMover : MonoBehaviour {

    public int moveTimeMax = 4;

    private float moveTime;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (moveTime <= 0)
        {
            moveTime += (moveTimeMax) * (Common.inst.tempo / (16 * 60));

            if (Input.GetMouseButton(0))
            {
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rh;
                Physics.Raycast(r.origin, r.direction, out rh, Mathf.Infinity);

                if (rh.collider != null)
                {
                    Vector3 collide = rh.point;
                    Vector3 dir = rh.point - this.transform.position;
                    Vector3 baseforce = new Vector3(dir.x, 0, dir.z);
                    if(baseforce.magnitude > 5)
                    {
                        baseforce = 5 * baseforce.normalized;
                    }
                    GetComponent<Rigidbody>().AddForce(3 * baseforce, ForceMode.Impulse);
                }
            }
        }
        moveTime -= Time.deltaTime;
    }
}
