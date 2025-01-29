using UnityEngine;

public class RPSSymbol : MonoBehaviour
{
    private Symbol currentSymbol;
    public Symbol CurrentSymbol => currentSymbol;

    [SerializeField]
    private MeshRenderer symbolRenderer;

    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private int livesCount = 1;

    void Start()
    {
        ChangeSymbol(GenerateSymbol(true));
    }

    public void TakeDamage()
    {
        livesCount--;
        if(livesCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeSymbolToRandom()
    {
        ChangeSymbol(GenerateSymbol(false));
    }

    private void ChangeSymbol(Symbol symbol)
    {
        currentSymbol = symbol;
        symbolRenderer.material = materials[(int)symbol];
    }

    private Symbol GenerateSymbol(bool completelyRandom)
    {
        if (completelyRandom) return (Symbol)Random.Range(0, 3);

        var newSymbol = (Symbol)Random.Range(0, 3);
        if(newSymbol == currentSymbol) 
            return GenerateSymbol(completelyRandom);
        return newSymbol;
    }
}
public enum Symbol
{
    Rock, Paper, Scissors
}