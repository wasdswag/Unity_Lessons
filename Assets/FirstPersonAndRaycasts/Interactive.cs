using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    public void DoSomething()
    {
        Debug.Log($"do somethin with {gameObject.name}");
    }

    public virtual void PerformAction()
    {
        Debug.Log($"Some basic behavior for {gameObject.name}");
    }
    
    
    public abstract void DoSomethingSpecial();


}
