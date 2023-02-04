using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public enum colors {Red, Blue, Yellow, White};

    public colors colorCategory = colors.White;

    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color activatedColor = Color.white;

    [SerializeField] private float activationSpeed = 1;

    private float timer = 0;

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
            isActivated = true;
            timer = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // reset color
        if (other.gameObject.tag == "Player")
        {
            isActivated = false;
            timer = 0f;
        }
    }

}
