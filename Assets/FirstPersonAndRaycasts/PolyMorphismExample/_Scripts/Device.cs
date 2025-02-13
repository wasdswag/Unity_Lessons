using UnityEngine;

public abstract class Device : MonoBehaviour, IClickable
{
    protected bool IsPowerOn { get; private set; }
    [SerializeField] private MeshRenderer look;
    private const string EMISSION_KEY = "_EMISSION";
    
    private void Awake()
    {
        if(look == null)
            look = GetComponent<MeshRenderer>();
    }

    
    protected virtual void TogglePower()
    {
        IsPowerOn = !IsPowerOn;
        Debug.Log($"{gameObject.name} is power on {IsPowerOn}");
    }

    public virtual void OnFocusEnter()
    {
        look.material.EnableKeyword(EMISSION_KEY);
    }

    public virtual void OnFocusExit()
    {
        look.material.DisableKeyword(EMISSION_KEY);
    }

    public void OnClick()
    {
        TogglePower();
    }
}
