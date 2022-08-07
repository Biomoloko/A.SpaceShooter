using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ParticleTypes
{
    Explosion,
    Star,
    Asteoid
}
public class ParticleSpawner : MonoBehaviour
{
    public Utility<StarParticles> starParticlesPool;
    public Utility<AsteroidParticles> asteroidParticlesPool;
    public Utility<ExplosionParticles> explosionParticlesPool;
    public static ParticleSpawner instance;
    void Awake()
    {
        instance = this;

        starParticlesPool = new Utility<StarParticles>();
        asteroidParticlesPool = new Utility<AsteroidParticles>();
        explosionParticlesPool = new Utility<ExplosionParticles>();
    }

    void Update()
    {
        
    }

    public PoolObject GetParticles(ParticleTypes particleTypes)
    {
        switch (particleTypes)
        {
            case ParticleTypes.Explosion:
                return explosionParticlesPool.pool.Get();
            case ParticleTypes.Star:
                return starParticlesPool.pool.Get();
            case ParticleTypes.Asteoid:
                return asteroidParticlesPool.pool.Get();
        }
        return null;
    }
}
