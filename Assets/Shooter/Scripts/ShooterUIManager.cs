using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShooterUIManager : MonoBehaviour
{
    /*
     Dod�lat UI  + reload
     D�lali jsme k�d a je�t� jsme ho neaplikovali/neotestovali
     */
    [SerializeField]
    private Image reloadCrosshair;
    
    [SerializeField]
    private GameObject normalCrosshair;

    [SerializeField]
    private Image weaponIcon;

    [SerializeField]
    private TMP_Text weaponNameText;

    [SerializeField]
    private TMP_Text weaponAmmoText;

    [SerializeField]
    private WeaponController weaponController;

    void Awake()
    {
        weaponController.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon prev, Weapon curr)
    {
        weaponNameText.text = curr.name;
        // Zm�na ikony zbran�
        ChangeAmmoText();
    }

    private void ChangeAmmoText()
    {
        weaponAmmoText.text = $"{weaponController.CurrentWeapon.CurrentAmmo}/{weaponController.CurrentWeapon.MaxAmmo}";
    }

    void Update()
    {
        
    }
}
