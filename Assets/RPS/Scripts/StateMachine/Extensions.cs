using UnityEngine;

public static class Extensions
{
    public static bool? WouldWin(this Symbol a, Symbol b)
    {
        if(a == b) return null;

        if(a == Symbol.Rock)
            return b == Symbol.Scissors;

        if (a == Symbol.Paper)
            return b == Symbol.Rock;

        if (a == Symbol.Scissors)
            return b == Symbol.Paper;

        return false;
    }
}
