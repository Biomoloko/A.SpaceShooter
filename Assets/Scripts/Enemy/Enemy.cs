using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : PoolObject, IShootable
{
    public Action OnDeath;

    [SerializeField] private Vector3 routTarget;
    [SerializeField] private float enemyMovementOffset;
    [SerializeField] private float cameraBorder;
    [SerializeField] private float enemySpeed;
    [SerializeField] protected ParticleSystem destroyEffect;
    private bool alive;
    private static Utility<EnemyShot> enemyShot;
    public Transform enemyShooter;
    public float shootInterval = 2f;

    private void OnEnable()
    {
        alive = true;
        StartCoroutine(Shooting());
    }
    private void OnDisable()
    {
        alive = false;
    }
    public void OnShotHit()
    {
        EffectBehaviour();
        OnDesObj.Invoke(this);
        OnDeath.Invoke();
    }
    void Awake()
    {
        if (enemyShot == null)
            enemyShot = new Utility<EnemyShot>();

        cameraBorder = Camera.main.aspect * Camera.main.orthographicSize + Camera.main.transform.position.x;
    }


    public void IfTurnedOn()
    {
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
        //ParticleSystem myEffect = Instantiate(destroyEffect, transform.position, Quaternion.identity); LEGACY
        //Destroy(myEffect.gameObject, 1f);
        var effect = ParticleSpawner.instance.GetParticles(ParticleTypes.Explosion);
        effect.transform.position = transform.position;
    }

    public IEnumerator Shooting()
    {
        while(alive == true)
        {
            yield return new WaitForSeconds(shootInterval);
            enemyShot.pool.Get().transform.position = enemyShooter.position;
        }
    }
}
