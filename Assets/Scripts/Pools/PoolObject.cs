using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PoolSender(PoolObject poolObject);
public abstract class PoolObject : MonoBehaviour
{
    public PoolSender OnDesObj;
}
