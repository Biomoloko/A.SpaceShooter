using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParticles : PoolObject
{
    public void StarParticleInvoker()
    {
        OnDesObj.Invoke(this);
    }
    private void OnEnable()
    {
        Invoke(nameof(StarParticleInvoker), 1f);
    }
}
