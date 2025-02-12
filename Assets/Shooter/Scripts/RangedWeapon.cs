using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    protected int ammo;
    [SerializeField]
    protected int maxAmmo;

    [SerializeField]
    private Rigidbody projectilePrefab;

    [SerializeField]
    private Transform shootPoint;

    public override void Attack()
    {
        if (ammo > 0)
            Shoot();
    }

    protected virtual void Shoot()
    {
        ammo--;
        SpawnProjectile();
    }

    protected virtual void SpawnProjectile()
    {
        var projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectile.AddForce(projectile.transform.forward * 1000);
    }

}
