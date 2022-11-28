using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Nuevopersonaje", menuName = "Personaje")]

public class Personajes : ScriptableObject
{
    // Start is called before the first frame update
    public GameObject personajeJugable;

    public Sprite imagen;

    public string nombre;
   
}
