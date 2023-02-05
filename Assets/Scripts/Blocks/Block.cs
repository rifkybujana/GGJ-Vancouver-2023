using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colors {None, White, Red, Blue, Yellow, Finish};

public class Block : MonoBehaviour
{
    public colors colorCategory = colors.White;


    [SerializeField] private Block connectedBlock;
    [SerializeField] private Color defaultColor = Color.black;
    [SerializeField] private Color activatedColor = Color.white;

    [SerializeField] private float activationSpeed = 1;

    private float timer = 0;

    private bool inContact = false;
    private bool isActivated = false;

    [SerializeField] private SpriteRenderer sprite;

    private void Start() 
    {
        if (sprite == null)
            sprite = GetComponent<SpriteRenderer>();
        sprite.color = defaultColor;
    }

    private void Update() 
    {
        sprite.color = isActivated ? Color.Lerp(sprite.color, activatedColor, Mathf.PingPong(timer, 1)):
                       Color.Lerp(sprite.color, defaultColor, Mathf.PingPong(timer, 1));

        timer += Time.deltaTime * activationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            setActivation(true);

            if (connectedBlock != null)
                connectedBlock.setActivation(true);

            inContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            inContact = false;

            if (connectedBlock != null)
                connectedBlock.setActivation(true);

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
