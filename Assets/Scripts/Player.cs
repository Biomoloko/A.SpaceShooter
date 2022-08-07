using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IShootable
{
    [SerializeField] private float health;
    [SerializeField] private float currentMaxHealth;
    [SerializeField] private int starsCount;
    [SerializeField] private Image healthImage;
    private void Awake()
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
        VisualManager.instance.Drawator(healthImage, health, currentMaxHealth);
    }
    public void StarsQuantity(int starsDelta)
    {
        starsCount += starsDelta;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Obstacle>()?.ToHitSpaceship(this);
    }

    public void OnShotHit()
    {
        Debug.Log("OUCH !!");
    }
}
