using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;           // Velocidad de movimiento
    public float jumpForce = 5f;       // Fuerza de salto
    private bool isGrounded;           // Para verificar si está en el suelo
    private Rigidbody rb;
    public Transform groundCheck;      // Punto desde donde se lanzará el Raycast
    public float groundDistance = 0.1f; // Distancia para detectar el suelo
    public LayerMask groundMask;       // Máscara de capa para el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica si el personaje está en el suelo usando un Raycast
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, groundMask);

        Move();
        Jump();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        Vector3 newPosition = rb.position + movement * Time.deltaTime;

        rb.MovePosition(newPosition);
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
