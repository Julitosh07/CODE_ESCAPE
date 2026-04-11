using UnityEngine;

public class RecolectorItems : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Coleccionable"))
        {
            Debug.Log("Item recolectado!");
            Destroy(hit.gameObject);
        }
    }
}