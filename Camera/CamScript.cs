using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Kamera etrafında dönecek karakterin Transform bileşeni
    public float rotationSpeedX = 2.0f; // Kamera yatay dönme hızı
    public float rotationSpeedY = 2.0f; // Kamera dikey dönme hızı
    public float maxVerticalAngle = 80.0f; // Kameranın en fazla yukarı bakabileceği açı
    public float minVerticalAngle = -80.0f; // Kameranın en fazla aşağı bakabileceği açı

    private Vector3 offset;
    private float currentRotationX = 0.0f;
    private float currentRotationY = 0.0f;

    void Start()
    {
        offset = transform.position - target.position; // Kameranın karaktere olan başlangıç mesafesi
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X"); // Fare yatay (X) hareketi
        float mouseY = Input.GetAxis("Mouse Y"); // Fare dikey (Y) hareketi

        // Kameranın yatay dönmesi
        currentRotationX += mouseX * rotationSpeedX;
        Quaternion horizontalRotation = Quaternion.Euler(0, currentRotationX, 0);

        // Kameranın dikey dönmesi
        currentRotationY -= mouseY * rotationSpeedY;
        currentRotationY = Mathf.Clamp(currentRotationY, minVerticalAngle, maxVerticalAngle);
        Quaternion verticalRotation = Quaternion.Euler(currentRotationY, 0, 0);

        // Kamerayı karakterin yeni pozisyonuna ve dönüş açısına yerleştir
        transform.position = target.position - (horizontalRotation * verticalRotation * offset);
        transform.LookAt(target);
    }
}
