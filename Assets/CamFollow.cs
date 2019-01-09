using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject target;
    public float CAM_RADIUS_XZ;
    public float CAM_HEIGHT_Y = 50;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var rbvel = target.transform.GetComponent<Rigidbody>().velocity;
        var velxz = new Vector2(rbvel.x, rbvel.z);
        if (velxz.magnitude < 1)
        {
            return;
        }
        var vel = new Vector2(rbvel.x, rbvel.z).normalized;

        var target_angle = Mathf.Atan2(-vel.y, -vel.x);

        var cam_offset = new Vector3(Mathf.Cos(target_angle),0,  Mathf.Sin(target_angle)); // The position of the camera is behind the direction of acceleration


        this.transform.position = new Vector3(
            CAM_RADIUS_XZ * cam_offset.x + target.transform.position.x,
            CAM_HEIGHT_Y + target.transform.position.y,
            CAM_RADIUS_XZ * cam_offset.z + target.transform.position.z
            );

        //var current_angle = transform.eulerAngles.y;
        //var lerp_targ_angle = Mathf.LerpAngle(current_angle, , 0.1f);
        this.transform.eulerAngles = new Vector3(30, (-target_angle * Mathf.Rad2Deg) - 90f, 0);
	}
}
