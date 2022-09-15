using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class ObstacleSpawner : MonoBehaviour
{
    private float hightPoint;
    private float leftP;
    private float rightP;

    private const float verticalBorderOffset = 1.5f;


    [SerializeField]
    private List<GameObject> spawnObjects;

    private Utility<Asteroid> asteroidPool;
    private Utility<Star> starPool;
    void Start()
    {
        hightPoint = Camera.main.orthographicSize + Camera.main.transform.position.y + verticalBorderOffset;
        

        float myAspect = Camera.main.orthographicSize * Camera.main.aspect;
        leftP = Camera.main.transform.position.x - myAspect;
        rightP = Camera.main.transform.position.x + myAspect;

        //Ёкземпл€ры классса Utility с типами объектов
        asteroidPool = new Utility<Asteroid>();
        starPool = new Utility<Star>();
        //дважды вызываем метод с разными параметрами, <> не ставили потому, что метод автоматически становитс€ типом параметров
        SpawnOurObjects(asteroidPool);
        SpawnOurObjects(starPool);
    }


    private async void SpawnOurObjects<T> (Utility<T> poolObject) where T : PoolObject
    {
        await Task.Delay(4000);
        while(GameManager.isGaming == true)
        { 
            float randomXPositon = Random.Range(leftP, rightP);

            ///Instantiate(spawnObjects[Random.Range(0,spawnObjects.Count)], new Vector3(randomXPositon, hightPoint,0), Quaternion.identity); (устаревший спавн астероида,(дл€ справки))
            ///
            T getedSpawnObject = poolObject.pool.Get();
            getedSpawnObject.transform.position = new Vector3(randomXPositon, hightPoint, 0);
            await Task.Delay(Random.Range(500,2000));
        }
    }
    
}
