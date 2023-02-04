using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    #region Public/Serializable Variable

    [SerializeField] private SpriteRenderer sprite;

    [Header("Horizontal Movement Settings")]

    [SerializeField] private float speed;

    #region Jump Settings

    [Space(10)]

    [Header("Jump Settings")]

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float jumpStamina;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float jumpCut = 0.5f;
    [SerializeField] private float jumpPressedRememberTime = 0.2f;
    [SerializeField] private float groundedRememberTime = 0.2f;

    [Space(10)]

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Transform groundCheck;

    #endregion

    #endregion

    #region Private/Hidden/Protected Variable

    private float jumpPressedRemember = 0;
    private float groundedRemember = 0;

    private bool isGrounded;
    private bool isJump;

    private Rigidbody2D rb;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // check if player touch ground at this current frame
        isGrounded = CheckGround();

        if (groundedRemember > -1)
            groundedRemember -= Time.deltaTime;

        if (isGrounded)
        {
            groundedRemember = groundedRememberTime;
            HorizontalMove(Input.GetAxis("Horizontal"));
        }
        else
        {
            HorizontalMove(Input.GetAxis("Air Horizontal"));
        }

        if (jumpPressedRemember > -1)
            jumpPressedRemember -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            jumpPressedRemember = jumpPressedRememberTime;

            if (groundedRemember > 0)
                isJump = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(
                    rb.velocity.x,
                    rb.velocity.y * jumpCut
                );

            isJump = false;
        }

        if (jumpPressedRemember > 0 && groundedRemember > 0)
        {
            jumpPressedRemember = 0;
            groundedRemember = 0;

            Jump();
        }
    }

    /// <summary>
    /// Move player toward a <c>direction</c>
    /// </summary>
    /// <param name="direction">a float number within [-1, 1]</param>
    /// <example>
    /// for example:
    /// <code>
    /// HorizontalMove(-1);  // move player to the left
    /// HorizontalMove(0);   // stop player
    /// HorizontalMove(0.5); // move player half speed to the right
    /// </code>
    /// </example>
    private void HorizontalMove(float direction)
    {
        rb.velocity = new Vector2(
            direction * speed,
            rb.velocity.y
        );
    }

    /// <summary>
    /// Detect object with <c>GroundMask</c> mask at <c>GroundCheck</c> position and whithin <c>GroundCheck</c> radius.
    /// </summary>
    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
    }

    /// <summary>
    /// Set player <c>y velocity</c> to <c>JumpVelocity</c>
    /// </summary>
    private void Jump()
    {
        rb.velocity = new Vector2(
            rb.velocity.x,
            jumpVelocity
        );
    }
}
