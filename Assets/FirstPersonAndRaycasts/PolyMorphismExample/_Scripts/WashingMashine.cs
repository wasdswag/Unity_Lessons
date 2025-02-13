using System.Collections;
using UnityEngine;

public class WashingMashine : Device
{
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeAmplitude;

    
    private MeshRenderer _look;
    private const string EMISSION_KEY = "_EMISSION";


    protected override void TogglePower()
    {
        base.TogglePower();
        if (IsPowerOn)
        {
            StartCoroutine(Shake());
        }
        else
        {
            StopAllCoroutines();
        }
    }


    private IEnumerator Shake()
    {
        Vector3 standPosition = transform.position;

        while(IsPowerOn)
        {
            float sin = Mathf.Sin(Time.time * shakeFrequency) * shakeAmplitude;
            float cos = Mathf.Cos(Time.time * shakeFrequency) * shakeAmplitude;
    
            transform.position = new Vector3(standPosition.x + sin, standPosition.y + sin, standPosition.z + cos);

            yield return null;
        }
    }

}
