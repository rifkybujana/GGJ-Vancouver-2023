using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject ButtonUI;
    [SerializeField] private ParticleSystem collectParticle;

    private void Start()
    {
        ButtonUI.SetActive(false);
    }

    private void Update()
    {
        if (ButtonUI.activeSelf && Input.GetKeyDown(KeyCode.F))
            Collect();
    }

    private void Collect()
    {
        collectParticle.Play();

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
