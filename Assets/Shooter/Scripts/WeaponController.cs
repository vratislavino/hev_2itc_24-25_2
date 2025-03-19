using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public event Action<Weapon, Weapon> WeaponChanged;

    Weapon currentWeapon;
    public Weapon CurrentWeapon => currentWeapon;

    List<Weapon> weapons;
    void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        weapons.ForEach(w => w.gameObject.SetActive(false));
        SelectWeapon(weapons.First());
    }

    private void SelectWeapon(Weapon weapon)
    {
        Weapon previousWeapon = currentWeapon;

        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);

        currentWeapon = weapon;
        currentWeapon.gameObject.SetActive(true);

        WeaponChanged?.Invoke(previousWeapon, currentWeapon);
    }

    void Update()
    {
        if (currentWeapon == null) return;

        if (currentWeapon.InputFunction("Fire1"))
            currentWeapon.Attack();

        if(Input.GetKeyDown(KeyCode.Alpha1))
            SelectWeapon(weapons[0]);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectWeapon(weapons[1]);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectWeapon(weapons[2]);
    }
}
