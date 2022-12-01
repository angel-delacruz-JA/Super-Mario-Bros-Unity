using UnityEngine;
using System.Collections;

public class Jugador : MonoBehaviour
{
    public SpriteRender smallRender;
    public SpriteRender bigRender;
    public AnimatedSprite corriendo;
    public GameObject sonidomuerto;
    public GameObject sonidoshrink;
    private DeathAnimation deathAnimation;
    private SpriteRender activoRenderer;
    private CapsuleCollider2D capsuleCollider;
    public bool big => bigRender.enabled;
    public bool small => smallRender.enabled;
    public bool dead => deathAnimation.enabled;
    private AudioSource musica;
    public bool starpower { get; private set; }
    private void Awake()
    {
        corriendo = GetComponent<AnimatedSprite>();
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        activoRenderer = smallRender;
    }
    public void Hit()
    {
        if (!dead && !starpower)
        {
            if (big)
            {
                Shrink();
            }
            else
            {
                Instantiate(sonidomuerto);
                Death();
            }
        }

    }
    private void Shrink()
    {
        Instantiate(sonidoshrink);
        smallRender.enabled = true;
        bigRender.enabled = false;
        activoRenderer = smallRender;
        capsuleCollider.size = new Vector2(1f, 1f);
        capsuleCollider.offset = new Vector2(0f, 0f);
        StartCoroutine(ScaleAnimation());
    }

    public void Crecer()
    {
        smallRender.enabled = false;
        bigRender.enabled = true;
        activoRenderer = bigRender;
        capsuleCollider.size = new Vector2(1f, 2f);
        capsuleCollider.offset = new Vector2(0f, 0.5f);
        StartCoroutine(ScaleAnimation());
    }
    public void Death()
    {
        smallRender.enabled = false;
        bigRender.enabled = false;
        deathAnimation.enabled = true;
        
        GameManager.Instancia.ResetLevel(10f);
    }

    private IEnumerator ScaleAnimation()
    {
        float elapsed = 0f;
        float duracion = 0.5f;

        while (elapsed < duracion)
        {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0)
            {
                smallRender.enabled = !smallRender.enabled;
                bigRender.enabled = !bigRender.enabled;
            }
            yield return null;
        }
        smallRender.enabled = false;
        bigRender.enabled = false;
        activoRenderer.enabled = true;
    }

    public void StarPower(float duracion = 28f)
    {
        StartCoroutine(StarPowerAnimacion(duracion));
    }
    private IEnumerator StarPowerAnimacion(float duracion)
    {
        starpower = true;
        float elapsed = 0f;
        while (elapsed < duracion)
        {
            elapsed += Time.deltaTime;
            if (Time.frameCount % 4 == 0)
            {
                activoRenderer.spriterender.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            }
            yield return null;
        }
        activoRenderer.spriterender.color = Color.white;
        starpower = false;
    }

}
