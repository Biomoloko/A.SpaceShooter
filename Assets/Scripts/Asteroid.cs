using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Obstacle, IShootable
{
    [SerializeField] private int damage;
    private void Awake()
    {
        minSpeed = 2;
        maxSpeed = 5;
    }
    
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
