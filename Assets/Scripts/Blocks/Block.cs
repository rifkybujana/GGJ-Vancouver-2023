using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colors {Red, Blue, Yellow, White, None};

public class Block : MonoBehaviour
{
    public colors colorCategory = colors.White;

    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color activatedColor = Color.white;

    [SerializeField] private float activationSpeed = 1;

    private float timer = 0;

    private bool inContact = false;
    private bool isActivated = false;

    private SpriteRenderer sprite;

    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = defaultColor;
    }

    private void Update() 
    {
        sprite.color = isActivated ? Color.Lerp(sprite.color, activatedColor, Mathf.PingPong(timer, 1)):
                       Color.Lerp(sprite.color, defaultColor, Mathf.PingPong(timer, 1));

        timer += Time.deltaTime * activationSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // change color
        if (other.gameObject.tag == "Player")
        {
            setActivation(true);
            inContact = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        // reset color
        if (other.gameObject.tag == "Player")
        {
            inContact = false;
            setActivation(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            setActivation(true);
            inContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            inContact = false;
            setActivation(false);
        }
    }

    public void setActivation(bool activation)
    {
        if (inContact)
            return;

        isActivated = activation;
        timer = 0f;
    }

}
