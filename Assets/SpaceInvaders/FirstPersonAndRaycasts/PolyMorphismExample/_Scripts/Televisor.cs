using UnityEngine;

public class Televisor : Device
{
   [SerializeField] private GameObject tvScreen;

   protected override void TogglePower()
   {
      base.TogglePower();
      tvScreen.SetActive(IsPowerOn);
   }
}
