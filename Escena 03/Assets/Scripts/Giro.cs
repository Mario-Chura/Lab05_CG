using UnityEngine;

public class RotateKey : MonoBehaviour
{
    // Velocidad de rotación (ajústala en el Inspector)
    public float rotationSpeed = 50f;

    void Update()
    {
        // Gira el objeto en su propio eje horizontal (ajusta el eje si es necesario)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
