using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Common "tile" class
public class Baddie : MonoBehaviour {

    private int moveTimeMax = 16;
    private float moveTime;
    bool die;
    public bool isSteady;
    float dieTime;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        bool fmove = false;
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
        } else
        {
            if (moveTime <= 0)
            {
                moveTime += ((moveTimeMax) * Common.inst.tempo) / (16f * 60f);
                if(Vector2.Distance(this.transform.position, Common.inst.player.transform.position) < 20)
                {

                    var toPlayer = AI.returnBestPathToTarget(this.transform.position, Common.inst.player.transform.position);
                    toPlayer = toPlayer.normalized;     
                    GetComponent<Rigidbody>().AddForce(toPlayer * 10, ForceMode.Impulse);
                    fmove = true;

                }
            }
            moveTime -= Time.deltaTime;
        }
        isSteady = fmove ? false : GetComponent<Rigidbody>().velocity.magnitude == 0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        /**
        if(!die && collision.rigidbody != null && collision.rigidbody.name == "Player")
        {
            die = true;
            dieTime = 1f;

            GameObject go = Instantiate(Resources.Load<GameObject>("prefabs/damagefloater"));
            go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            go.transform.parent = this.transform.parent;
        }
    */
    }
}
