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
        ///�������� ������ �������� ��������
        PointSpawnerPos.AddRange(transform.GetComponentsInChildren<Transform>());
        ///������� ������ �������, �.�. �� ������������
        PointSpawnerPos.RemoveAt(0);
        ///�������� ������� ���������� ���� ������ ����� ������� ������
        float leftSpawnerPosition = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect) - containerOffset;
        ///����������� �� ��� ������ ���������� 
        transform.Translate(leftSpawnerPosition,0,0);
        
        ///������� ������� ������
        float upperBorder = Camera.main.transform.position.y + Camera.main.orthographicSize;
        ///��������� ������� ������ ��������

        ///������ ���� ��������� ��������
        for (int i = 0; i < PointSpawnerPos.Count; i++)
        {
            PointSpawnerPos[i].position = new Vector3(transform.position.x, upperBorder - pointSpawnerVertOffset*(i+1), 0);
        }
    }

    void Update()
    {
        
    }
}
