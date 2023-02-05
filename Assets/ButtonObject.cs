using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private GameObject ButtonUI;
    [SerializeField] private GameObject target;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ButtonUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonUI.activeSelf && Input.GetKeyDown(KeyCode.F))
            Activate();
    }

    public void Activate()
    {
        animator.SetTrigger("Pressed");
        ButtonUI.SetActive(true);
        target.GetComponent<Rigidbody2D>().isKinematic = false;
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
