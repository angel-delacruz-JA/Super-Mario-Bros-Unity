using UnityEngine;
using System.Collections;
public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public AnimatedSprite corriendo;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdatSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    private void UpdatSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        if (deadSprite != null)
        {
            spriteRenderer.sprite = deadSprite;
        }
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach(Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
        GetComponent<Rigidbody2D>().isKinematic = true;
        PlayerMove playerMove = GetComponent<PlayerMove>();
        EntityMove entityMove = GetComponent<EntityMove>();

        if(playerMove!=null)
        {
            playerMove.enabled = false;
        }
        if(entityMove != null)
        {
            entityMove.enabled = false;
        }
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duracion=10f;
        float velocidadSalto = 10f;
        float gravedad = -36f;

        Vector3 velocity = Vector3.up * velocidadSalto;

        while (elapsed < duracion)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravedad * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
