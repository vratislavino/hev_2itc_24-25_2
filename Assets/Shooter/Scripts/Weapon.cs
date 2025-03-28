using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action AmmoChanged;
    public event Action<float> ReloadProgressChanged;

    public Func<string, bool> InputFunction;

    private float fireRate = 0.2f;
    private float currentRate = 0f;

    public virtual int CurrentAmmo { get; }
    public virtual int MaxAmmo { get; }
    public virtual bool IsReloading { get; }  
    public void Attack()
    {
        if(currentRate <= 0)
        {
            DoAttack();
            currentRate = fireRate;
        }
    }

    protected void RaiseAmmoChanged()
    {
        AmmoChanged?.Invoke();
    }

    protected void RaiseReloadProgressChanged(float progress)
    {
        ReloadProgressChanged?.Invoke(progress);
    }

    public abstract void Reload();

    protected virtual void Update()
    {
        currentRate -= Time.deltaTime;
    }

    protected abstract void DoAttack();
}
