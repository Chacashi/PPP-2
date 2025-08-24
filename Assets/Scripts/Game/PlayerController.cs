using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(GravityPlayer))]
public class PlayerController : MonoBehaviour
{
    public static event Func<Transform> OnGetCamera;
    public static event Action OnDead;

    [Header("Player Stats")]
    [SerializeField] private int maxVida = 100;
    [SerializeField] private int vida;
    [SerializeField] private float umbralCaida = -10f;  
    [SerializeField] private float multiplicadorDaño = 2f; 

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

    private bool estabaEnElSuelo = false;

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
        vida = maxVida;
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

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundMask))
        {
            bool isGrounded = true;

            PlataformsCae plataformaCae = hit.collider.GetComponent<PlataformsCae>();
            if (plataformaCae != null)
            {
                plataformaCae.Caer();
            }

            PlataformsSube plataformaSube = hit.collider.GetComponent<PlataformsSube>();
            if (plataformaSube != null)
            {
                plataformaSube.Subir();
            }

            if (!estabaEnElSuelo)
            {
                RevisarDañoCaida();
            }

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            if (isGrounded && jumpPressed)
            {
                velocity.y = jumpForce;
                jumpPressed = false;
            }

            estabaEnElSuelo = true;
        }
        else
        {
            estabaEnElSuelo = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void RevisarDañoCaida()
    {
        if (velocity.y < umbralCaida)
        {
            int daño = Mathf.RoundToInt(Mathf.Abs(velocity.y) * multiplicadorDaño);
            vida -= daño;
            Debug.Log($" Daño por caída: {daño}, Vida restante: {vida}");

            if (vida <= 0)
            {
                OnDead?.Invoke();
                Debug.Log("  El jugador ha muerto");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
