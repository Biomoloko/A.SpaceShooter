using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Utility : MonoBehaviour
{
    private Asteroid asteroid;
    private Star star;
    public ObjectPool<Obstacle> pool;
    void Start()
    {
        asteroid = Resources.Load<Asteroid>("Prefabs/Asteroid");
        star = Resources.Load<Star>("Prefabs/Star");
        pool = new ObjectPool<Obstacle>(OnCreate, OnGet, OnRelease, OnObjectDestroy, true, 5, 15);
    }

    private Obstacle OnCreate()
    {
        Obstacle spawnObject;
        if(UnityEngine.Random.Range(0,5) == 0)
        {
            spawnObject = Instantiate(star, transform);
        }
        else
        {
            spawnObject = Instantiate(asteroid, transform);
        }
        //выт€гиваем из пула и выключаем (так надо, если не сразу нужно включить объект), но в нашем случае нет неободимости (нужно чтобы не сломать ничего в некоторых случа€х)
        //spawnObject.gameObject.SetActive(false);
        spawnObject.onDesObs += (Obs) => pool.Release(Obs);
        return spawnObject;
    }

    private void OnGet(Obstacle obj) => obj.gameObject.SetActive(true);

    private void OnRelease(Obstacle obj) => obj.gameObject.SetActive(false);

    private void OnObjectDestroy(Obstacle obj) => Destroy(obj.gameObject);
}
