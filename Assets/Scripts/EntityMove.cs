using UnityEngine;

public class EntityMove : MonoBehaviour
{
    public float velocidad = 1f;
    public Vector2 direccion = Vector2.left;
    private Rigidbody2D rigibody;
    private Vector2 velocity;

    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        enabled = false;
    }
    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        rigibody.WakeUp();
    }

    private void OnDisable()
    {
        rigibody.velocity = Vector2.zero;
        rigibody.Sleep();
    }
    private void FixedUpdate()
    {
        velocity.x = direccion.x * velocidad;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        rigibody.MovePosition(rigibody.position + velocity * Time.fixedDeltaTime);

        if (rigibody.Raycast(direccion))
        {
            direccion = -direccion;
        }
        if (rigibody.Raycast(Vector2.down))
        {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }
    }
}
