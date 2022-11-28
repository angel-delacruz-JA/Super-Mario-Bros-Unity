using System.Collections;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instancia.AgregarMoneda();
        StartCoroutine(Animate());
    }
    private IEnumerator Animate()
    {
        Vector3 restingPoint = transform.localPosition;
        Vector3 animatedPosition = restingPoint + Vector3.up * 2f;
        yield return Move(restingPoint, animatedPosition);
        yield return Move(animatedPosition, restingPoint);
        Destroy(gameObject);
    }
    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapsed = 0f;
        float duracion = 0.25f;
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
