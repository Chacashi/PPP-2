using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static event Func<Transform> OnGetCamera;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    private Transform mainCamera;
    private CharacterController controller;
    private Vector3 velocity;

    private Vector2 moveInput;

    private void OnEnable()
    {
        InputReader.OnMovePlayer += SetMoveInput;
    }

    private void OnDisable()
    {
        InputReader.OnMovePlayer -= SetMoveInput;
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

    private void MovePlayer()
    {
        Vector3 direction = (mainCamera.right * moveInput.x + mainCamera.forward * moveInput.y).normalized;
        direction.y = 0;

        controller.Move(direction * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
