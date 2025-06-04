using System.Collections.Generic;
using UnityEngine;

public abstract class TdTower : MonoBehaviour
{
    protected List<TdEnemy> enemiesInRange= new List<TdEnemy>();

    public LayerMask enemyLayer;

    [SerializeField]
    protected float damage = 5f;

    [SerializeField]
    protected float range = 5f;

    [SerializeField]
    protected float attackSpeed = 5f; // even for rotation

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENEMY IS HERE");
        other.TryGetComponent<TdEnemy>(out var enemy);
        if(enemy)
            enemiesInRange.Add(enemy);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.TryGetComponent<TdEnemy>(out var enemy);
        if (enemy && enemiesInRange.Contains(enemy))
            enemiesInRange.Remove(enemy);
    }

    protected virtual void Start()
    {
        var col = GetComponent<CircleCollider2D>();
        col.radius = range;
    }

    protected virtual void DoDamage(TdEnemy target)
    {
        target.TakeDamage(damage);
    }
}
