using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int puntos = 10;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            Debug.Log("Item recolectado! +" + puntos + " puntos");
            Destroy(gameObject);
        }
    }
}
