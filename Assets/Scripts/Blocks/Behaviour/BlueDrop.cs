using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDrop : MonoBehaviour
{
    private Animator animator;

    private Vector2 firstPosition;

    private void Start()
    {
        firstPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            animator.SetTrigger("Shake");
    }

    public void Drop()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public void ResetState()
    {
        transform.position = firstPosition;
        animator.ResetTrigger("Shake");
        animator.Play("Idle");
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
