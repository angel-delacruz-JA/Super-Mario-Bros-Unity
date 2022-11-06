using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private float inputAxis;
    private Camera camara;
    private Vector2 velocity;
    public float moveSpeed = 8f;
    public float  maxAltura = 5f;
    public float maxTiempoSalto = 1f;
    public float fuerzaSalto => (2f * maxAltura) /  (maxTiempoSalto / 2f);
    public float gravedad => (-2f * maxAltura) / Mathf.Pow(maxTiempoSalto / 2f , 2);

    public bool suelo { get; private set; }
    public bool saltando { get; private set; }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camara = Camera.main;
    }
    private void Update()
    {
        MovimientoHorizontal();

        suelo = rigidbody.Raycast(Vector2.down);

        if (suelo)
        {
            movimientoSuelo();
        }

        aplicarGravedad();
    }

    private void MovimientoHorizontal()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);
    }

    private void movimientoSuelo()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        saltando = velocity.y < 0f;
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = fuerzaSalto;
            saltando = true;
        }
    }

    private void aplicarGravedad()
    {
        bool cayendo = velocity.y < 0f || !Input.GetButton("Jump");
        float multiplicador = cayendo ? 2f : 1f;
        velocity.y += gravedad * multiplicador * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravedad / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 posicion = rigidbody.position;
        posicion += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camara.ScreenToWorldPoint(Vector3.zero);
        Vector2 rightEdge = camara.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        posicion.x = Mathf.Clamp(posicion.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
        rigidbody.MovePosition(posicion);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         
    }
}
