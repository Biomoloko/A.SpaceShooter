using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public int destroyerOffset;
    
    void Start()
    {
        float lowerBorder = Camera.main.transform.position.y - Camera.main.orthographicSize - destroyerOffset;
        transform.position = new Vector3(0, lowerBorder, 0);
    }

    

    void Update()
    {
        
    }
}
