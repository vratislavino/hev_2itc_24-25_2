using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> InputFunction;

    private float fireRate = 0.2f;
    private float currentRate = 0f;

    public virtual int CurrentAmmo { get; }
    public virtual int MaxAmmo { get; }

    public void Attack()
    {
        if(currentRate <= 0)
        {
            DoAttack();
            currentRate = fireRate;
        }
    }

    private void Update()
    {
        currentRate -= Time.deltaTime;
    }

    protected abstract void DoAttack();
}
