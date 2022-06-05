using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Obstacle, IShootable
{
    [SerializeField] private int damage;
    
    public override void ToHitSpaceship(Player player)
    {
        player.ChangeHealth(-damage);
        EffectBehaviour();
    }

    public void OnShotHit()
    {
        EffectBehaviour();
    }
}
