using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    
    public static T Creator<T>(T t) where T : MonoBehaviour
        {
            return Instantiate(t);
        }
    public static void Destroyer(GameObject t)
        {
            Destroy(t);
        }
}
