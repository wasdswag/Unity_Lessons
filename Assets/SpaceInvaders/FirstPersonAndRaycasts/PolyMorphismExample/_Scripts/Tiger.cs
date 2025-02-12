using UnityEngine;

public class Tiger : MonoBehaviour, IClickable 
{
    public void OnClick()
    {
       Debug.Log("Я ТИГОР!");
    }
}
