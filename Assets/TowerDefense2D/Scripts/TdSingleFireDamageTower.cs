using System.Linq;
using UnityEngine;

public class TdSingleFireDamageTower : TdOvertimeDamageTower
{
    protected override void Attack()
    {
        if(enemiesInRange.Count > 0)
        {
            DoDamage(enemiesInRange.First());
        }
    }
}
