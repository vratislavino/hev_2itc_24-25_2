using UnityEngine;

public class TdSingleFireDamageTower : TdOvertimeDamageTower
{
    protected override void Attack()
    {
        var col = Physics2D.OverlapCircle(transform.position, attackRange, enemyLayer);
        if (col)
        {
            var enemy = col.GetComponent<TdEnemy>();
            if (enemy)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
