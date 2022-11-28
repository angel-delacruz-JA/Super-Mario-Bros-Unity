using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSeleccionPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    private int index;

    [SerializeField] private Image imagen;
    
    [SerializeField] private TextMeshProUGUI nombre;

    public GameManager selectplayer;

    public void Start()
    {
        selectplayer = GameManager.Instancia;

        index = PlayerPrefs.GetInt("JugadorIndex");

        if (index > selectplayer.personajes.Count - 1)
        {
            index = 0;
        }
        CambiarPantalla();

    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex",index);
        imagen.sprite = selectplayer.personajes[index].imagen;
        nombre.text = selectplayer.personajes[index].nombre;
    }
    public void SiguientePersonaje()
    {
        if (index == selectplayer.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarPantalla();
    }
    public void AnteriorPersonaje()
    {
        if (index == 0)
        {
            index = selectplayer.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarPantalla();
    }
    public void iniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
