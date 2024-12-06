using UnityEngine;

public class KlasickyUstecak : Ustecak
{
    public override void DoDamage()
    {
        RemoveLife();
    }

    public override void Start()
    {
        base.Start();
    }
}
