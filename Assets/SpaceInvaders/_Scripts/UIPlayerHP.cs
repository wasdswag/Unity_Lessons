using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerHP : MonoBehaviour
{
    [SerializeField] private GameObject[] lives;
    private int _currentLifeIndex;

    private void Start()
    {
        _currentLifeIndex = lives.Length;
        foreach (var live in lives)
        {
            live.SetActive(true);
        }
    }

    

    public void TakeLive()
    {
        if (_currentLifeIndex > 0)
        {
            lives[_currentLifeIndex-1].SetActive(false);
            _currentLifeIndex--;
        }
        else
        {
            Debug.Log("There is no lives left to remove");
        }
    }


}
