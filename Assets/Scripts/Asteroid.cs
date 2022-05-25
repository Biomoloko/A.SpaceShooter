using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IObstacle
{
    [SerializeField] private int damage;
    public void ToHitSpaceship(Player player)
    {
        player.ChangeHealth(-damage);
    }

}
