using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTierra : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    float rotacion = 200;
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotacion * Mathf.Deg2Rad;
        /*float rotY = Input.GetAxis("Mouse Y") * rotacion * Mathf.Deg2Rad;*/

        transform.Rotate(Vector3.forward, rotX);
        /*transform.Rotate(Vector3.up, rotX);*/
        /*transform.Rotate(Vector3.right, rotY);*/
    }
}
