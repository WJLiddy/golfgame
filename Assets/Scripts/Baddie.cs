using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Common "tile" class
public class Baddie : PuckCharacter
{
    public override int attackPower()
    {
        return 1;
    }

    public override Vector3 desiredMove()
    {
        return AI.returnBestPathToTarget(this.transform.position, Common.inst.player.transform.position);
    }

    public override int getMoveTimeMax()
    {
        return 16;
    }

    public override bool isFriendly()
    {
        return false;
    }

    public override float moveVelocity()
    {
        return 10;
    }

    public override void onCharacterDamaged(int i)
    {
        kill();
    }
}
