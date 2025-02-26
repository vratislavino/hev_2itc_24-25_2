using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private int pellets;

    [SerializeField]
    private float spread;

    protected override void SpawnProjectile()
    {
        for(int i = 0; i < pellets; i++)
        {
            var projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            var rand = Random.insideUnitSphere;
            var dir = shootPoint.forward + rand * spread;

            projectile.AddForce(dir, ForceMode.Impulse);
            Destroy(projectile.gameObject, 4f);
        }
    }
}
