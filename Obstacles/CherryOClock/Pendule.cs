using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public Transform centerObject; // Etrafında dönecek olan obje
    public float rotationSpeed = 30.0f; // Dönme hızı
    public GameObject[] rotatingObjects; // Etrafında dönecek olan objeler

    void Update()
    {
        
        

        // Etrafında dönen objeleri merkez nesneye bağla
        foreach (var obj in rotatingObjects)
        {
            obj.transform.RotateAround(centerObject.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
