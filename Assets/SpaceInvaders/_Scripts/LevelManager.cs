using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int gameSceneIndex;
    [SerializeField] private int menuSceneIndex;
    
    private int _currentSceneIndex;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }



}
