using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baddie : MonoBehaviour {

    bool die;
    float dieTime;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if(die)
        {
            dieTime -= Time.deltaTime;
            if(dieTime < 0)
            {
                Destroy(gameObject);
            } else
            {
                GetComponent<MeshRenderer>().material.color = new Color(dieTime, 0, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!die && collision.rigidbody != null && collision.rigidbody.name == "Cylinder")
        {
            die = true;
            dieTime = 1f;
            GameObject go = Instantiate(Resources.Load<GameObject>("prefabs/damagefloater"));
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            go.transform.parent = this.transform.parent;
        }
    }
}
