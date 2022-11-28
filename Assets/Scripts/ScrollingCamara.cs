using UnityEngine;

public class ScrollingCamara : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        //player = GameObject.FindWithTag("Player").transform;
        player = Instantiate(GameManager.Instancia.personajes[indexJugador].personajeJugable).transform;
    }

    private void LateUpdate()
    {
        Vector3 posicionCamara = transform.position;
        posicionCamara.x = Mathf.Max(posicionCamara.x, player.position.x);
        transform.position = posicionCamara;
    }
}
