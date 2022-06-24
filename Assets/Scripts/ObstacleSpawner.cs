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


    private bool isGaming = true;
    [SerializeField]
    private List<GameObject> spawnObjects;

    private Utility ourPool;
    void Start()
    {
        hightPoint = Camera.main.orthographicSize + Camera.main.transform.position.y + verticalBorderOffset;
        

        float myAspect = Camera.main.orthographicSize * Camera.main.aspect;
        leftP = Camera.main.transform.position.x - myAspect;
        rightP = Camera.main.transform.position.x + myAspect;
        SpawnOurObjects();

        ourPool = FindObjectOfType<Utility>();
    }

    private void OnApplicationQuit()
    {
        isGaming = false;
    }

    private async void SpawnOurObjects ()
    {
        await Task.Delay(4000);
        while(isGaming == true)
        { 
            float randomXPositon = Random.Range(leftP, rightP);

            ///Instantiate(spawnObjects[Random.Range(0,spawnObjects.Count)], new Vector3(randomXPositon, hightPoint,0), Quaternion.identity); (устаревший спавн астероида,(для справки))
            ///
            Obstacle getedSpawnObject = ourPool.pool.Get();
            getedSpawnObject.transform.position = new Vector3(randomXPositon, hightPoint, 0);
            await Task.Delay(Random.Range(500,2000));
        }
    }
}
