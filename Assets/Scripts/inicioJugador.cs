using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicioJugador : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instancia.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
    }

}

    // Update is called once per frame
