using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    [Header("Animación")]
    public Animator PlayerAnimator;

    [Header("Audio")]
    public AudioSource footstepsSource;
    public AudioClip sonidoPasos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        if (PlayerAnimator == null)
            PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Inputs de movimiento
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        bool isMovingForward = Input.GetKey(KeyCode.W);
        bool isRunning = isMovingForward && Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 velocity = move.normalized * currentSpeed;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        // Animación
        PlayerAnimator.SetFloat("Speed", move.magnitude * (isRunning ? 1.5f : 1f));

        // Rotación de cámara y jugador
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Sonido de pasos
        if (move.magnitude > 0.1f && isGrounded)
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}