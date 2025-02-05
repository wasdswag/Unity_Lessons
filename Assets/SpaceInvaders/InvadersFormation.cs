using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersFormation : MonoBehaviour
{
    [SerializeField] private Field field;
    [SerializeField] private Invader invaderPrefab; // ссылка на префаб
    [SerializeField] private int col = 8;
    [SerializeField] private int row = 5;
    [SerializeField] private float gap = 1.5f;
  
    [SerializeField] private Color [] colors; 
    [SerializeField] private List<Invader> invaders = new List<Invader>();
    [SerializeField] private float speed = 10f;

    [SerializeField] private float heightOffset = 2f;
    [SerializeField] private float downStep = 10f;

    [SerializeField] private float minFps = 5f;
    [SerializeField] private float maxFps = 30f;
    
    [SerializeField] private float fps = 12f;
    
    private Vector3 _direction = Vector3.left;

    private bool _formationHasReachBorder;
    private float _startAmount;
    
 
    
    private void Start()
    {

        Vector3 invaderScale = invaderPrefab.transform.localScale;
        float xOffset = invaderScale.x * (col-1) * gap / 2;
        float yOffset = invaderScale.y * (row-1) * gap / 2 - heightOffset;
        
        int colorIndex = 0;

        for(int y = row; y > 0; y--)
        {
            for(int x = 0; x < col; x++)
            {
                Vector3 spawnPosition = new Vector3(x * gap - xOffset, y * gap - yOffset, 0);
                Invader invader = Instantiate(invaderPrefab, spawnPosition, Quaternion.identity);
                invader.transform.parent = transform;
                invader.Init(this, field, y);
                invader.SetColor(colors[colorIndex]);
                invaders.Add(invader); // добавляем в лист
            }

            colorIndex++;
            if(colorIndex >= colors.Length)
            {
                colorIndex = 0;
            }
        }

        _startAmount = (float)invaders.Count;
        StartCoroutine(MoveFormation());
    }

    public void Remove(Invader invader)
    {
        invaders.Remove(invader);
    }


    private IEnumerator MoveFormation()
    {
        while (invaders.Count > 0)
        {
            float t = (float)invaders.Count / _startAmount;
            fps = Mathf.Lerp(minFps, maxFps, 1f-t);
            
            float delay = 1f / fps;
            Vector3 direction = GetStepDirection();
            
            for (int i = 0; i <= row; i++)
            {
                yield return new WaitForSeconds(delay);
                foreach (var invader in invaders)
                {
                    if (invader != null && invader.RowIndex == i)
                        invader.Move(direction * speed);
                }
            }

            yield return null;
        }
    }
    
    


    private Vector3 GetStepDirection()
    {
        foreach (var invader in invaders)
        {
            if (_formationHasReachBorder == false)
            {
                if (invader.IsOnTheBorder())
                {
                    _direction = -_direction;
                    _formationHasReachBorder = true;
                    break;
                }
            }
            else
            {
                _formationHasReachBorder = false;
                break;
            }
        }
        
        Vector3 moveDirection = _formationHasReachBorder ? Vector3.down * downStep : _direction;
        return moveDirection;
    }
    
}
