using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    public List<Personajes> personajes;

    public int mundo { get; private set; }
    public int nivel { get; private set; }
    public int vidas { get; private set; }
    public int monedas { get; private set; }
    public float tiempo { get; private set; }
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
<<<<<<< HEAD
        Application.targetFrameRate = 60;
        //NewGame();
=======
        
        
    } 
    public void Update()
    {
        
        tiempo += Time.deltaTime;
                
>>>>>>> 123201af6cfc5307cf6e9eecb6bd8d4652e3f4a9
    }
    public void NewGame()
    {
        tiempo = 0;
        monedas = 0;
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
        tiempo = 0;
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
        //Invoke(nameof(NewGame), 3f);
        SceneManager.LoadScene("GameOver");
    }
    public void AgregarMoneda()
    {
        monedas++;
        if (monedas == 100)
        {
            AgregarVidas();
            monedas = 0;
        }
    }
    public void AgregarVidas()
    {
        vidas++;
    }
}
