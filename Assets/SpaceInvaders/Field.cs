using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    [SerializeField] private float depth;
    [SerializeField] private Shield shieldPrefab;
    
    public float Top { get; private set; } 
    public float Bottom { get; private set; }
    public float Left { get; private set; } 
    public float Right { get; private set; } 
    
    [SerializeField] private Camera gameCamera;

    [SerializeField] private float leftOffset;
    [SerializeField] private float botOffset = 3f;
    
    [SerializeField] private float shieldGap = 15f;
    
    
    private void Awake()
    {
        // left down corner
        Vector3 leftDownCorner = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, depth));
        Vector3 rightUpCorner = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, depth));

        Top = rightUpCorner.y;
        Bottom = leftDownCorner.y;
        
        Left = leftDownCorner.x;
        Right = rightUpCorner.x;
       
    }

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 spawnPos = new Vector3(Left + leftOffset + i * shieldGap, Bottom + botOffset, 0);
            Shield shield = Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
        }
    }

}
