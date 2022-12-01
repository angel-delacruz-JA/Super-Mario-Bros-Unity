using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower
    }
    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect(collision.gameObject);
        }
    }
    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                GameManager.Instancia.AgregarMoneda();
                break;
            case Type.ExtraLife:
                GameManager.Instancia.AgregarVidas();
                break;
            case Type.MagicMushroom:
                player.GetComponent<Jugador>().Crecer(); 
                break;
            case Type.Starpower:
                player.GetComponent<Jugador>().StarPower();
                break;
        }
        Destroy(gameObject);
    }
}
