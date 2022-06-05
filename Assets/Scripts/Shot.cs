using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class Shot : MonoBehaviour
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * shotSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<IShootable>()?.OnShotHit();
        Destroy(gameObject);
    }
}
