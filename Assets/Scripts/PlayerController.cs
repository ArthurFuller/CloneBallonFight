using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float vel = 5.0f;
    [SerializeField] float upForce = 5.0f;
    //[SerializeField] float gravity = 1.5f;
    [SerializeField] float limiteX = 4.0f;

    bool impulsionar;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


    }

    void Update()
    {
        callJump();
    }

    private void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * vel * Time.deltaTime;
        transform.Translate(x, 0, 0);
    }

    void callJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            impulsionar = true;
        }
    }

    void Jump()
    {
        if (impulsionar)
        {
            rb.linearVelocity = new Vector2(0, upForce);
            impulsionar = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            collision.collider.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
