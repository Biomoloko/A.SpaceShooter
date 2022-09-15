using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Obstacle, IShootable
{
    [SerializeField] private int damage;

    //цена астероида
    //[SerializeField] private static int asteroidCost = 2;

    public int myCost { get; set; } = 2;

    public override void ToHitSpaceship(Player player)
    {
        player.ChangeHealth(-damage);
        EffectBehaviour(ParticleTypes.Asteoid);
    }

    public void OnShotHit()
    {
        //разрушение астероида и изменение динмического значения
        //Player.instance.dynamicScore = asteroidCost;

        Player.instance.CountScore(myCost);
        EffectBehaviour(ParticleTypes.Asteoid);
    }
}

