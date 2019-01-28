using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        Common.inst.heartsystem.setMaxHeartCount(3);
        Common.inst.heartsystem.setHeartPieceCount(6);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // called when the cube hits the floor
    void OnCollisionEnter(Collision col)
    {

        if (col.collider.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            return;

        }
            if(!col.collider.attachedRigidbody.gameObject.GetComponent<Baddie>().isSteady)
            {

                Debug.Log("hit!");
                Common.inst.heartsystem.hurt();   
            }
            Debug.Log("hit " + col.collider.attachedRigidbody.gameObject.name + "vel" + col.collider.attachedRigidbody.velocity);
        }
}
