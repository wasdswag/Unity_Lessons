using UnityEngine;

    public class Lamp : Device
    {
        [SerializeField] private GameObject lightCone;

        protected override void TogglePower()
        {
            base.TogglePower();
            lightCone.SetActive(IsPowerOn);
            
        }
    }
