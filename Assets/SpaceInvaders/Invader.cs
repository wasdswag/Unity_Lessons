
using UnityEngine;

public class Invader : MonoBehaviour
{
    public int RowIndex { get; private set; }
   
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float rayDistance = 100f;
    
    private MeshRenderer _look;
    private InvadersFormation _formation;
    private Field _field;
    private Vector3 _currentPosition;

    private int _stepBeforeShoot;
    private int _shootStep;
    
    public void Init(InvadersFormation formation, Field field, int row)
    {
        _look = GetComponent<MeshRenderer>();
        _formation = formation;
        _field = field;
        RowIndex = row;
        _currentPosition = transform.position;
        _shootStep = Random.Range(2, 12);
        Debug.Log(_stepBeforeShoot);

    }

    public bool IsOnTheBorder()
    {
        return (transform.position.x <= _field.Left + 2f || transform.position.x >= _field.Right - 2f);
    }
    
    public void Move(Vector3 dir)
    {
        _currentPosition += dir;
        _currentPosition.x = Mathf.Clamp(_currentPosition.x, _field.Left + 2f, _field.Right - 2f);
        transform.position = _currentPosition;
        _stepBeforeShoot++;
        
        if (_stepBeforeShoot >= _shootStep)
        {
            TryShoot();
            _stepBeforeShoot = 0;
            _shootStep = Random.Range(2, 12);
        }
    }


    private void TryShoot()
    {
        if (IsAllowedToShoot())
            Shoot();
    }

    private bool IsAllowedToShoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(muzzle.position, Vector3.down);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Invader invader))
                return false;
        }

        return true;
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        bullet.Init(Vector3.down, 20f);
    }
    

    public void Kill()
    {
        _formation.Remove(this);
        Destroy(gameObject);
    }

    public void SetColor(Color color)
    {
        _look.material.color = color;
    }

    
    public void SetRandomColor()
    {
        _look.material.color = Random.ColorHSV();
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 35f);
    }


}
