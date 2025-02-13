using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float rayLength = 10f;
    [SerializeField] private LayerMask raycastLayers;

    private Ray _ray;
    private RaycastHit _hit;


    private IClickable previousClickable; 
    private IClickable currentClickable;

    private void Update()
    {
        _ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f,
            playerCamera.nearClipPlane));

        bool hasHit = Physics.Raycast(_ray, out _hit, rayLength, raycastLayers); 

        if (hasHit && _hit.collider.TryGetComponent(out IClickable clickable))
        {
            previousClickable = currentClickable;
            currentClickable = clickable;
            
            // highLight
            if (currentClickable != previousClickable)
            {
                HighlightObject(ref currentClickable);
                DeselectObject(ref previousClickable);
            }

            // LMB ЛКМ     
            if (Input.GetMouseButtonDown(0))
            {
                currentClickable.OnClick();
            }

        }
         // когда луч обрывается  
        else 
        {
            DeselectObject(ref currentClickable);
            DeselectObject(ref previousClickable);
        }
    }


    private void DeselectObject(ref IClickable clickable)
    {
        if (clickable != null)
        {
            clickable.OnFocusExit();
            clickable = null;
        }
    }

    private void HighlightObject(ref IClickable clickable)
    {
        if (clickable != null)
            clickable.OnFocusEnter();
    }


    
}
