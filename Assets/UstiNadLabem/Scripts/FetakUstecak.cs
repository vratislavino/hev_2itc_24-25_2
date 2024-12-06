using UnityEngine;

public class FetakUstecak : Ustecak
{
    public override void DoDamage()
    {
        transform.Rotate(0, 180, 0);

        Vector3 localPos = transform.localPosition;
        localPos.z = -localPos.z;
        localPos.x = -localPos.x;
        transform.localPosition = localPos;

        RemoveLife();
    }
}
