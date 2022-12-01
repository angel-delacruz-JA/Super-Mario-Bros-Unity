using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject sonidoHongo;
    public GameObject sonidoEstrella;
    public GameObject sonido1up;
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
                Instantiate(sonido1up);
                GameManager.Instancia.AgregarVidas();
                break;
            case Type.MagicMushroom:
                Instantiate(sonidoHongo);
                player.GetComponent<Jugador>().Crecer();
                break;
            case Type.Starpower:
                Instantiate(sonidoEstrella);
                player.GetComponent<Jugador>().StarPower();
                break;
        }
        Destroy(gameObject);
    }
}
