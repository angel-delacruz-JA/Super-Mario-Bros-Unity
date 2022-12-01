using UnityEngine;

public class MusicaJuego : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject musica;
    private Jugador muerto;
    public void OnEnable()
    {
        Instantiate(musica);
    }
}
