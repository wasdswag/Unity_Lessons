using UnityEngine;

public class Tiger : MonoBehaviour, IClickable 
{

    public void OnFocusEnter()
    {
    }

    public void OnFocusExit()
    {
    }

    public void OnClick()
    {
       Debug.Log("Я ТИГОР!");
    }
}
