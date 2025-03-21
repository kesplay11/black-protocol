using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // [SerializeField] private Rigidbody _rigidbody = null;
    // [SerializeField] private float _speed = 10;


    // void Update()
    // {
    //     // if (Input.GetKey(KeyCode.W))
    //     // {
    //     //     _rigidbody.velocity = Vector3.forward * _speed;
    //     // } else{
    //     //     _rigidbody.velocity = Vector3.zero;
    //     // }
    //     float h = Input.GetAxisRaw("Horizontal");
    //     float v = Input.GetAxisRaw("Vertical");

    //     Vector3 move = new Vector3(h, 0, v).normalized;
    //     _rigidbody.velocity = move * _speed;
    // }


        [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;

    [Header("Mouse Look")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Bloquear el cursor al centro
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimiento WASD
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 velocity = move * speed;
        velocity.y = rb.velocity.y; // mantenemos la velocidad vertical actual (por gravedad o salto)
        rb.velocity = velocity;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Mouse Look (solo eje Y, rotación horizontal del cuerpo)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Mouse Look (eje X, rotación vertical de la cámara)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detecta si toca el suelo
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
