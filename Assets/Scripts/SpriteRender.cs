using UnityEngine;

public class SpriteRender : MonoBehaviour
{
    public SpriteRenderer spriterender { get; private set; }
    private PlayerMove movimiento;
    public Sprite idle;
    public Sprite salto;
    private AudioSource saltando;
    public Sprite desliz;
    public Sprite dead;
    private Jugador jug;
    public AnimatedSprite correr;

    private void Awake()
    {
        saltando = GetComponent<AudioSource>();
        jug = GetComponent<Jugador>();
        spriterender = GetComponent<SpriteRenderer>();
        movimiento = GetComponentInParent<PlayerMove>();
    }

    private void OnEnable()
    {
        spriterender.enabled = true;
    }

    private void OnDisable()
    {
        spriterender.enabled = false;
        correr.enabled = false;
    }

    private void LateUpdate()
    {
        correr.enabled = movimiento.corriendo;
        if (movimiento.saltando)
        {
            spriterender.sprite = salto;
        }else if (movimiento.deslizando)
        {
            spriterender.sprite = desliz;
        }
        else if(!movimiento.corriendo)
        {
            spriterender.sprite = idle;
        }
    }
}
