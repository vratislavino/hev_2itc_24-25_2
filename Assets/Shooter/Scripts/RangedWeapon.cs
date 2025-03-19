using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    protected int ammo;
    [SerializeField]
    protected int maxAmmo;

    public override int CurrentAmmo => ammo;
    public override int MaxAmmo => maxAmmo;

    [SerializeField]
    protected Rigidbody projectilePrefab;

    [SerializeField]
    protected Transform shootPoint;

    protected virtual void Start()
    {
        InputFunction = Input.GetButtonDown;
        ammo = maxAmmo;        
    }

    protected override void DoAttack()
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
        projectile.AddForce(projectile.transform.forward * 1, ForceMode.Impulse);
        Destroy(projectile.gameObject, 4f);
    }

}
