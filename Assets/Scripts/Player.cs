using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int starsCount;
    void Start()
    { 
    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        transform.position = mousePos;
    }

    public void ChangeHealth(int healthDelta)
    {
        health += healthDelta;
    }
    public void StarsQuantity(int starsDelta)
    {
        starsCount += starsDelta;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Obstacle>()?.ToHitSpaceship(this);
    }
    
}
