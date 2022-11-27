using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    public List<Personajes> personajes;

    public int mundo { get; private set; }
    public int nivel { get; private set; }
    public int vidas { get; private set; }
    private void Awake()
    {
        if (Instancia != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);  
        }
    }
    private void OnDestroy()
    {
        if (Instancia == this)
        {
            Instancia = null;
        }
    }
    public void Start()
    {
        //NewGame();
    }
    public void NewGame()
    {
        vidas = 3;
        CargarNivel(1,1);
    }
    private void CargarNivel(int mundo,int nivel)
    {
        this.mundo = mundo;
        this.nivel = nivel;
        SceneManager.LoadScene($"{mundo}-{nivel}");
    }
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetNivel),delay);
    }
    public void SiguienteNivel()
    {
        if((mundo==1 || mundo == 2) && nivel == 3)
        {
            CargarNivel(mundo + 1, 1);
        }
        CargarNivel(mundo, nivel + 1);
    }
    public void ResetNivel()
    {
        vidas--;
        if (vidas > 0)
        {
            CargarNivel(mundo,nivel);
        }
        else
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Invoke(nameof(NewGame), 3f);    }
}
