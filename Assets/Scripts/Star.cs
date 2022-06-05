using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Obstacle
{
    
    public override void ToHitSpaceship(Player player)
    {
        player.StarsQuantity(1);
        EffectBehaviour();
    }
}
