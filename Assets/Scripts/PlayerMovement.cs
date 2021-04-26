using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float speed = 2f;
    float maxSpeed = 10f;
    bool isJumping = false;
    [SerializeField]
    bool playerGrounded;
    public float horizontalMovement;
    public Rigidbody2D rb;
    public CapsuleCollider2D boxCollider;
    Vector3 currVelocity = Vector3.zero;
    [SerializeField]
    LayerMask platformLayer;
    [SerializeField]
    bool spriteIsFlipped = false;
    [SerializeField]
    AudioSource audioPlayer;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Debug.Log(rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) >= maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        animator.SetFloat("Speed", System.Math.Abs(horizontalMovement));
        animator.SetBool("Jump", isJumping);
        animator.SetFloat("VerticalVelocity", rb.velocity.y);
        animator.SetBool("isGrounded", playerGrounded);

        if (horizontalMovement < 0 && !spriteIsFlipped) {
            GetComponent<SpriteRenderer>().flipX = true;
            spriteIsFlipped = true;
        }
        else if (horizontalMovement > 0 && spriteIsFlipped) {
            GetComponent<SpriteRenderer>().flipX = false;
            spriteIsFlipped = false;
        }

        if (Input.GetKeyDown("space")) {
            isJumping = true;
        }

    }

    private void FixedUpdate() {
        playerGrounded = isGrounded();
        MovePlayer(horizontalMovement, isJumping, playerGrounded);
        isJumping = false;
    }

    void MovePlayer(float horizontalMovement, bool isJumping, bool isGrounded) {
        Vector3 target = new Vector2(horizontalMovement * speed, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref currVelocity, 0.05f);

        if (isJumping && isGrounded) {
            audioPlayer.Play();
            rb.AddForce(new Vector2(0f, 225f));
            isJumping = false;
        }
    }

    bool isGrounded() {
        RaycastHit2D rayCastResult = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + 0.05f, platformLayer);
        return rayCastResult.collider != null;

    }
}
