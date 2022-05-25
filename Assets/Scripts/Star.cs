using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour, IObstacle
{
    public void ToHitSpaceship(Player player)
    {
        player.StarsQuantity(1);
        Destroy(gameObject);
    }
}
