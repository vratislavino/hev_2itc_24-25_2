using UnityEngine;

public class AdrenalineUstecak : Ustecak
{
    public override void DoDamage()
    {
        RemoveLife();
    }
}
