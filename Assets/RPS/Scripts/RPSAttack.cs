using System.Collections;
using System.Linq;
using UnityEngine;

public class RPSAttack : MonoBehaviour
{
    [SerializeField]
    private RPSSymbol mySymbol;

    [SerializeField]
    private float attackInterval;

    private ParticleSystem attackParticleSystem;

    private void Start()
    {
        attackParticleSystem = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(DoAttack());
    }

    private IEnumerator DoAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            DoDamage();
            DoVisuals();
        }
    }

    private void DoDamage() 
    {
        var colliders = Physics.OverlapSphere(transform.position, 0.75f);
        var symbols = colliders.Select(c => c.GetComponentInParent<RPSSymbol>());
        symbols = symbols
            .Where(s => s != null)
            .Where(s => s.transform != transform);
        if(symbols.Count() > 0)
        {
            var enemySymbol = symbols.First();
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(enemySymbol.CurrentSymbol);
            enemySymbol.TakeDamage();
        }
    }

    private void DoVisuals() 
    {
        attackParticleSystem.Emit(30);
    }
}
