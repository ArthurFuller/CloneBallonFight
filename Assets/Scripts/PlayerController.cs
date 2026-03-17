using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float vel = 5.0f;
    [SerializeField] float upForce = 5.0f;
    //[SerializeField] float gravity = 1.5f;
    [SerializeField] float limiteX = 7.5f;

    [SerializeField] GameController gameController;

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

        if (Input.GetAxis("Horizontal") < 0) 
        { 
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (transform.position.x < -limiteX || transform.position.x > limiteX)
        {
            transform.position = new Vector2(transform.position.x * -1, transform.position.y);
        }

        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            gameController.coinsCount++;            
        }
    }
}
