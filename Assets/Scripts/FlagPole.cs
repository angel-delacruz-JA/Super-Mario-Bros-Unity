using UnityEngine;
using System.Collections;
public class FlagPole : MonoBehaviour
{
    public Transform Bandera;
    public Transform poleBottom;
    public Transform castillo;
    public float velocidad = 6f;
    public int siguienteMundo = 1;
    public int siguienteNivel = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveTo(Bandera, poleBottom.position));
            StartCoroutine(SecuenciaNivelCompletado(collision.transform));
        }
    }
    private IEnumerator SecuenciaNivelCompletado(Transform jugador)
    {
        jugador.GetComponent<PlayerMove>().enabled = false;
        yield return MoveTo(jugador, poleBottom.position);
        yield return MoveTo(jugador, jugador.position + Vector3.right);
        yield return MoveTo(jugador, jugador.position + Vector3.right + Vector3.down);
        yield return MoveTo(jugador, castillo.position);
        jugador.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        GameManager.Instancia.CargarNivel(siguienteMundo,siguienteNivel+1);
    }
    private IEnumerator MoveTo(Transform subject, Vector3 destino)
    {
        while (Vector3.Distance(subject.position, destino) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
        subject.position = destino;
    }
}
