using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 5f; // Fuerza de salto (se mantiene)
    private Rigidbody rb;
    private bool isGrounded; // Para detectar si está en el suelo

    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    [Header("Animación")]
    public Animator PlayerAnimator; // Solo controla Idle/Run (sin salto)


    [Header("Audio")]
    public AudioSource footstepsSource;
    public AudioClip sonidoPasos;


    [Header("Velocidades")]
    public float walkSpeed = 4.3f;
    public float runSpeed = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        // Opcional: Obtener el Animator automáticamente
        if (PlayerAnimator == null)
            PlayerAnimator = GetComponent<Animator>();
    }

void Update()
{
    // Movimiento horizontal
    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");

    // ¿Está moviéndose?
    bool isMoving = x != 0 || z != 0;
    bool isRunning = isMoving && Input.GetKey(KeyCode.LeftShift);

    // Velocidad dinámica
    float currentSpeed = isRunning ? runSpeed : walkSpeed;

    Vector3 move = transform.right * x + transform.forward * z;
    Vector3 velocity = move.normalized * currentSpeed;
    velocity.y = rb.velocity.y; // Mantener gravedad y salto
    rb.velocity = velocity;

    // Animaciones (puede usarse para blend tree)
    PlayerAnimator.SetFloat("Speed", move.magnitude * currentSpeed);

    // Rotación de cámara
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);

    // Salto
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    // Sonido de pasos
    if (isMoving && isGrounded)
    {
        if (!footstepsSource.isPlaying)
        {
            footstepsSource.clip = sonidoPasos;
            footstepsSource.loop = true;
            footstepsSource.Play();
        }
    }
    else
    {
        if (footstepsSource.isPlaying)
        {
            footstepsSource.Stop();
        }
    }
}

    // Detección del suelo (sin animación)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}