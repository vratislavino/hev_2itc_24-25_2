using UnityEngine;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        if (currentWeapon.InputFunction("Fire1"))
            currentWeapon.Attack();
    }
}
