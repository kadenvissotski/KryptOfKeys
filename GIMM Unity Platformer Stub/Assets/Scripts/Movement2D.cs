using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 8f;
    public bool isGrounded;
    private SpriteRenderer sprite;

    public float dashDistance = 7f;
    public float dashCooldown = 1f;
    public float groundedRayLength = 1.0f; // Length of the ray to check if the player is grounded
    public LayerMask groundLayer; // Layer(s) considered as ground

    private bool canDash = true;
    private Vector3 dashDirection;


    private bool canDoubleJump;

    [SerializeField] private TrailRenderer tr;
    private Rigidbody2D rb;

    public void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        Jump();

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = true;
        }

        if ((canDash && Input.GetKeyDown(KeyCode.LeftShift)) || (canDash && Input.GetKeyDown(KeyCode.RightShift)) || (canDash && Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            dashDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;

            if (dashDirection != Vector3.zero)
            {
                StartCoroutine(Dash());
            }
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0f, jumpForce));
                canDoubleJump = true;
            }
      
            else
            {
                if (canDoubleJump) {
                rb.velocity = Vector2.up * jumpForce;
                canDoubleJump = false; 
                }
            }
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;

        Vector3 targetPosition = transform.position + dashDirection * dashDistance;

        float startTime = Time.time;
        while (Time.time < startTime + 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}

