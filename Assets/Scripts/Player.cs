using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PuckCharacter
{
    public Vector3 targVec = Vector3.zero;

    // Use this for initialization
    void Start()
    {

        Common.inst.heartsystem.setMaxHeartCount(3);
        Common.inst.heartsystem.setHeartPieceCount(6);

    }

    public override int attackPower()
    {
        return 4;
    }

    public override Vector3 desiredMove()
    {
        return targVec;
    }

    public override int getMoveTimeMax()
    {
        return 12;
    }

    public override bool isFriendly()
    {
        return true;
    }

    public override float moveVelocity()
    {
        return 26;
    }

    public override void onCharacterDamaged(int damage)
    {
        Common.inst.heartsystem.hurt();
    }
	
}
