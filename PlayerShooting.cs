using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    // Input
    private PlayerInputActions playerControls;
    private InputAction fire;
    private InputAction aim;

    // Aiming
    private Camera cam;
    private Vector2 aimPoint;
    private float angle;
    
    // Shooting
    [SerializeField] Transform shootPivot;
    [SerializeField] GameObject bulletPrefab;
    
    private void Awake()
    {
        playerControls = InputManager.Instance.PlayerControls;
        cam = Camera.main;
    }

    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        aim = playerControls.Player.Aim;
        aim.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
        fire.performed -= Fire;

        aim.Disable();
    }

    private void Update()
    {
        aimPoint = cam.ScreenToWorldPoint(playerControls.Player.Aim.ReadValue<Vector2>());
        Vector2 aimDir = (aimPoint - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if (bulletPrefab == null)
            return;

        Instantiate(bulletPrefab, shootPivot.position, Quaternion.Euler(0, 0, angle));
    }
}
