using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloater : MonoBehaviour {

    float aliveTime;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        aliveTime += Time.deltaTime;
        if(aliveTime > 1)
        {
            Destroy(gameObject);
        }

        //transform.LookAt(Camera.main.transform.position);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime * 0.1f), transform.position.z);
        GetComponentInChildren<TextMesh>().color = new Color(1f, 0f, 0f, 1 - aliveTime);
	}
}
