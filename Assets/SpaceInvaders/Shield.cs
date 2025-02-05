using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private int cols;
    [SerializeField] private int rows;
    
    [SerializeField] private ShieldVoxel voxelPrefab;
    
    private void Start()
    {
        Make();
    }

    private void Make()
    {
        Vector3 startPosition = transform.position;
        float gapX = voxelPrefab.transform.localScale.x;
        float gapY = voxelPrefab.transform.localScale.y;
        float xOffset = 0;
        
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 spawnPos = new Vector3(startPosition.x + i * gapX + j * gapX * 0.5f, startPosition.y + j * gapY, startPosition.z);
                ShieldVoxel voxel = Instantiate(voxelPrefab, spawnPos, Quaternion.identity);
                voxel.transform.parent = transform;
            }
            rows--;
        }
        
    }
    
}
