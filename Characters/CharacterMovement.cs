using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Karakterin yürüme hızı
    public float rotationSpeed = 120.0f; // Karakterin yatay dönme hızı
    public float jumpForce = 8.0f; // Karakterin zıplama gücü

    private Rigidbody rb;
    private bool isGrounded;
    public Transform mainCamera; // Kamera objesi

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       

        // Yürüme kontrolü
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (mainCamera.forward * verticalInput + mainCamera.right * horizontalInput).normalized;
        
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        // Karakterin yatay eksende (x ekseni) dönme işlemi
        Vector3 moveDirWithoutY = moveDirection;
        moveDirWithoutY.y = 0;

        if (moveDirWithoutY != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirWithoutY, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Karakteri zıplatma kontrolü
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
