using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidParticles : PoolObject
{
    public void AsteroidParticleInvoker()
    {
        OnDesObj.Invoke(this);
    }
    private void OnEnable()
    {
        Invoke(nameof(AsteroidParticleInvoker), 1f);
    }
}
