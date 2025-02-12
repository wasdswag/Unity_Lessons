using UnityEngine;

public abstract class Device : MonoBehaviour, IClickable
{
    protected bool IsPowerOn { get; private set; }
    
    protected virtual void TogglePower()
    {
        IsPowerOn = !IsPowerOn;
        Debug.Log($"{gameObject.name} is power on {IsPowerOn}");
    }

    public void OnClick()
    {
        TogglePower();
    }
}
