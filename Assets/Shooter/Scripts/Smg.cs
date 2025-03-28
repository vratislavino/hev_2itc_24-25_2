using UnityEngine;

public class Smg : RangedWeapon
{
    protected override void Start()
    {
        ChangeAmmo(maxAmmo);
        InputFunction = Input.GetButton;
    }
}
