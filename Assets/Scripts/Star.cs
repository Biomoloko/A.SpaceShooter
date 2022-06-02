using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Obstacle
{
    private void Awake()
    {
        minSpeed = 2;
        maxSpeed = 3;
    }
    
    public override void ToHitSpaceship(Player player)
    {
        player.StarsQuantity(1);
        EffectBehaviour();
    }
}
