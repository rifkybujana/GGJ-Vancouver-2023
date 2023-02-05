using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject ButtonUI;
    [SerializeField] private colors color;
    [SerializeField] private Animator UIAnimator;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ButtonUI.SetActive(false);

        UIAnimator.enabled = false;
    }

    private void Update()
    {
        if (ButtonUI.activeSelf && Input.GetKeyDown(KeyCode.F))
            Collect();
    }

    private void Collect()
    {
        animator.SetTrigger("collect");
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;
        player.GetComponent<PlayerController>().checkpoint = transform;
        player.GetComponent<Skill>().AddColor(color);
    }

    public void ShowPicture()
    {
        UIAnimator.enabled = true;
    }

    public void disableObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            ButtonUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            ButtonUI.SetActive(false);
    }

}
