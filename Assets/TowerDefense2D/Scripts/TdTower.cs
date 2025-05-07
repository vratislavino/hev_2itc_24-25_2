using UnityEngine;

public abstract class TdTower : MonoBehaviour
{
    public LayerMask enemyLayer;

    [SerializeField]
    protected float damage = 5f;

    [SerializeField]
    protected float range = 5f;

    [SerializeField]
    protected float attackSpeed = 5f; // even for rotation

    protected virtual void Start()
    {
    }

    protected virtual void DoDamage(TdEnemy target)
    {
        target.TakeDamage(damage);
    }
}
