using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStatic : MonoBehaviour
{
    public GameObject target;
    public float height;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.transform.position + new Vector3(0, height, 5);
        transform.eulerAngles = new Vector3(100, 0, 180);
	}
}
