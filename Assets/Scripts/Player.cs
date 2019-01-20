using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // called when the cube hits the floor
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter");
    }
}
