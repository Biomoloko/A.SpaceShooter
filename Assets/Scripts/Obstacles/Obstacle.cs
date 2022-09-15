using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : PoolObject
    ///public abstract class Obstacle<T> : MonoBehaviour where T : MonoBehaviour
{
    //public OnDestroyObstacle onDesObs;
    public abstract void ToHitSpaceship(Player player);

    protected float obstacleSpeed;
    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

     protected float rotationSpeed;
    [SerializeField] protected float minRotSpeed;
    [SerializeField] protected float maxRotSpeed;

    [SerializeField] protected ParticleSystem obstacleCollisionEffect;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        obstacleSpeed = Random.Range(minSpeed,maxSpeed);
        rotationSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }
    private void FixedUpdate()
    {
        rb.velocity = Vector3.down * obstacleSpeed;
        transform.Rotate(0,0,rotationSpeed);
    }
    protected void EffectBehaviour(ParticleTypes particleTypes)
    {
        ParticleSpawner.instance.GetParticles(particleTypes).transform.position = transform.position;
        //ParticleSystem myEffect = Instantiate(obstacleCollisionEffect, transform.position, Quaternion.identity);
        //Destroy(myEffect.gameObject, 1f);
        //onDesObs.Invoke(this);
        OnDesObj.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        OnDesObj.Invoke(this);
    }
    public void TestMethod<T>(T testParam) where T : MonoBehaviour
    {
        testParam.enabled = false;
    }
}
