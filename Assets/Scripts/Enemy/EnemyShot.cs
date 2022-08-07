using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : PoolObject
{
    [SerializeField] private float shotSpeed;
    [SerializeField] private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<IShootable>()?.OnShotHit();
        OnDesObj.Invoke(this);
        CancelInvoke();
    }
    public void InvokeDestroyer()
    {
        OnDesObj.Invoke(this);
    }
    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.down * shotSpeed, ForceMode2D.Impulse);
        Invoke(nameof(InvokeDestroyer), 2f);
    }
}
