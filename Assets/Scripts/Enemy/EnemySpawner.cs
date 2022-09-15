using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static Utility<Enemy> enemyPool;
    [SerializeField] private bool alive;
    void Start()
    {
        if(enemyPool == null)
        {
            enemyPool = new Utility<Enemy>();
        }
        

        /*if (firstEnemy == null)
        {
            firstEnemy = Resources.Load<Enemy>("Prefabs/EnemyFirst");
        }
        */
       StartCoroutine(Spawner());
        
    }

    void Update()
    {
        
    }
    public IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitUntil(()=>alive == false);

            if (GameManager.isGaming == false)
                break;

            int chance = Random.Range(0, 10);
            if (chance != 0)
            {
                yield return new WaitForSeconds(1f);
                continue;
            }
            alive = true;
            
            Enemy currentEnemy = enemyPool.pool.Get();
            currentEnemy.transform.position = transform.position;
            currentEnemy.IfTurnedOn();
            currentEnemy.OnDeath += () => alive = false;
        }
    }
    //private void AliveSwitcher() => alive = false;
}
