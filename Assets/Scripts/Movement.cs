using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collision collision;
    private float speed = 10f;
    public float wallSlideSpeed = 2f;

    [Header("Jump")]
    [Range(1, 10)]
    public float jumpVelocity = 7;
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 1.5f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public bool isDashing;
    private float dashTime;

    [Header("Dash Particles")]
    public ParticleSystem dashParticles;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collision>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Walk(horizontalInput);

        // Glissement sur le mur
        if ((collision.onRightWall && horizontalInput > 0) || (collision.onLeftWall && horizontalInput < 0))
        {
            // Le personnage est en train de glisser le long du mur
            if (!collision.onGround && rb.velocity.y < 0)  // Assurez-vous qu'il ne soit pas au sol et qu'il se déplace vers le bas
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }

        Jump();

        if (Input.GetButtonDown("Fire3") && !isDashing && (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0))
        {
            StartCoroutine(Dash());
        }
    }


    private void Walk(float horizontalInput)
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (collision.onGround) // Si le joueur est au sol
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
            else if (collision.onRightWall) // Si le joueur est en contact avec un mur à droite
            {
                rb.velocity = new Vector2(-jumpVelocity, jumpVelocity);
            }
            else if (collision.onLeftWall) // Si le joueur est en contact avec un mur à gauche
            {
                rb.velocity = new Vector2(jumpVelocity, jumpVelocity);
            }
        }

        // Pour mieux contrôler le saut en fonction de si le joueur maintient le bouton de saut ou non
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }



    private IEnumerator Dash()
    {
        isDashing = true;
        dashParticles.Play();

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 dashDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Sauvegarder la gravité actuelle et la mettre à 0
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.velocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        rb.velocity = Vector2.zero;

        // Rétablir la gravité à sa valeur originale
        rb.gravityScale = originalGravity;

        isDashing = false;
    }


}