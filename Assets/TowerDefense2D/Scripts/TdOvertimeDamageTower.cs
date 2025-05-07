using System.Collections;
using UnityEngine;

public abstract class TdOvertimeDamageTower : TdTower
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed);
            Attack();
        }
    }

    protected abstract void Attack();
    
}
