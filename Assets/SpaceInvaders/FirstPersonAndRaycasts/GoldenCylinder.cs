using UnityEngine;

public class GoldenCylinder : Interactive
{
    public override void DoSomethingSpecial()
    {
        transform.Rotate(Vector3.right * 45f);
    }

    public override void PerformAction()
    {
        base.PerformAction();
        transform.Rotate(Vector3.right * 45f);
    }
}
