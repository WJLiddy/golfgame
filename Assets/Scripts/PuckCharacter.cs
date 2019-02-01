using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuckCharacter : MonoBehaviour
{
    private float moveTime;
    private bool m_isSteady;
    private bool dead = false;
    private float dieTime;
    private float dieTimeMax = 1f;

    public abstract int getMoveTimeMax();
    public abstract bool isFriendly();
    public abstract float moveVelocity();
    public abstract Vector3 desiredMove();
    public abstract void onCharacterDamaged(int damage);
    public abstract int attackPower();

    void Update()
    {
        bool justmoved = false;
        if (dead)
        {
            dieTime -= Time.deltaTime;
            if (dieTime < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, dieTime);
            }
        }
        else
        {
            if (moveTime <= 0)
            {
                moveTime += ((getMoveTimeMax()) * Common.inst.tempo) / (16f * 60f);
                Vector3 dir = desiredMove();
                if (dir != Vector3.zero)
                {
                    justmoved = true;
                    float vel = moveVelocity();
                    GetComponent<Rigidbody>().velocity = new Vector3(dir.x * vel, GetComponent<Rigidbody>().velocity.y, dir.z * vel);
                }
            }
        }
        moveTime -= Time.deltaTime;
        m_isSteady = justmoved ? false : GetComponent<Rigidbody>().velocity.magnitude == 0f;
    }

    bool isSteady()
    {
        return m_isSteady;
    }

    public void kill()
    {
        dead = true;
    }

    void OnCollisionEnter(Collision col)
    {
        bool allied = col.collider.gameObject.layer == LayerMask.NameToLayer("Player");
        bool enemy = col.collider.gameObject.layer == LayerMask.NameToLayer("Enemy");
        
        // not another player.
        if (!allied && !enemy)
        {
            return;
        }

        // not a "fight"
        if((isFriendly() && allied) || (!isFriendly() && enemy))
        {
            return;
        }

        // Other target is not moving.
        if (col.collider.attachedRigidbody.gameObject.GetComponent<PuckCharacter>().isSteady())
        {
            return;
        }

        onCharacterDamaged(col.collider.attachedRigidbody.gameObject.GetComponent<PuckCharacter>().attackPower());
    }
}
