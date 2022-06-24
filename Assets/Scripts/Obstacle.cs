using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDestroyObstacle(Obstacle obstacle);
public abstract class Obstacle : MonoBehaviour
{
    public OnDestroyObstacle onDesObs;
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
        TestMethod<>();
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
        onDesObs.Invoke(this);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        onDesObs.Invoke(this);
    }
    public void TestMethod<T>(T testParam) where T:MonoBehaviour
    {
        Debug.Log(testParam);
    }
}
