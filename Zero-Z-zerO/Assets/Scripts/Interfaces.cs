using UnityEngine;

interface IDamageable {
    void ReceiveHit(float damage);
}
interface ICustomSpawner {
    void Initialize(GameObject spawned);
}

interface IProjectileOwner
{
    void RegisterProjectile(GameObject projectile);
}