using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(GravityPlayer))]
public class PlayerController : MonoBehaviour
{
    public static event Func<Transform> OnGetCamera;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;   
    public float jumpForce = 5f;    

    [Header("Ground Check")]
    public float groundCheckDistance = 0.2f;
    public LayerMask groundMask;

    private Transform mainCamera;
    private CharacterController controller;
    private Vector3 velocity;
    private Vector2 moveInput;
    private bool jumpPressed;

    private void OnEnable()
    {
        InputReader.OnMovePlayer += SetMoveInput;
        InputReader.OnJump += HandleJump;
    }

    private void OnDisable()
    {
        InputReader.OnMovePlayer -= SetMoveInput;
        InputReader.OnJump -= HandleJump;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        mainCamera = OnGetCamera?.Invoke();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void SetMoveInput(Vector2 value)
    {
        moveInput = value;
    }

    private void HandleJump(bool pressed)
    {
        jumpPressed = pressed;
    }

    private void MovePlayer()
    {
        Vector3 direction = (mainCamera.right * moveInput.x + mainCamera.forward * moveInput.y).normalized;
        direction.y = 0;
        controller.Move(direction * moveSpeed * Time.deltaTime);

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (isGrounded && jumpPressed)
        {
            velocity.y = jumpForce;
            jumpPressed = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
