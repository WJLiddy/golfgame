using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public static Common inst;
    public float tempo = 120.0f;
    public GameObject player;
    public HeartSystem heartsystem;
	// Use this for initialization
	void Awake()
    {
        inst = this;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
