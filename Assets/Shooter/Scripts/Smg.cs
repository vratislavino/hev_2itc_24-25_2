using UnityEngine;

public class Smg : RangedWeapon
{
    protected override void Start()
    {
        ammo = maxAmmo;
        InputFunction = Input.GetButton;
    }
}
