using System.Collections;
using UnityEngine;

public class Microwave : Device
{
    
    [SerializeField] private GameObject internalLight;
    [SerializeField] private Transform plate;
    [SerializeField] private float plateRotationSpeed = 15f;


    protected override void TogglePower()
    {
        base.TogglePower();
        internalLight.SetActive(IsPowerOn);
        if (IsPowerOn)
        {
            StartCoroutine(RotatePlate());
        }
        else
        {
            StopAllCoroutines();
        }
    }
    
    private IEnumerator RotatePlate()
    {
        while(IsPowerOn)
        {
            plate.Rotate(Vector3.up * plateRotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
