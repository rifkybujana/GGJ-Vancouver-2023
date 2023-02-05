using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDisappear : MonoBehaviour
{
    [SerializeField] private GameObject sprite;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            animator.SetTrigger("Shake");
    }

    public void ResetState()
    {
        sprite.SetActive(true);
        animator.ResetTrigger("Shake");
        animator.Play("Idle");
    }
}
