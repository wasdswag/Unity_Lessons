using UnityEngine;

public class RaycastInteractor : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float rayLength = 10f;
    [SerializeField] private LayerMask raycastLayers;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        _ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f,
            playerCamera.nearClipPlane));

        if (Physics.Raycast(_ray, out _hit, rayLength, raycastLayers))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_hit.collider.TryGetComponent(out IClickable clickable))
                {
                    clickable.OnClick();
                }
            }

        }
    }
}
