using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool _mouseState;
    private GameObject target;
    public Vector3 screenSpace;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Detecta el clic izquierdo para agrandar el objeto
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                _mouseState = true;
                Enlarge(); // Llama a la función que agranda el objeto
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }

        // Detecta el clic derecho para reducir el tamaño del objeto
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo;
            target = GetClickedObject(out hitInfo);
            if (target != null)
            {
                _mouseState = true;
                Reduce(); // Llama a la función que reduce el tamaño del objeto
                screenSpace = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }

        // Detecta cuando se suelta el mouse
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            _mouseState = false;
        }

        // Si se está arrastrando el objeto, actualiza su posición
        if (_mouseState && target != null)
        {
            var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            target.transform.position = curPosition;
        }
    }

    // Función para agrandar el objeto
    public void Enlarge()
    {
        target.transform.localScale = target.transform.localScale * 1.5f;

        Vector3 pos = target.transform.position;
        pos.z = pos.z + (1.80f * target.transform.localScale.x);
        target.transform.position = pos;
    }

    // Función para reducir el tamaño del objeto
    public void Reduce()
    {
        target.transform.localScale = target.transform.localScale / 1.5f; // Reduce el tamaño

        Vector3 pos = target.transform.position;
        pos.z = pos.z - (1.80f * target.transform.localScale.x); // Ajusta la posición en Z para mantener el efecto de perspectiva
        target.transform.position = pos;
    }

    // Detecta el objeto en el que se hace clic
    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
