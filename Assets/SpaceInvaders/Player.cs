using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float bulletSpeed = 100f;
    
    [SerializeField] private float offset = 2f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Field field;

    [SerializeField] private int maxLives = 3;
    [SerializeField] private UIPlayerHP uiPlayerHp;

    [SerializeField] private LevelManager levelManager;
    
    private int _currentHP;
    private float currentXPos;
    private Vector3 startPosition;
    
    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        _currentHP = maxLives;
        startPosition = transform.position;
        currentXPos = startPosition.x;
    }
    
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        currentXPos += h * moveSpeed * Time.deltaTime;
        currentXPos = Mathf.Clamp(currentXPos, field.Left+offset, field.Right-offset);
        transform.position = new Vector3(currentXPos, startPosition.y, startPosition.z);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        bullet.Init(muzzle.transform.up, bulletSpeed);
    }

    public void TakeDamage()
    {
        uiPlayerHp.TakeLive();
        if (_currentHP > 1)
        {
            _currentHP--;
        }
        else
        {
            levelManager.ShowMenu();
            Debug.Log("Game Over!");
        }
        
    }
    
    
}
