using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    protected int ammo;
    [SerializeField]
    protected int maxAmmo;

    [SerializeField]
    protected float reloadTime = 2f;
    private float remainingReloadTime;

    public override int CurrentAmmo => ammo;
    public override int MaxAmmo => maxAmmo;

    public override bool IsReloading => remainingReloadTime > 0;

    [SerializeField]
    protected Rigidbody projectilePrefab;

    [SerializeField]
    protected Transform shootPoint;

    protected virtual void Start()
    {
        InputFunction = Input.GetButtonDown;
        ChangeAmmo(maxAmmo);        
    }

    public override void Reload()
    {
        remainingReloadTime = reloadTime;
        RaiseReloadProgressChanged(1);
    }

    protected override void Update()
    {
        base.Update();
        if (remainingReloadTime > 0)
        {
            remainingReloadTime -= Time.deltaTime;
            RaiseReloadProgressChanged(remainingReloadTime / reloadTime);
            if (remainingReloadTime <= 0)
            {
                ChangeAmmo(maxAmmo);
            }
        }
    }

    protected override void DoAttack()
    {
        if (ammo > 0 && !IsReloading)
            Shoot();
    }

    protected virtual void Shoot()
    {
        ChangeAmmo(ammo - 1);
        SpawnProjectile();
    }

    protected void ChangeAmmo(int currAmmo)
    {
        ammo = currAmmo;
        RaiseAmmoChanged();
    }

    protected virtual void SpawnProjectile()
    {
        var projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectile.AddForce(projectile.transform.forward * 1, ForceMode.Impulse);
        Destroy(projectile.gameObject, 4f);
    }

}
