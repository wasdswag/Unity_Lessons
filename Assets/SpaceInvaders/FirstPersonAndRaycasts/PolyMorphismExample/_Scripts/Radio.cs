using UnityEngine;

public class Radio : Device
{
    [SerializeField] private AudioSource audioSource;

    protected override void TogglePower()
    {
        base.TogglePower();
        if (IsPowerOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
