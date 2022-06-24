using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour, IShootable
{
    public Action OnDeath;

    private void OnDestroy()
    {
        EffectBehaviour();
        OnDeath.Invoke();
    }
    [SerializeField] private Vector3 routTarget;
    [SerializeField] private float enemyMovementOffset;
    [SerializeField] private float cameraBorder;
    [SerializeField] private float enemySpeed;
    [SerializeField] protected ParticleSystem destroyEffect;
    public void OnShotHit()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        cameraBorder = Camera.main.aspect * Camera.main.orthographicSize + Camera.main.transform.position.x;
        routTarget = new Vector3(cameraBorder + enemyMovementOffset, transform.position.y, 0);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, routTarget, enemySpeed * Time.deltaTime);
        if (transform.position == routTarget)
        {
            routTarget.x *= -1;
        }
     }
    protected void EffectBehaviour()
    {
        ParticleSystem myEffect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(myEffect.gameObject, 1f);
        Destroy(gameObject);
    }

}
