using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : PoolObject
{
    public void ExplosionParticleInvoker()
    {
        OnDesObj.Invoke(this);
    }
    private void OnEnable()
    {
        Invoke(nameof(ExplosionParticleInvoker), 1f);
    }
}
