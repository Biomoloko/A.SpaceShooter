using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Utility<T> where T : PoolObject
{
    public ObjectPool<T> pool;
    private T prefab;
    public Utility()
    {
        //asteroid = Resources.Load<Asteroid>("Prefabs/Asteroid");
        //star = Resources.Load<Star>("Prefabs/Star");
        prefab = Resources.Load<T>($"Prefabs/{typeof(T).Name}");
        pool = new ObjectPool<T>(OnCreate, OnGet, OnRelease, OnObjectDestroy, true, 5, 15);
    }

    private T OnCreate()
    {
        T spawnObject = PoolManager.Creator<T>(prefab);

        spawnObject.OnDesObj += (Obs) => pool.Release(Obs as T);
        //выт€гиваем из пула и выключаем (так надо, если не сразу нужно включить объект), но в нашем случае нет необходимости (нужно чтобы не сломать ничего в некоторых случа€х)
        //spawnObject.onDesObs += (Obs) => pool.Release(Obs);
        return spawnObject;
    }

    private void OnGet(T obj) => obj.gameObject.SetActive(true);

    private void OnRelease(T obj) => obj.gameObject.SetActive(false);

    private void OnObjectDestroy(T obj) => PoolManager.Destroyer(obj.gameObject);
}
