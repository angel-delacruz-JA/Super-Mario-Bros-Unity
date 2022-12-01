using UnityEngine;

public class BarreraMuerte : MonoBehaviour
{
    private Jugador jugador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GameManager.Instancia.ResetLevel(10f);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
