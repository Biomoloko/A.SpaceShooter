using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyContainer : MonoBehaviour
{
    [SerializeField] private float containerOffset;
    [SerializeField] private float pointSpawnerVertOffset = 0.5f;
    [SerializeField] private List<Transform> PointSpawnerPos = new List<Transform>();
    void Start()
    {
        ///получили список дочерних объектов
        PointSpawnerPos.AddRange(transform.GetComponentsInChildren<Transform>());
        ///удалили первый элемент, т.к. он родительский
        PointSpawnerPos.RemoveAt(0);
        ///получили позицию контейнера чуть дальше левой границы экрана
        float leftSpawnerPosition = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) - containerOffset;
        ///переместили ее при помощи транслейта 
        transform.Translate(leftSpawnerPosition,0,0);
        
        ///верхняя граница камеры
        float upperBorder = Camera.main.transform.position.y + Camera.main.orthographicSize;
        ///вычесляем позицию первой пустышки

        ///теперь всех остальных пустышек
        for (int i = 0; i < PointSpawnerPos.Count; i++)
        {
            PointSpawnerPos[i].position = new Vector3(transform.position.x, upperBorder - pointSpawnerVertOffset*(i+1), 0);
        }
    }

    void Update()
    {
        
    }
}
