using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        Common.inst.heartsystem.setMaxHeartCount(3);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    // called when the cube hits the floor
    void OnCollisionEnter(Collision col)
    {
        Common.inst.heartsystem.setHeartPieceCount(5);
    }
}
