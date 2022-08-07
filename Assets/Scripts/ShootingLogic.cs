using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLogic : MonoBehaviour
{
    [SerializeField]
    private float shootingInterval;
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shooterTransform;
    private Utility<Shot> shotPool;
    void Start()
    {
        shotPool = new Utility<Shot>();
        StartCoroutine(Shooting());
    }

    void Update()
    {
        
    }

    private IEnumerator Shooting()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootingInterval);
            Shot currentShot = shotPool.pool.Get();
            currentShot.transform.position = shooterTransform.position;

        }
        
        
    }
}
