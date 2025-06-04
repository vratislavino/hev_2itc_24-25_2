using UnityEngine;

public class TdAreaDamageTower : TdOvertimeDamageTower
{
    protected override void Attack()
    {
        if (enemiesInRange.Count > 0)
            enemiesInRange.ForEach(enemy => DoDamage(enemy));
    }

}
