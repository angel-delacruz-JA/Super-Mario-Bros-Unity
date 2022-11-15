using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Sprite goombaAplastado;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (collision.transform.Test(transform, Vector2.down))
            {
                Aplastado();
            }
            else
            {
                jugador.Hit();
            }
        }
    }

    private void Aplastado()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMove>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = goombaAplastado;
        Destroy(gameObject, 0.5f);
    }
}
