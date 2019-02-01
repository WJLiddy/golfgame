using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProp : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if(col.relativeVelocity.magnitude > 11)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>("props/barrel/broken"));
            go.transform.parent = this.transform.parent;
            go.transform.position = this.transform.position;
            go.transform.rotation = this.transform.rotation;
            Destroy(this.gameObject);
        }
    }
}