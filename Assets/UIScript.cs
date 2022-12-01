using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI monedas;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI tiempo;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        monedas.text = GameManager.Instancia.monedas.ToString();
        vidas.text = GameManager.Instancia.vidas.ToString();
        tiempo.text = GameManager.Instancia.tiempo.ToString("f0");
    }
}
