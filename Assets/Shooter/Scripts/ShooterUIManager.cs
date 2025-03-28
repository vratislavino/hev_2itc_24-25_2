using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShooterUIManager : MonoBehaviour
{
    /*
     Dodìlat UI  + reload
     Dìlali jsme kód a ještì jsme ho neaplikovali/neotestovali
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

        normalCrosshair.SetActive(true);
        reloadCrosshair.transform.parent.gameObject.SetActive(false);
    }

    private void OnWeaponChanged(Weapon prev, Weapon curr)
    {
        if (prev != null)
        {
            // nezajímá mì zmìna nábojù na zbrani, kterou uklízím do kapsy
            prev.AmmoChanged -= ChangeAmmoText;
            prev.ReloadProgressChanged -= OnReloadProgressChanged;
        }
        // zajímá mì zmìna nábojù na aktuálnì volené zbrani
        curr.AmmoChanged += ChangeAmmoText;
        curr.ReloadProgressChanged += OnReloadProgressChanged;

        weaponNameText.text = curr.name;
        // Zmìna ikony zbranì
        OnReloadProgressChanged(curr.IsReloading?1:0);
        ChangeAmmoText();
    }

    private void OnReloadProgressChanged(float progress)
    {
        if(progress == 1)
        {
            normalCrosshair.SetActive(false);
            reloadCrosshair.transform.parent.gameObject.SetActive(true);
        }
        if(progress <= 0)
        {
            normalCrosshair.SetActive(true);
            reloadCrosshair.transform.parent.gameObject.SetActive(false);
        } else
        {
            reloadCrosshair.fillAmount = progress;
        }
    }

    private void ChangeAmmoText()
    {
        weaponAmmoText.text = $"{weaponController.CurrentWeapon.CurrentAmmo}/{weaponController.CurrentWeapon.MaxAmmo}";
    }

    void Update()
    {
        
    }
}
