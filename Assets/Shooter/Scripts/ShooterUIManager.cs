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

        normalCrosshair.SetActive(true);
        reloadCrosshair.transform.parent.gameObject.SetActive(false);
    }

    private void OnWeaponChanged(Weapon prev, Weapon curr)
    {
        if (prev != null)
        {
            // nezaj�m� m� zm�na n�boj� na zbrani, kterou ukl�z�m do kapsy
            prev.AmmoChanged -= ChangeAmmoText;
            prev.ReloadProgressChanged -= OnReloadProgressChanged;
        }
        // zaj�m� m� zm�na n�boj� na aktu�ln� volen� zbrani
        curr.AmmoChanged += ChangeAmmoText;
        curr.ReloadProgressChanged += OnReloadProgressChanged;

        weaponNameText.text = curr.name;
        // Zm�na ikony zbran�
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
