using UnityEngine;

public class PinkSphere : Interactive
{
    public override void DoSomethingSpecial()
    {
        ChangeScale();
    }

    public override void PerformAction()
    {
        ChangeScale();
    }

    public void ChangeScale()
    {
        transform.localScale *= 1.1f;
    }
    
    
}
