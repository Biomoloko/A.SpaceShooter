using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private static Enemy firstEnemy;
    [SerializeField] private bool alive;
    void Start()
    {
        StartCoroutine(Spawner());
        if (firstEnemy == null)
        {
            firstEnemy = Resources.Load<Enemy>("Prefabs/EnemyFirst");
        }
    }

    void Update()
    {
        
    }
    public IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitUntil(()=>alive == false);
            int chance = Random.Range(0, 10);
            if (chance != 0)
            {
                yield return new WaitForSeconds(1f);
                continue;
            }
            alive = true;
            
            Enemy currentEnemy = Instantiate(firstEnemy, transform.position, Quaternion.identity);
            currentEnemy.OnDeath += () => alive = false;
        }
    }
    //private void AliveSwitcher() => alive = false;
    
}
