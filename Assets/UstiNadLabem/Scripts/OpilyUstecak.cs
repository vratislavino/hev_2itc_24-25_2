using UnityEngine;

public class OpilyUstecak : Ustecak
{
    [SerializeField]
    private float turningSpeed = 10;

    private float angleDifferenceBeforeSwitch = 80;
    private bool rotatingRight = true;
    Quaternion baseRotation;

    public override void Start()
    {
        baseRotation = transform.rotation;
    }

    public override void DoDamage()
    {
        RemoveLife();
    }

    protected override void Update()
    {
        base.Update();
        if (rotatingRight)
        {
            transform.Rotate(0, Time.deltaTime * turningSpeed, 0);
        } else
        {
            transform.Rotate(0, -Time.deltaTime * turningSpeed, 0);
        }
        if(Quaternion.Angle(baseRotation, transform.rotation) 
            >= angleDifferenceBeforeSwitch)
        {
            rotatingRight = !rotatingRight;
        }
    }

}
