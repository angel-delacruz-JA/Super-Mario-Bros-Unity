using System.Collections;
using UnityEngine;

public class HitBlock : MonoBehaviour
{
    public GameObject item;
    public Sprite bloqueVacio;
    public int maxHits = -1;
    private bool animating;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!animating && maxHits !=0 && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.Test(transform, Vector2.up))
            {
                Hit();
            }
        }
    }
    private void Hit()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        maxHits--;
        if (maxHits == 0)
        {
            spriteRenderer.sprite = bloqueVacio;
        }
        if (item != null)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        StartCoroutine(Animate());
    }
    private IEnumerator Animate()
    {
        animating = true;
        Vector3 restingPoint = transform.localPosition;
        Vector3 animatedPosition = restingPoint + Vector3.up * 0.5f;
        yield return Move(restingPoint, animatedPosition);
        yield return Move(animatedPosition, restingPoint);
        animating = false;
    }
    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duracion = 0.125f;
        while (elapsed < duracion)
        {
            float t = elapsed / duracion;
            transform.localPosition = Vector3.Lerp(from, to, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = to;
    }
}
