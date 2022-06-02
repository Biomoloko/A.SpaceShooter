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
    void Start()
    {
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
            Instantiate(shot, shooterTransform.position, Quaternion.identity);
        }
        
        
    }
}
