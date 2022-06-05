using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public abstract void ToHitSpaceship(Player player);


    [SerializeField] protected float obstacleSpeed = 0;

    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

    [SerializeField] protected ParticleSystem obstacleCollisionEffect;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        obstacleSpeed = Random.Range(minSpeed,maxSpeed);
    }
    private void Update()
    {
        ///rb.AddForce(Vector3.down * obstacleSpeed * Time.deltaTime, ForceMode2D.Force);
        rb.velocity = Vector3.down * obstacleSpeed * Time.deltaTime;
    }
    protected void EffectBehaviour()
    {
        ParticleSystem myEffect = Instantiate(obstacleCollisionEffect, transform.position, Quaternion.identity);
        Destroy(myEffect.gameObject, 1f);
        Destroy(gameObject);
    }
}
