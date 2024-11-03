using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool rotatingClockwise = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rotatingClockwise && (transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0))
        {
            transform.Rotate(0, 0, -1);
        }
        else if (!rotatingClockwise && transform.eulerAngles.z > 0)
        {
            transform.Rotate(0, 0, 1);
        }

        // Cambiar el estado de rotación solo cuando se presiona la tecla G
        if (Input.GetKeyDown(KeyCode.G))
        {
            rotatingClockwise = !rotatingClockwise;
        }
    }
}
