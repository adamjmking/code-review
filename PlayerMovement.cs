using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Input
    private PlayerInputActions playerControls;
    private InputAction move;

    // Movement
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake() 
    {
        playerControls = InputManager.Instance.PlayerControls;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.gravityScale = 0;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate() 
    {
        rb.velocity = moveDirection * speed;
    }
}
