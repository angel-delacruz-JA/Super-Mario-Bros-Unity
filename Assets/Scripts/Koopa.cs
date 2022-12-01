using UnityEngine;

public class Koopa : MonoBehaviour
{
    public Sprite caparazonSprite;
    public float velocidadCaparazon = 12f;
    private bool adentroCaparazon;
    private bool caparazonMovimiento;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!adentroCaparazon && collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador.starpower)
            {
                Hit();
            }
            else if (collision.transform.Test(transform, Vector2.down))
            {
                Caparazon();
            }
            else
            {
                jugador.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(adentroCaparazon && other.CompareTag("Player"))
        {
            if (!caparazonMovimiento)
            {
                Vector2 direccion = new Vector2(transform.position.x - other.transform.position.x , 0f);
                PushCaparazon(direccion);
            }
            else
            {
                Jugador jugador = other.GetComponent<Jugador>();
                if (jugador.starpower)
                {
                    Hit();
                }
                else
                {
                    jugador.Hit();
                }
            }
        }
        else if(!adentroCaparazon && other.gameObject.layer == LayerMask.NameToLayer("Shell"))
        {
            Hit();
        }
    }

    private void PushCaparazon(Vector2 direccion) 
    {
        caparazonMovimiento = true;
        GetComponent<Rigidbody2D>().isKinematic = false;
        EntityMove movimiento = GetComponent<EntityMove>();
        movimiento.direccion = direccion.normalized;
        movimiento.velocidad = velocidadCaparazon;
        movimiento.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Shell");
    }

    private void Caparazon()
    {
        adentroCaparazon = true;
        GetComponent<EntityMove>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = caparazonSprite;
    }
    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }
    private void OnBecameInvisible()
    {
    //    if (caparazonMovimiento)
    //    {
    //        Destroy(gameObject);
    //    }
    }
}
