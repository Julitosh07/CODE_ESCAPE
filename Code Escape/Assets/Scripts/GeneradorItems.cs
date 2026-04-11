using UnityEngine;
public class GeneradorItems : MonoBehaviour
{
    public GameObject prefabItem; // Arrastra aquí el Prefab desde el Project
    public float tiempoEntreSpawn = 2.0f;
    private float temporizador;
    void Start()
    {
        // Al inicio, instancia un item inmediatamente
        Instantiate(prefabItem, transform.position, Quaternion.identity);
        temporizador = tiempoEntreSpawn;
    }
    void Update()
    {
        // Cuenta regresiva para el siguiente spawn
        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            // --- Acción de Instanciación ---
            // Crea una NUEVA copia del Prefab en la posición del Spawner
            Instantiate(prefabItem, transform.position, Quaternion.identity);
            // Reinicia el temporizador
            temporizador = tiempoEntreSpawn;
        }
    }
}
