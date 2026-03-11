using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] public float Sensibilidad = 100;


    void Start()
    {
        
    }

    void Update()
    {
        float valorX = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
        float valorY = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;

        Debug.Log($"MouseEnX={valorX:F1}, MouseEnY={valorY:F1}");
    }
}
