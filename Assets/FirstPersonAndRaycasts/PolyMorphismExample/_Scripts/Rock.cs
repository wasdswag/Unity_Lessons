using UnityEngine;

public class Rock : MonoBehaviour, IClickable
{
    private MeshRenderer _look;
    private Animator _animator;

    private void Awake()
    {
        _look = GetComponentInChildren<MeshRenderer>();
        _animator = GetComponent<Animator>();
    }
    
    
    public void OnFocusEnter()
    {
        _look.material.EnableKeyword("_EMISSION");
        Debug.Log($"Highlight {gameObject.name}");
    }

    public void OnFocusExit()
    {
        _look.material.DisableKeyword("_EMISSION");
    }

    public void OnClick()
    {
        Debug.Log("YOU ROCK!!!");
        _animator.SetTrigger("Enter");
    }
}
