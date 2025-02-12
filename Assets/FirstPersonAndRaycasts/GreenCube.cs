using UnityEngine;

public class GreenCube : Interactive
{
    private MeshRenderer _look;

    private void Awake()
    {
        _look = GetComponent<MeshRenderer>();
    }

    public override void PerformAction()
    {
        ChangeColor();
        base.PerformAction();
    }

    public override void DoSomethingSpecial()
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        _look.material.color = Random.ColorHSV();
    }
    
    
}
