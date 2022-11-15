using UnityEngine;

public class Jugador : MonoBehaviour
{
    public SpriteRender smallRender;
    public SpriteRender bigRender;
    private DeathAnimation deathAnimation;
    public bool big => bigRender.enabled;
    public bool small => smallRender.enabled;
    public bool dead => deathAnimation.enabled;

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }
    public void Hit()
    {
        if (big) {
            Shrink();
        }
        else
        {
            Death();
        }
    }    
    private void Shrink()
    {

    }
    private void Death()
    {
        smallRender.enabled = false;
        bigRender.enabled = false;
        deathAnimation.enabled = true;

        GameManager.Instancia.ResetLevel(3f);
    }
}
